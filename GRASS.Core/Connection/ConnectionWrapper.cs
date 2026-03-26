using System.Net.Sockets;
using GRASS.Core.Enums;
using PKHeX.Core;
using GRASS.Core.Structures;
using SysBot.Base;
using static SysBot.Base.SwitchButton;
using static SysBot.Base.SwitchCommand;
using GRASS.Core.KeyboardEntry;

namespace GRASS.Core.Connection;

public class ConnectionWrapperAsync(SwitchConnectionConfig Config, Action<string> StatusUpdate) : Offsets
{
    public readonly ISwitchConnectionAsync Connection = Config.Protocol switch
    {
        SwitchProtocol.USB => new SwitchUSBAsync(Config.Port),
        _ => new SwitchSocketAsync(Config),
    };

    public bool Connected => IsConnected;
    private bool IsConnected { get; set; }
    private readonly bool CRLF = Config.Protocol is SwitchProtocol.WiFi;

    private string title { get; set; } = string.Empty;
    private readonly SAV3FRLG sav = new();


    public async Task<(bool, string)> Connect(CancellationToken token)
    {
        if (Connected) return (true, "");

        try
        {
            StatusUpdate("Connecting...");
            Connection.Connect();
            IsConnected = true;

            StatusUpdate("Detecting Game Version");
            title = await Connection.GetTitleID(token).ConfigureAwait(false);
            if (!LanguageVersionOffsetsFRLG.IsTitleIDValidFRLG(title))
            {
                IsConnected = false;
                return (false, $"{title} is not a valid FRLG title.");
            }

            await GetFakeTrainerSAV(title, token).ConfigureAwait(false);
            KeyboardTools.SetKeyboard((LanguageID)sav.Language);

            StatusUpdate("Configuring sysmodule...");
            var cmd = Configure(SwitchConfigureParameter.mainLoopSleepTime, 15, CRLF);
            await Connection.SendAsync(cmd, token).ConfigureAwait(false);


            StatusUpdate("Connected!");
            return (true, "");
        }
        catch (SocketException e)
        {
            IsConnected = false;
            return (false, e.Message);
        }
    }

    public async Task<(bool, string)> DisconnectAsync(CancellationToken token)
    {
        if (!Connected) return (true, "");

        try
        {
            StatusUpdate("Disconnecting controller");
            await DetachController(token).ConfigureAwait(false);

            StatusUpdate("Disconnecting...");
            Connection.Disconnect();
            IsConnected = false;
            StatusUpdate("Disconnected!");
            return (true, "");
        }
        catch (SocketException e)
        {
            IsConnected = false;
            return (false, e.Message);
        }
    }

    public Game GetSavVersion() => (Game)(sav.Version - GameVersion.FR);

    public async Task GetFakeTrainerSAV(string titleID, CancellationToken token)
    {
        var block = sav.SmallBuffer;
        var smallOffset = await GetSmallOffset(titleID, token).ConfigureAwait(false);
        if (smallOffset == 0)
            throw new Exception("Failed to get small block offset. Is your game version supported?");
        var read = await Connection.ReadBytesAsync(smallOffset, sav.Small.Length, token).ConfigureAwait(false);
        read.CopyTo(block);
        sav.Language = (int)LanguageVersionOffsetsFRLG.GetLanguageFromTitleID(titleID);
        sav.Version = LanguageVersionOffsetsFRLG.GetGameVersionFromTitleID(titleID);
    }

    public async Task<uint> GetSmallOffset(string titleID, CancellationToken token)
    {
        var currentSeedOffset = LanguageVersionOffsetsFRLG.GetCurrentSeedOffsetFromTitleID(titleID);
        if (currentSeedOffset == 0)
            return 0;
        var small = currentSeedOffset + SmallShift; // Pointer to small block.
        var data = await Connection.ReadBytesAsync(small, 4, token).ConfigureAwait(false);
        var smallOffset = BitConverter.ToUInt32(data, 0); // This offset is relative to 0x02020000, which is where InitialSeed is.
        if (smallOffset == 0)
            return 0; // In case it's not loaded.
        return InitialSeed + (smallOffset - 0x02020000); // Convert to absolute offset in the heap.        
    }

    public async Task<ushort> GetInitialRNGState(CancellationToken token)
    {
        var data = await Connection.ReadBytesAsync(InitialSeed, 2, token).ConfigureAwait(false);
        var seed = BitConverter.ToUInt16(data, 0);
        return seed;
    }

    public async Task<uint> GetCurrentRNGState(CancellationToken token)
    {
        var offs = LanguageVersionOffsetsFRLG.GetCurrentSeedOffsetFromLanguageAndVersion((LanguageID)sav.Language, sav.Version);
        return await GetCurrentRNGState(offs, token).ConfigureAwait(false);
    }

    public async Task<uint> GetCurrentRNGState(uint offset, CancellationToken token)
    {
        var data = await Connection.ReadBytesAsync(offset, 4, token).ConfigureAwait(false);
        var seed = BitConverter.ToUInt32(data, 0);
        return seed;
    }

    public async Task<bool> GetIsBoxPointerLoaded(CancellationToken token)
    {
        return await GetBoxStartOffset(title, token).ConfigureAwait(false) != 0;
    }

    public async Task<uint> GetBoxStartOffset(string titleID, CancellationToken token)
    {
        var currentSeedOffset = LanguageVersionOffsetsFRLG.GetCurrentSeedOffsetFromTitleID(titleID);
        if (currentSeedOffset == 0)
            return 0;
        var boxes = currentSeedOffset + BoxStartShift; // Pointer to box data block.
        var data = await Connection.ReadBytesAsync(boxes, 4, token).ConfigureAwait(false);
        var boxStartOffset = BitConverter.ToUInt32(data, 0); // This offset is relative to 0x02020000, which is where InitialSeed is.
        if (boxStartOffset == 0)
            return 0; // In case it's not loaded.
        return InitialSeed + (boxStartOffset - 0x02020000); // Convert to absolute offset in the heap.
    }

    public async Task PressHOME(int sleep, CancellationToken token)
    {
        await Connection.SendAsync(Click(HOME, CRLF), token).ConfigureAwait(false);
        await Task.Delay(sleep, token).ConfigureAwait(false);
    }

    public async Task DetachController(CancellationToken token)
    {
        await Connection.SendAsync(SwitchCommand.DetachController(CRLF), token).ConfigureAwait(false);
    }

    public async Task PressButton(SwitchButton btn, int delay, CancellationToken token)
    {
        await Connection.SendAsync(Click(btn, CRLF), token).ConfigureAwait(false);
        await Task.Delay(delay, token).ConfigureAwait(false);
    }

    public async Task DoTurboCommand(string command, CancellationToken token)
    {
        switch (command)
        {
            case "Wait (100ms)":
                await Task.Delay(100, token).ConfigureAwait(false);
                break;
            case "Wait (500ms)":
                await Task.Delay(500, token).ConfigureAwait(false);
                break;
            case "Wait (1000ms)":
                await Task.Delay(1_000, token).ConfigureAwait(false);
                break;
            default:
                _ = command switch
                {
                    "A" => await Connection.SendAsync(Click(A, CRLF), token).ConfigureAwait(false),
                    "B" => await Connection.SendAsync(Click(B, CRLF), token).ConfigureAwait(false),
                    "X" => await Connection.SendAsync(Click(X, CRLF), token).ConfigureAwait(false),
                    "Y" => await Connection.SendAsync(Click(Y, CRLF), token).ConfigureAwait(false),

                    "Left Stick (L3)" => await Connection.SendAsync(Click(LSTICK, CRLF), token).ConfigureAwait(false),
                    "Right Stick (R3)" => await Connection.SendAsync(Click(RSTICK, CRLF), token).ConfigureAwait(false),

                    "L" => await Connection.SendAsync(Click(L, CRLF), token).ConfigureAwait(false),
                    "R" => await Connection.SendAsync(Click(R, CRLF), token).ConfigureAwait(false),
                    "ZL" => await Connection.SendAsync(Click(ZL, CRLF), token).ConfigureAwait(false),
                    "ZR" => await Connection.SendAsync(Click(ZR, CRLF), token).ConfigureAwait(false),

                    "+" => await Connection.SendAsync(Click(PLUS, CRLF), token).ConfigureAwait(false),
                    "-" => await Connection.SendAsync(Click(MINUS, CRLF), token).ConfigureAwait(false),

                    "Up (Hold)" => await Connection.SendAsync(SetStick(SwitchStick.LEFT, 0, 30000, CRLF), token).ConfigureAwait(false),
                    "Down (Hold)" => await Connection.SendAsync(SetStick(SwitchStick.LEFT, 0, -30000, CRLF), token).ConfigureAwait(false),
                    "Left (Hold)" => await Connection.SendAsync(SetStick(SwitchStick.LEFT, -30000, 0, CRLF), token).ConfigureAwait(false),
                    "Right (Hold)" => await Connection.SendAsync(SetStick(SwitchStick.LEFT, 30000, 0, CRLF), token).ConfigureAwait(false),
                    "Release Stick" => await Connection.SendAsync(ResetStick(SwitchStick.LEFT, CRLF), token).ConfigureAwait(false),

                    "D-Pad Up" => await Connection.SendAsync(Click(DUP, CRLF), token).ConfigureAwait(false),
                    "D-Pad Down" => await Connection.SendAsync(Click(DDOWN, CRLF), token).ConfigureAwait(false),
                    "D-Pad Left" => await Connection.SendAsync(Click(DLEFT, CRLF), token).ConfigureAwait(false),
                    "D-Pad Right" => await Connection.SendAsync(Click(DRIGHT, CRLF), token).ConfigureAwait(false),

                    "HOME" => await Connection.SendAsync(Click(HOME, CRLF), token).ConfigureAwait(false),
                    "Screenshot" => await Connection.SendAsync(Click(CAPTURE, CRLF), token).ConfigureAwait(false),

                    _ => throw new NotImplementedException(),
                };
                break;
        }
    }
}

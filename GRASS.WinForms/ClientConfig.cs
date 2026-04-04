using SysBot.Base;

namespace GRASS.WinForms;

public class ClientConfig
{
    // Connection
    public string IP { get; set; } = "192.168.0.0";
    public int UsbPort { get; set; } = 0;
    public SwitchProtocol Protocol { get; set; } = SwitchProtocol.WiFi;
    public int Game { get; set; } = 0;

    // Fields
    public int TID { get; set; } = 1337;
    public int SID { get; set; } = 1390;

    // TID Reset
    public string OT_Name { get; set; } = "Lego";
    public int NameEntryButtonPressDelay { get; set; } = 110;
    public int NameEntryPageChangeDelay { get; set; } = 800;
    public int NameEntryRejectDelay { get; set; } = 4_000;
    public int NameEntryReloadNameScreenDelay { get; set; } = 1_700;

    // Misc
    public bool ColorHiddenPowerResults { get; set; } = false;
}

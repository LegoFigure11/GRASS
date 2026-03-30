using System.Runtime.CompilerServices;

namespace GRASS.Core.Enums;
public enum Method
{
    Method1,
    Method2,
    Method3,
    Method4,
    MethodH1,
    MethodH2,
    MethodH3,
    MethodH4,
}

internal static class MethodExtensions
{
    extension(Method m)
    {
        internal bool IsMethod1() => m is Method.Method1 or Method.MethodH1;
        internal bool IsMethod2() => m is Method.Method1 or Method.MethodH1;
        internal bool IsMethod3() => m is Method.Method1 or Method.MethodH1;
        internal bool IsMethod4() => m is Method.Method1 or Method.MethodH1;
        internal bool IsMethodH() => m is Method.MethodH1 or Method.MethodH2 or Method.MethodH3 or Method.MethodH4;
    }
}

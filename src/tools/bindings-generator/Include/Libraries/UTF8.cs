using RobloxEngine;

[LuauClass("utf8")]
public static class UTF8
{
     // public extern static string Char(Tuple<double>)

     [LuauFunction("codes")]
     public extern static (Action, string, double) Codes(string str);

     // codepoint

     [LuauFunction("len")]
     public extern static double Len(string s, double i, double j);

     [LuauFunction("offset")]
     public extern static double? Offset(string s, double n, double i);

     [LuauFunction("graphemes")]
     public extern static Action Graphemes(string str, double i, double j);

     [LuauFunction("nfcnormalize")]
     public extern static string NFCNormalize(string str);

     [LuauFunction("nfdnormalize")]
     public extern static string NFDNormalize(string str);

     [LuauProperty("charpattern")]
     public static string CharPattern { get; }
}

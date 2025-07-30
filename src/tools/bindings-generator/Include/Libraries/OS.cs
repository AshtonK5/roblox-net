using RobloxEngine;

[LuauClass("os")]
public static class OS
{
     [LuauFunction("clock")]
     public extern static double Clock();

     // [LuauGlobal("date")]
     // public extern static            SKIP      FOR NOW...

     [LuauFunction("difftime")]
     public extern static double DiffTime(double t2, double t1);

     [LuauFunction("time")]
     public extern static double Time(dynamic time);
}

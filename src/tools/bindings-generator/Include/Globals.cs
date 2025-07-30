// WIP

namespace RobloxEngine;

public abstract class GlobalSettings;
public abstract class UserSettings;
public abstract class DataModel;
public abstract class Plugin;
public abstract class LuaSourceContainer;
public abstract class Workspace;

// Might not be in generated bindings
public abstract class Userdata;

public static class Luau
{
     // Luau Globals
     [LuauGlobal("assert")]
     public extern static dynamic Assert(dynamic value, string errorMessage);

     [LuauGlobal("error")]
     public extern static void Error(object message, double level);

     [LuauGlobal("gcinfo")]
     public extern static double GCInfo();

     [LuauGlobal("getmetatable")]
     public extern static object GetMetaTable(object t);

     // ipairs(t : Array):function,Array,number
     // Returns an iterator function and the table for use in a for loop.

     [LuauGlobal("loadstring")]
     public extern static object LoadString(string contents, string chunkName);

     [LuauGlobal("newproxy")]
     public extern static Userdata NewProxy(bool addMetatable);

     [LuauGlobal("next")]
     public extern static (object, object) Next(object t, object lastKey);

     [LuauGlobal("pairs")]
     public extern static (Action, object) Pairs(object t);
     // public extern static (bool, object) PCall(Action func, Tuple args);

     [LuauGlobal("print")]
     public extern static void Print(params dynamic[] args);

     [LuauGlobal("rawequal")]
     public extern static bool RawEqual(dynamic v1, dynamic v2);

     [LuauGlobal("rawget")]
     public extern static dynamic RawGet(dynamic t, dynamic index);

     [LuauGlobal("rawlen")]
     public extern static dynamic RawLen(dynamic t);

     [LuauGlobal("rawset")]
     public extern static dynamic RawSet(dynamic t, dynamic index, dynamic value);

     [LuauGlobal("type")]
     public static string? Type { get; }

     // Roblox Globals
     [LuauGlobal("ElapsedTime")]
     public extern static double ElapsedTime();

     [LuauGlobal("settings")]
     public extern static GlobalSettings Settings();

     [LuauGlobal("tick")]
     public extern static double Tick();

     [LuauGlobal("time")]
     public extern static double Time();

     [LuauGlobal("typeof")]
     public extern static string TypeOf(dynamic obj);

     [LuauGlobal]
     public extern static UserSettings UserSettings();

     [LuauGlobal("version")]
     public extern static string Version();

     [LuauGlobal("warn")]
     public extern static void Warn(params dynamic[] args);

     //[LuauGlobal]
     //public static Enums Enum { get; } // enums datatype doesn't exist yet!

     //[LuauGlobal("game")]
     public extern static DataModel? Game { [LuauGlobal("game")] get; }

     //[LuauGlobal("plugin")]
     public extern static Plugin? plugin { [LuauGlobal("plugin")] get; }

     //[LuauGlobal("script")]
     public extern static LuaSourceContainer? Script { [LuauGlobal("script")] get; }

     //[LuauGlobal("workspace")]
     public extern static Workspace? Workspace { [LuauGlobal("workspace")] get; }
}

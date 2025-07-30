namespace RobloxEngine;

public abstract class LuauAttribute(string? name) : Attribute
{
    protected LuauAttribute() : this(null) { }
}

public sealed class LuauProperty(string name) : LuauAttribute(name);
public sealed class LuauFunction(string name) : LuauAttribute(name);
public sealed class LuauClass(string name) : LuauAttribute(name);

public sealed class LuauGlobal(string? name = null) : LuauAttribute(name);
public sealed class LuauMeta(string name) : LuauAttribute(name);

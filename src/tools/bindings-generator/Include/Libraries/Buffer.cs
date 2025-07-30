// Check back on this file [WIP]
using RobloxEngine;

[LuauClass("buffer")]
public abstract class Buffer
{

    [LuauFunction("create")]
    public extern static Buffer Create(double size);

    [LuauFunction("fromstring")]
    public extern static Buffer FromString(string str);

    [LuauFunction("tostring")]
    public extern static string ToString(Buffer b);

    [LuauFunction("len")]
    public extern static double Len(Buffer b);

    [LuauFunction("readbits")]
    public extern static double ReadBits(Buffer b, double bitOffset, double bitCount);

    [LuauFunction("readi8")]
    public extern static double ReadI8(Buffer b, double offset);

    [LuauFunction("readu8")]
    public extern static double ReadU8(Buffer b, double offset);

    [LuauFunction("readi16")]
    public extern static double ReadI16(Buffer b, double offset);

    [LuauFunction("readu16")]
    public extern static double ReadU16(Buffer b, double offset);

    [LuauFunction("readi32")]
    public extern static double ReadI32(Buffer b, double offset);

    [LuauFunction("readu32")]
    public extern static double ReadU32(Buffer b, double offset);

    [LuauFunction("readf64")]
    public extern static double ReadF32(Buffer b, double offset);

    [LuauFunction("readf64")]
    public extern static double ReadF64(Buffer b, double offset);

    [LuauFunction("writebits")]
    public extern static void WriteBits(Buffer b, double bitOffset, double bitCount, double value);

    [LuauFunction("writei8")]
    public extern static void WriteI8(Buffer b, double offset, double value);

    [LuauFunction("writeu8")]
    public extern static void WriteU8(Buffer b, double offset, double number);

    [LuauFunction("writei16")]
    public extern static void WriteI16(Buffer b, double offset, double number);

    [LuauFunction("writeu16")]
    public extern static void WriteU16(Buffer b, double offset, double value);

    [LuauFunction("writeu32")]
    public extern static void WriteU32(Buffer b, double offset, double value);

    [LuauFunction("writef32")]
    public extern static void WriteF32(Buffer b, double offset, double value);

    [LuauFunction("writef64")]
    public extern static void WriteF64(Buffer b, double offset, double value);

    [LuauFunction("readstring")]
    public extern static string ReadString(Buffer b, double offset, double count);

    [LuauFunction("writestring")]
    public extern static void WriteString(Buffer b, double offset, string value, double? count);

    [LuauFunction("copy")]
    public extern static void Copy(Buffer target, double targetOffset, Buffer source, double? sourceOffset, double? count);

    [LuauFunction("fill")]
    public extern static void Fill(Buffer b, double offset, double value, double? count);
}

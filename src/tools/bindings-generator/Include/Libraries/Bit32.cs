// This file is still rusty make sure to come back to it [WIP]
using RobloxEngine;

[LuauClass("bit32")]
public static class Bit32
{
    // <summary> Returns a number after its bits have been arithmetically shifted to the right by a given displacement. </summary>
    [LuauFunction("arshift")]
    public extern static double ArShift(double x, double disp);

    // Returns the bitwise AND of all provided numbers.
    // public extern static double BAnd(Tuple numbers) // roblox on docs don't explain what this tuple even is

    // Returns the bitwise negation of a given number.
    [LuauFunction("bnot")]
    public extern static double BNot(double x);

    // Returns the bitwise OR of all provided numbers.

    [LuauFunction("bor")]
    public extern static double Bor(double x);

    // Returns a boolean describing whether the bitwise and of its operands is different from zero.
    // public extern static bool BTest(Tuple numbers) what tuple?

    // Returns the bitwise XOR of all provided numbers.
    //public extern static double BXor(Tuple numbers);

    // Returns the given number with the order of the bytes swapped.

    [LuauFunction("byteswap")]
    public extern static double ByteSwap(double x);

    // Returns the number of consecutive zero bits in the 32-bit representation of the provided number starting from the left-most (most significant) bit.

    [LuauFunction("countlz")]
    public extern static double CountLz(double n);

    // Returns the number of consecutive zero bits in the 32-bit representation of the provided number starting from the right-most (least significant) bit.
    [LuauFunction("countrz")]
    public extern static double CountRz(double n);

    // Extract a range of bits from a number and return them as an unsigned number.

    [LuauFunction("extract")]
    public extern static double Extract(double n, double field, double width);

    // Return a copy of a number with a range of bits replaced by a given value.
    [LuauFunction("replace")]
    public extern static double Replace(double n, double v, double field, double width);

    // Returns a number after its bits have been rotated to the left by a given number of times.
    [LuauFunction("lrotate")]
    public extern static double LRotate(double x, double disp);

    // Returns a number whose bits have been logically shifted to the left by a given displacement.
    [LuauFunction("lshift")]
    public extern static double LShift(double x, double disp);

    // Returns a number after its bits have been rotated to the right by a given number of times.
    [LuauFunction("rrotate")]
    public extern static double RRotate(double x, double disp);

    // Returns a number whose bits have been logically shifted to the right by a given displacement.
    [LuauFunction("rshift")]
    public extern static double RShift(double x, double disp);
}

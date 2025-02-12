namespace Vapour.Utils;

using System;


public static class Rand
{
    private static Random _rand = new();

    /// Randomly pick between `0` or `1`.
    public static int Binary()
        => _rand.Next(2);

    /// Randomly pick between `-1` or `1`.
    public static int Direction()
        => 2 * _rand.Next(2) - 1;
}

namespace Vapour.Utils;

using System;


public static class Rand
{
    private static Random _rand = new();

    /// <summary>
    /// Pick a scalar between <c>0f</c> and <c>1f</c>.
    /// </summary>
    /// <returns></returns>
    public static float Scale()
        => (float) _rand.NextDouble();

    /// <summary>
    /// Pick between <c>0</c> or <c>1</c>.
    /// </summary>
    public static int Binary()
        => _rand.Next(2);

    /// <summary>
    /// Pick between <c>-1</c> or <c>1</c>.
    /// </summary>
    public static int Direction()
        => Norm.Signed(_rand.Next(2));
}

namespace Vapour.Utils;


public static class Norm
{
    /// <summary>
    /// Normalise a value in the range <c>[0, 1]</c> to <c>[-1, 1]</c>.
    /// </summary>
    public static int Signed(int value)
        => value * 2 - 1;
        
    /// <summary>
    /// Normalise a value in the range <c>[0.0f, 1.0f]</c> to <c>[-1.0f, 1.0f]</c>.
    /// </summary>
    public static float Signed(float value)
        => value * 2 - 1;
}

namespace Vapour.Colours;


using Vec4 = (float, float, float, float);


public static class Cols
{
    public static readonly Vec4 back = new Colour(0, 0, 0).ToFloats();
}


public struct Colour
{
    /// RGB components. [0-255].
    public int r;
    public int g;
    public int b;

    /// Alpha component. [0-100].
    public int alpha;

    public Colour(int r, int g, int b, int alpha = 100)
    {
        this.r = r;
        this.g = g;
        this.b = b;
        this.alpha = alpha;
    }

    public Vec4 ToFloats()
        => (this.r / 255f,
            this.g / 255f,
            this.b / 255f,
            this.alpha / 100f);
}

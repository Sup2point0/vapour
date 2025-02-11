namespace Vapour;


public class Program
{
    public static void Main(string[] args)
    {
        var pict = new TextureLayer();
        var pixels = new PixelLayer();
        
        using (
            var window = new Window(1200, 1200) {
                pict = pict,
                pixels = pixels,
            }
        )
        {
            window.Run();
        }
    }
}


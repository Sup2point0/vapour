namespace Vapour;

using Vapour.Effects;
using Vapour.Effects.BasicRandomWalk;

public class Program
{
    public static void Main(string[] args)
    {
        var pict = new TextureLayer("../.assets/terabyte.png") {
            vertices = [
                // position cords   texture cords
                0.8f,  0.8f, 0f, 1f, 1f,  // top right
                0.8f, -0.8f, 0f, 1f, 0f,  // bottom right
               -0.8f, -0.8f, 0f, 0f, 0f,  // bottom left
               -0.8f,  0.8f, 0f, 0f, 1f,  // top left
            ],
            indices = [
                0, 1, 3,
                1, 2, 3,
            ]
        };
        
        var effect = new BasicRandomWalkEffect(3);
        
        using (var window = new Window(1200, 1200) {
            pict = pict,
            effects = [effect],
        })
        {
            window.Run();
        }
    }
}


namespace Vapour;


public class Program
{
    public static void Main(string[] args)
    {
        using (var window = new Window(1600, 900))
        {
            float[] vertices = {
                // position cords   texture cords
                0.5f,  0.5f, 0.0f, 1.0f, 1.0f,  // top right
                0.5f, -0.5f, 0.0f, 1.0f, 0.0f,  // bottom right
               -0.5f, -0.5f, 0.0f, 0.0f, 0.0f,  // bottom left
               -0.5f,  0.5f, 0.0f, 0.0f, 1.0f,  // top left
            };
            uint[] indices = {
                0, 1, 3,
                1, 2, 3,
            };

            window.vertices = vertices;
            window.indices = indices;

            window.Run();
        }
    }
}


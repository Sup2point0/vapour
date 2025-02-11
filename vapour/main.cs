namespace Vapour
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var window = new Window(1600, 900))
            {
                float[] vertices = {
                    0.5f, 0.5f, 0.0f,
                    -0.5f, 0.5f, 0.0f,
                    -0.5f, -0.5f, 0.0f,
                    0.5f, -0.5f, 0.0f,
                };
                uint[] indices = {
                    0, 1, 2,
                    2, 0, 3,
                };

                window.AddVertices(vertices);
                window.AddIndexedVertices(vertices, indices);
                window.Run();
            }
        }
    }
}

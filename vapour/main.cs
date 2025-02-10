namespace Vapour
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var game = new Window(1600, 900))
            {
                game.Run();
            }
        }
    }
}

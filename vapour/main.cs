namespace Vapour;

using Vapour.Effects;
using Vapour.Effects.BasicRandomWalk;

public class Program
{
    public static void Main(string[] args)
    {
        var pict = new TextureLayer();
        var effect = new BasicRandomWalkEffect(3);
        
        using (
            Window<bool, BasicRandomWalkMatrix> window = new(1200, 1200) {
                pict = pict,
                effects = [effect],
            }
        )
        {
            window.Run();
        }
    }
}


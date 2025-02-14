namespace Vapour.Effects.BasicRandomWalk;


public class RandomWalker : Walker<bool>
{
    public RandomWalker(EffectMatrix<bool> source, (int x, int y) pos) : base(source, pos)
    {}
}

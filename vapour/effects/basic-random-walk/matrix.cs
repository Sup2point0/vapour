namespace Vapour.Effects.BasicRandomWalk;


public class BasicRandomWalkMatrix : EffectMatrix<bool>
{
    public RandomWalker walker;

    public BasicRandomWalkMatrix(params int[] size) : base(size)
    {
        this.walker = new(this, this.centre);
    }
}

namespace Vapour.Effects;


public class BasicRandomWalkMatrix : EffectMatrix<bool>
{
    RandomWalker walker;

    public BasicRandomWalkMatrix(params int[] size) : base(size)
    {
        this.walker = new(this, this.centre);
    }

    public override void Update()
    {
        this.walker.Update();
    }
}


class RandomWalker : Walker<bool>
{
    public RandomWalker(EffectMatrix<bool> source, (int x, int y) pos) : base(source, pos)
    {}

    public override void Update()
    {
        base.RandomStep();
        this.source[this.xy] = true;
    }
}

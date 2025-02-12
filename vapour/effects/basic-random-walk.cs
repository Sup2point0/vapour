namespace Vapour.Effects;


public class BasicRandomWalk<T> : EffectMatrix<T>
{
    RandomWalker walker;

    public BasicRandomWalk(params int[] size) : base(size)
    {
        this.walker = new RandomWalker(this.centre);
    }

    public void Update()
    {
        this.walker.Update();
    }
}


private class RandomWalker : Walker<BasicRandomWalk>
{
    public override void Update()
    {
        base.RandomStep();
        this.source[this.xy] = true;
    }
}

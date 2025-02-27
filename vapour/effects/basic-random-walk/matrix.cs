namespace Vapour.Effects.BasicRandomWalk;


public class BasicRandomWalkMatrix : EffectMatrix<bool>
{
    public RandomWalker walker;

    public BasicRandomWalkMatrix(int width, int height) : base(width, height)
    {
        this.walker = new(this, this.centre);
    }

    public BasicRandomWalkMatrix((int width, int height) size) : this(size.width, size.height)
    {}

    public BasicRandomWalkMatrix(int size) : this(size, size)
    {}

    public BasicRandomWalkMatrix(int[] size) : this(size[0], size[1])
    {}
}

namespace Vapour.Effects.BasicRandomWalk;

using Vapour.Effects;


public class BasicRandomWalkEffect : EffectExecutive<bool, BasicRandomWalkMatrix>
{
    public BasicRandomWalkEffect(int size) :
        base(
            matrix: new BasicRandomWalkMatrix(size),
            layer: new PixelLayer()
        )
    {}

    public override void OnLoad()
    {
        this.matrix.OnLoad();
        this.layer.OnLoad();
    }

    public override void Update()
    {
        var walker = this.matrix.walker;
        walker.Update();
        this.matrix[walker.xy] = true;

        base.Update();
    }
}

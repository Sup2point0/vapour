namespace Vapour.Effects.BasicRandomWalk;

using Vapour.Effects;


public class BasicRandomWalkEffect : EffectExecutive<bool, BasicRandomWalkMatrix>
{
    public BasicRandomWalkEffect(int size) :
        base(
            matrix: new BasicRandomWalkMatrix(size),
            layer: new PixelLayer() {
                vertex_chunk_size = 4
            }
        )
    {}

    public override void OnLoad()
    {
        this.matrix.OnLoad();

        var (vertices, indices) = this.matrix.GeneratePixels();
        this.layer.vertices = vertices;
        this.layer.indices = indices;
        this.layer.OnLoad();
    }

    public override void Update()
    {
        var walker = this.matrix.walker;
        // walker.Update();
        // this.matrix[walker.xy] = true;

        base.Update();
    }
}

namespace Vapour.Effects;

using Vapour.Effects;


public class BasicRandomWalkEffect : EffectExecutive<bool>
{
    public BasicRandomWalkEffect(int size) : base()
    {
        matrix = new BasicRandomWalkMatrix(size);
        layer = new PixelLayer();
    }

    public override void OnLoad()
    {
    }

    public override void Update()
    {
        this.matrix.Update();
    
        var (vertices, indices) = this.matrix.UpdatePixels();
        this.layer.vertices = vertices;
        this.layer.indices = indices;
    }
}

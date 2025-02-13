namespace Vapour.Effects;


/// A wrapper that handles an `EffectMatrix`, its effect processors (`Walker`), and its linked `PixelLayer`.
public abstract class EffectExecutive<T>
{
    public required EffectMatrix<T> matrix;
    public required PixelLayer layer;

    public virtual void OnLoad() {}
    
    public virtual void Update() {}
}

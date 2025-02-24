namespace Vapour.Effects;


/// <summary>
/// A wrapper that handles an <c>EffectMatrix</c>, its effect processors (<c>Walker</c>), and its linked <c>PixelLayer</c>.
/// </summary>
/// <typeparam name="T">The type of data stored in each pixel.</typeparam>
/// <typeparam name="TMatrix">The subclass of <c>EffectMatrix</c> used by the effect.</typeparam>
public abstract class EffectExecutive<T, TMatrix> where TMatrix : EffectMatrix<T>
{
    public TMatrix matrix;
    public PixelLayer layer;

    public EffectExecutive(TMatrix matrix, PixelLayer layer)
    {
        this.matrix = matrix;
        this.layer = layer;
    }

    /// <summary>
    /// Access the value of a single pixel in the matrix. Modifications will automatically be synced with the effect's <c>.layer.vertices</c>.
    /// </summary>
    public T this[int x, int y]
    {
        get => this.matrix[x, y];
        set {
            this.matrix[x, y] = value;
            this.layer.vertices[(y * this.matrix.width + x) * this.matrix.vertex_chunk_size + 3] = Convert.ToSingle(value);
        }
    }

    public T this[(int x, int y) index]
    {
        get => this.matrix[index];
        set => this[index.x, index.y] = value;
    }

    public virtual void OnLoad() {}
    
    public virtual void Update()
    {
        this.layer.OnRenderFrame();
    }
}

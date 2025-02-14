namespace Vapour.Effects;


/// <summary>
/// A matrix of pixels for tracking effects.
/// </summary>
public class EffectMatrix<T>
{
    #region FIELDS

    /// Pixels in the matrix, where each pixel stores a colour.
    public T[,] pixels;

    public readonly int width;
    public readonly int height;

    /// Number of points for each vertex in the vertex array. Defaults to 4 for (x, y, z, brightness).
    public int vertex_chunk_size { get; init; } = 4;

    public (int, int) centre {
        get => (this.width / 2, this.height / 2);
        // precise centre doesn't really matter (especially at large sizes) so we won't bother dealing with offsets
    }

    #endregion

    #region CORE

    public EffectMatrix(int width, int height)
    {
        this.width = width;
        this.height = height;
        this.pixels = new T[this.width, this.height];
    }

    public EffectMatrix(int size) : this(size, size)
    {}

    public EffectMatrix(params int[] size) : this(size[0], size[1])
    {}

    public T this[int x, int y]
    {
        get => this.pixels[x, y];
        set => this.pixels[x, y] = value;
    }

    public T this[(int x, int y) index]
    {
        get => this.pixels[index.x, index.y];
        set => this.pixels[index.x, index.y] = value;
    }

    #endregion

    #region METHODS

    public virtual void OnLoad() {}

    public virtual void Update() {}

    /// Generate the arrays of vertices and indices for rendering the pixel matrix.
    public (float[] vertices, uint[] indices) GeneratePixels(float[]? init_value = null)
    {
        int area, len;
        int chunk, stride, offset;

        // generate vertices
        area = (this.width +1) * (this.height +1);
        len = area * this.vertex_chunk_size;
        var vertices = new float[len];

        float frac_x, frac_y;

        for (int i = 0; i <= this.width; i++)
        {
            frac_x = (float) i / this.width;

            // starting index for current column
            chunk = this.width * this.vertex_chunk_size;
            offset = i * chunk;

            for (int j = 0; j <= this.height; j++)
            {
                frac_y = (float) j / this.height;

                stride = j * this.vertex_chunk_size;

                vertices[offset + stride]    = frac_x;
                vertices[offset + stride +1] = frac_y;
                vertices[offset + stride +2] = 0f;

                if (init_value == null) {
                    vertices[offset + stride +3] = 0f;  // start as no colour
                }
                else {
                    for (int k = 0; k < this.vertex_chunk_size; k++) {
                        vertices[offset + stride +3 +k] = init_value[k];
                    }
                }
            }
        }

        // generate indices
        area = this.width * this.height;
        len = area * 6;
        var indices = new uint[len];

        for (int i = 0; i < this.width; i++)
        {
            // 2 triangles per pixel
            chunk = this.height * 3 * 2;
            offset = i * chunk;
            
            for (int j = 0; j < this.height; j++)
            {
                stride = j * 3 * 2;

                // upper-left triangle
                indices[offset + stride   ] = (uint)( (this.height +1) *  i    +j   );
                indices[offset + stride +1] = (uint)( (this.height +1) *  i    +j +1);
                indices[offset + stride +2] = (uint)( (this.height +1) * (i+1) +j +1);

                // lower-right triangle
                indices[offset + stride +3] = (uint)( (this.height +1) *  i    +j   );
                indices[offset + stride +4] = (uint)( (this.height +1) * (i+1) +j   );
                indices[offset + stride +5] = (uint)( (this.height +1) * (i+1) +j +1);
            }
        }

        return (vertices, indices);
    }

    // TODO
    public (float[] vertices, uint[] indices) UpdatePixels()
    {
        return (vertices: new float[0], indices: new uint[0]);
    }

    #endregion
}

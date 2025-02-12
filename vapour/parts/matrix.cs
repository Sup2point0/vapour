/// <summary>
/// A matrix of pixels for rendering effects.
/// </summary>
public class EffectMatrix<T>
{
    #region FIELDS

    public T[,] pixels;

    public readonly int width;
    public readonly int height;

    public Layer? layer;

    /// Number of points for each vertex in the vertex array. Defaults to 4 for (x, y, z, brightness).
    public required vertex_chunk_size = 4;

    public (int, int) centre {
        get => (this.width / 2, this.height / 2);
        // precise centre doesn't really matter (especially at large sizes) so we won't bother dealing with offsets
    }

    #endregion

    #region CORE

    public EffectMatrix(int size)
        => this.Init(size, size);

    public EffectMatrix(int width, int height)
        => this.Init(width, height);

    public EffectMatrix(params int[] size)
    {
        this.Init(size, size);
    }

    protected void Init(int width, int height)
    {
        this.width = width;
        this.height = height;
        this.pixels = new T[width, height];
    }

    public T this[(int x, int y) index]
        => this.pixels[x, y];

    public T this[int x, int y]
        => this.pixels[x, y];

    #endregion

    #region METHODS

    public virtual void OnLoad()
    {
        this.layer = new PixelLayer();

        var (vertices, indices) = GeneratePixels();
        this.layer.vertices = vertices;
        this.layer.indices = indices;

    }

    /// Generate the arrays of vertices and indices for rendering the pixel matrix.
    protected (float[] vertices, uint[] indices)
        GeneratePixels(float[]? init_value = null)
    {
        int area, len;
        int chunk, offset, stride;

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

                if (!this.init_value) {
                    vertices[offset + stride +3] = 0f;  // start as no colour
                }
                else {
                    for (int k = 0; k < this.vertex_chunk_size; k++) {
                        vertices[offset + stride +3 +k] = this.init_value[k];
                    }
                }
            }
        }

        // generate indices
        int next_offset;

        area = this.width * this.height;
        len = area * 6;
        var indices = uint[len];

        for (int i = 0; i < this.width; i++)
        {
            // 2 triangles per pixel
            chunk = this.width * 6;
            offset = i * chunk;
            next_offset = (i+1) * chunk;
            
            for (int j = 0; j < this.height; j++)
            {
                stride = j * 6;

                // upper-left triangle
                indices[offset + stride]    = offset +j;
                indices[offset + stride +1] = offset +j +1;
                indices[offset + stride +2] = next_offset +j +1;

                // lower-right triangle
                indices[offset + stride +3] = offset +j;
                indices[offset + stride +4] = next_offset +j;
                indices[offset + stride +5] = next_offset +j +1;
            }
        }

        return (vertices: vertices, indices: indices);
    }

    #endregion
}

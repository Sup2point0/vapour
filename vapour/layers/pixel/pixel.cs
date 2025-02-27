using OpenTK.Graphics.OpenGL4;


public class PixelLayer : Layer
{
    /// <summary>
    /// How many values are associated with each vertex.
    /// Set to 7 for <c>(x, y, z, r, g, b, a)</c>.
    /// </summary>
    public static readonly int vertex_chunk_size = 7;

    public override void OnLoad()
    {
        base.OnLoad();

        this.vbo = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
        GL.BufferData(
            BufferTarget.ArrayBuffer,
            size: this.vertices.Length * sizeof(float),
            data: this.vertices,
            BufferUsageHint.DynamicDraw
        );

        this.ebo = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ElementArrayBuffer, ebo);
        GL.BufferData(
            BufferTarget.ElementArrayBuffer,
            size: this.indices.Length * sizeof(uint),
            data: this.indices,
            BufferUsageHint.DynamicDraw
        );

        this.shader = new Shader(
            vertex: "layers/pixel/shader.vert.glsl",
            frag: "layers/pixel/shader.frag.glsl");
        this.shader.Use();

        // cords
        GL.EnableVertexAttribArray(2);
        GL.VertexAttribPointer(
            index: 2,
            size: 3,
            VertexAttribPointerType.Float,
            normalized: false,
            stride: sizeof(float) * PixelLayer.vertex_chunk_size,
            offset: 0
        );

        // col
        GL.EnableVertexAttribArray(3);
        GL.VertexAttribPointer(
            index: 3,
            size: 4,
            VertexAttribPointerType.Float,
            normalized: false,
            stride: sizeof(float) * PixelLayer.vertex_chunk_size,
            offset: sizeof(float) * 3
        );
    }

    public override void OnRenderFrame()
    {
        base.OnRenderFrame();

        GL.DrawElements(PrimitiveType.Triangles, this.indices.Length, DrawElementsType.UnsignedInt, 0);
    }
}

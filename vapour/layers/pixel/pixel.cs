using OpenTK.Graphics.OpenGL4;


public class PixelLayer : Layer
{
    public int vertex_chunk_size { get; init; } = 3;

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

        GL.EnableVertexAttribArray(2);
        GL.VertexAttribPointer(
            index: 2,
            size: 3,
            VertexAttribPointerType.Float,
            normalized: false,
            stride: this.vertex_chunk_size * sizeof(float),
            offset: 0
        );

        GL.EnableVertexAttribArray(3);
        GL.VertexAttribPointer(
            index: 3,
            size: this.vertex_chunk_size - 3,
            VertexAttribPointerType.Float,
            normalized: false,
            stride: this.vertex_chunk_size * sizeof(float),
            offset: 3
        );
    }

    public override void OnRenderFrame()
    {
        base.OnRenderFrame();

        GL.DrawElements(PrimitiveType.Triangles, this.indices.Length, DrawElementsType.UnsignedInt, 0);
    }
}

using OpenTK.Graphics.OpenGL4;


public class PixelLayer : Layer
{
    public PixelLayer() : base(
        vertices: [
            -1.0f, -1.0f, 0f,
            -1.0f, -0.9f, 0f,
            -0.9f, -0.9f, 0f,
            -0.9f, -1.0f, 0f,
            -0.9f, -0.9f, 0f,
            -0.9f, -0.8f, 0f,
            -0.8f, -0.8f, 0f,
            -0.8f, -0.9f, 0f,
            -0.1f, -0.1f, 0f,
            -0.1f, -0.2f, 0f,
            -0.2f, -0.2f, 0f,
            -0.2f, -0.1f, 0f,
            0.1f, 0.1f, 0f,
            0.1f, 0.2f, 0f,
            0.2f, 0.2f, 0f,
            0.2f, 0.1f, 0f,
        ],
        indices: [
            0, 1, 2,
            2, 0, 3,
            4, 5, 6,
            6, 4, 7,
            8, 9, 10,
            10, 8, 11,
            12, 13, 14,
            14, 12, 15,
        ]
    )
    {}

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
            stride: 3 * sizeof(float),
            offset: 0
        );
    }

    public override void OnRenderFrame()
    {
        base.OnRenderFrame();

        GL.DrawElements(PrimitiveType.Triangles, this.indices.Length, DrawElementsType.UnsignedInt, 0);
    }
}

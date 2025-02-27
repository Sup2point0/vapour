using OpenTK.Graphics.OpenGL4;


public class TextureLayer : Layer
{
    public string texture_path;
    public Texture? texture;

    public TextureLayer(string texture_path)
    {
        this.texture_path = texture_path;
    }

    public override void OnLoad()
    {
        base.OnLoad();

        this.vbo = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
        GL.BufferData(
            BufferTarget.ArrayBuffer,
            size: this.vertices.Length * sizeof(float),
            data: this.vertices,
            BufferUsageHint.StaticDraw
        );
        
        this.ebo = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ElementArrayBuffer, ebo);
        GL.BufferData(
            BufferTarget.ElementArrayBuffer,
            size: this.indices.Length * sizeof(uint),
            data: this.indices,
            BufferUsageHint.StaticDraw
        );

        this.shader = new Shader(
            vertex: "layers/texture/shader.vert.glsl",
            frag: "layers/texture/shader.frag.glsl");
        this.shader.Use();

        GL.EnableVertexAttribArray(0);
        GL.VertexAttribPointer(
            index: 0,
            size: 3,
            VertexAttribPointerType.Float,
            normalized: false,
            stride: 5 * sizeof(float),
            offset: 0
        );

        this.texture = new Texture(this.texture_path);
        this.texture.Use();

        GL.EnableVertexAttribArray(1);
        GL.VertexAttribPointer(
            index: 1,
            size: 2,
            VertexAttribPointerType.Float,
            normalized: false,
            stride: 5 * sizeof(float),
            offset: 3 * sizeof(float)
        );
    }

    public override void OnRenderFrame()
    {
        base.OnRenderFrame();

        this.texture?.Use();

        GL.DrawElements(PrimitiveType.Triangles, this.indices.Length, DrawElementsType.UnsignedInt, 0);
    }
}

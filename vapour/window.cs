using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;


class Window : GameWindow
{
    #region ATTRIBUTES

    private Shader? shader;
    private Texture? texture;

    private int vbo;  // vertex buffer object
    private int vao;  // vertex array object
    private int ebo;  // element buffer object

    public float[] vertices = [];
    public uint[] indices = [];

    #endregion

    #region CORE

    public Window(
        int width,
        int height
    ) :
        base(
            GameWindowSettings.Default,
            new NativeWindowSettings() {
                ClientSize = (width, height),
                Title = "vapour",
            }
        )
    {
    }

    #endregion

    #region OVERRIDE

    protected override void OnLoad()
    {
        base.OnLoad();

        vao = GL.GenVertexArray();
        GL.BindVertexArray(vao);

        vbo = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
        GL.BufferData(
            BufferTarget.ArrayBuffer,
            size: vertices.Length * sizeof(float),
            data: vertices,
            BufferUsageHint.StaticDraw
        );
        
        ebo = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ElementArrayBuffer, ebo);
        GL.BufferData(
            BufferTarget.ElementArrayBuffer,
            size: indices.Length * sizeof(uint),
            data: indices,
            BufferUsageHint.StaticDraw
        );

        shader = new Shader("shaders/shader.vert.glsl", "shaders/shader.frag.glsl");
        shader.Use();

        GL.EnableVertexAttribArray(0);
        GL.VertexAttribPointer(
            index: 0,
            size: 3,
            VertexAttribPointerType.Float,
            normalized: false,
            stride: 5 * sizeof(float),
            offset: 0
        );

        texture = new Texture("../.assets/terabyte.png");
        texture.Use();

        GL.EnableVertexAttribArray(1);
        GL.VertexAttribPointer(
            index: 1,
            size: 2,
            VertexAttribPointerType.Float,
            normalized: false,
            5 * sizeof(float),
            3 * sizeof(float)
        );

        GL.ClearColor(0.03584f, 0.0922f, 0.24582f, 1.0f);
    }

    protected override void OnRenderFrame(FrameEventArgs e)
    {
        base.OnRenderFrame(e);

        GL.Clear(ClearBufferMask.ColorBufferBit);

        GL.BindVertexArray(vao);

        shader?.Use();
        texture?.Use();
        
        // GL.DrawArrays(PrimitiveType.Triangles, 0, vertices.Length / 3);
        GL.DrawElements(PrimitiveType.Triangles, indices.Length, DrawElementsType.UnsignedInt, 0);

        SwapBuffers();
    }

    protected override void OnFramebufferResize(FramebufferResizeEventArgs e)
    {
        base.OnFramebufferResize(e);

        GL.Viewport(0, 0, e.Width, e.Height);
    }

    protected override void OnUpdateFrame(FrameEventArgs e)
    {
        base.OnUpdateFrame(e);

        if (KeyboardState.IsKeyDown(Keys.Escape)) {
            Close();
        }
    }

    protected override void OnUnload()
    {
        base.OnUnload();

        shader?.Dispose();
    }

    #endregion
}

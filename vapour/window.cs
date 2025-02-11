using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

using Vapour.Colours;


class Window : GameWindow
{
    #region ATTRIBUTES

    Shader? shader;

    int vbo;  // vertex buffer object
    int vao;  // vertex array object
    int ebo;  // element buffer object

    float[] vertices = [];
    uint[] indices = [];

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
        
        ebo = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ElementArrayBuffer, ebo);

        GL.BufferData(
            BufferTarget.ArrayBuffer,
            size: vertices.Length * sizeof(float),
            data: vertices,
            BufferUsageHint.StaticDraw
        );
        GL.BufferData(
            BufferTarget.ElementArrayBuffer,
            size: vertices.Length * sizeof(uint),
            data: indices,
            BufferUsageHint.StaticDraw
        );
        GL.VertexAttribPointer(
            index: 0,
            size: 3,
            VertexAttribPointerType.Float,
            normalized: false,
            stride: 0,
            offset: 0
        );
        GL.EnableVertexAttribArray(0);
        

        shader = new Shader("shaders/shader.vert", "shaders/shader.frag");

        GL.ClearColor(0.25f, 0.5f, 1f, 1.0f);
    }

    protected override void OnRenderFrame(FrameEventArgs e)
    {
        base.OnRenderFrame(e);

        shader?.Use();
        GL.BindVertexArray(vao);
        
        GL.Clear(ClearBufferMask.ColorBufferBit);
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

    #region METHODS

    public void AddVertices(float[] vertices)
    {
        this.vertices = vertices;
    }

    public void AddIndexedVertices(float[] vertices, uint[] indices)
    {
        AddVertices(vertices);
        this.indices = indices;
    }

    #endregion
}

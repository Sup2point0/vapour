using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

using Vapour.Colours;


class Window : GameWindow
{
    #region ATTRIBUTES

    int VertexBufferObject;

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

        VertexBufferObject = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObject);

        GL.ClearColor(0, 0, 0, 1.0f);
    }

    protected override void OnRenderFrame(FrameEventArgs e)
    {
        base.OnRenderFrame(e);

        GL.Clear(ClearBufferMask.ColorBufferBit);

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

    #endregion
}

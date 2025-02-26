namespace Vapour;

using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

using Vapour.Effects;


class Window : GameWindow
{
    #region ATTRIBUTES

    public required Layer pict;

    /// <summary>
    /// A series of effects to apply on top of the picture.
    /// </summary>
    public required EffectExecutive[] effects;

    #endregion

    #region CORE

    public Window(int width, int height) :
        base(
            GameWindowSettings.Default,
            new NativeWindowSettings() {
                ClientSize = (width, height),
                Title = "vapour",
            }
        )
    {}

    #endregion

    #region OVERRIDE

    protected override void OnLoad()
    {
        base.OnLoad();

        GL.Enable(EnableCap.Blend);
        GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

        pict.OnLoad();
        foreach (var effect in effects) {
            effect.OnLoad();
        }

        GL.ClearColor(0.03584f, 0.0922f, 0.24582f, 1.0f);
    }

    protected override void OnRenderFrame(FrameEventArgs e)
    {
        base.OnRenderFrame(e);

        GL.Clear(ClearBufferMask.ColorBufferBit);

        pict.OnRenderFrame();
        foreach (var effect in effects) {
            effect.Update();
        }

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

        pict.shader?.Dispose();
        foreach (var effect in effects) {
            effect.layer.shader?.Dispose();
        }
    }

    #endregion
}

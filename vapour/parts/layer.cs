using OpenTK.Graphics.OpenGL4;


public class Layer
{
    public float[] vertices = [];
    public uint[] indices = [];

    public int vao;
    public int vbo;
    public int ebo;

    public Shader? shader;
    
    public Layer(float[] vertices, uint[] indices)
    {
        this.vertices = vertices;
        this.indices = indices;
    }

    /// <summary>
    /// Initialise the layer by calling relevant OpenGL functions. Call from `OpenTK.GameWindow.OnLoad()`.
    /// </summary>
    public virtual void OnLoad()
    {
        this.vao = GL.GenVertexArray();
        GL.BindVertexArray(this.vao);
    }

    public virtual void OnRenderFrame()
    {
        shader?.Use();
        GL.BindVertexArray(this.vao);
    }
}

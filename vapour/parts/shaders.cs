using OpenTK.Graphics.OpenGL4;


public class Shader
{
    public int handle;
    
    private bool is_disposed = false;

    public Shader(string vertex, string frag)
    {
        string vertex_shader_source = File.ReadAllText(vertex);
        string frag_shader_source = File.ReadAllText(frag);

        var vertex_shader = GL.CreateShader(ShaderType.VertexShader);
        var frag_shader = GL.CreateShader(ShaderType.FragmentShader);

        GL.ShaderSource(vertex_shader, vertex_shader_source);
        GL.ShaderSource(frag_shader, frag_shader_source);
        GL.CompileShader(vertex_shader);
        GL.CompileShader(frag_shader);

        handle = GL.CreateProgram();
        GL.AttachShader(handle, vertex_shader);
        GL.AttachShader(handle, frag_shader);
        GL.LinkProgram(handle);

        GL.DetachShader(handle, vertex_shader);
        GL.DetachShader(handle, frag_shader);
        GL.DeleteShader(vertex_shader);
        GL.DeleteShader(frag_shader);
    }

    public void Use()
    {
        GL.UseProgram(handle);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!is_disposed) {
            GL.DeleteProgram(handle);
            is_disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    ~Shader()
    {
        if (is_disposed == false) {
            Console.Error.WriteLine("RESOURCE LEAK: Did you forget to call `.Dispose()` on `Shader`?");
        }
    }
}

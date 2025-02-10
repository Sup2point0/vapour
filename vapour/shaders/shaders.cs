using OpenTK.Graphics.OpenGL4;


public class Shader
{
    int handle;

    public Shader(string vertex_path, string frag_path)
    {
        string vertex_shader_source = File.ReadAllText(vertex_path);
        string frag_shader_source = File.ReadAllText(frag_path);

        var vertex_shader = GL.CreateShader(ShaderType.VertexShader);
        var frag_shader = GL.CreateShader(ShaderType.FragmentShader);

        GL.ShaderSource(vertex_shader, vertex_shader_source);
        GL.ShaderSource(frag_shader, frag_shader_source);

        GL.CompileShader(vertex_shader);
        GL.GetShader(vertex_shader, ShaderParameter.CompileStatus, out int success);
        if (success == 0) {
            Console.WriteLine(GL.GetShaderInfoLog(frag_shader));
        }

        handle = GL.CreateProgram();

        GL.AttachShader(handle, vertex_shader);
        GL.AttachShader(handle, frag_shader);

        GL.LinkProgram(handle);
        GL.GetProgram(handle, GetProgramParameterName.LinkStatus, out int sucess);
        if (success == 0) {
            Console.WriteLine(GL.GetProgramInfoLog(handle));
        }

        GL.DetachShader(handle, vertex_shader);
        GL.DetachShader(handle, frag_shader);
        GL.DeleteShader(vertex_shader);
        GL.DeleteShader(frag_shader);
    }

    public void Use()
    {
        GL.UseProgram(handle);
    }
}

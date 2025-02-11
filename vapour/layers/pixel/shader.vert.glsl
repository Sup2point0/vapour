// Vertex Shader
#version 330 core

layout (location = 2) in vec3 pos_cord;


void main()
{
    gl_Position = vec4(pos_cord, 1.0);
}

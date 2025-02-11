// Vertex Texture Shader
#version 330 core

layout (location = 0) in vec3 pos_cord;
layout (location = 1) in vec2 tex_cord;

out vec2 tex_cord_forwarded;


void main()
{
    gl_Position = vec4(pos_cord, 1.0);
    tex_cord_forwarded = tex_cord;
}

// Vertex Shader
#version 330 core

layout (location = 2) in vec3 pos_cord;
layout (location = 3) in vec4 col;

out vec4 col_forwarded;


void main()
{
    gl_Position = vec4(pos_cord, 1.0);
    col_forwarded = col;
}

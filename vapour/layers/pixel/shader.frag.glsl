// Fragment Shader
#version 330 core

in vec4 col_forwarded;

out vec4 col;


void main()
{
    col = col_forwarded;
}

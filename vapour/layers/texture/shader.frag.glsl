// Fragment Texture Shader
#version 330 core

in vec2 tex_cord_forwarded;

out vec4 col;

uniform sampler2D texture0;


void main()
{
    col = texture(texture0, tex_cord_forwarded);
}

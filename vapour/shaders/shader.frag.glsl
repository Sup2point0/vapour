#version 330 core
// Fragment Shader

in vec2 tex_cord_forwarded;

out vec4 col;

uniform sampler2D texture0;


void main()
{
    // col = vec4(1.0f, 0, 0.2f, 1.0f);
    col = texture(texture0, tex_cord_forwarded);
}

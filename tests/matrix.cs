namespace Tests;

using Vapour.Effects;


[TestClass]
public class Test_EffectMatrix
{
    [TestMethod]
    public void Test_Init()
    {
        var matrix = new EffectMatrix<int>(3, 3);

        Assert.IsTrue(matrix.width == 3);
        Assert.IsTrue(matrix.height == 3);
        Assert.IsTrue(matrix.centre == (2, 2));

        matrix = newEffectMatrix<int>(4) {
            vertex_chunk_size = 5;
        }
        Assert.IsTrue(matrix.width == 4);
        Assert.IsTrue(matrix.height == 4);
        Assert.IsTrue(matrix.centre == (2, 2));
        Assert.IsTrue(matrix.vertex_chunk_size == 5);
    }

    [TestMethod]
    public void Test_GenerateVertices()
    {
        // test expected for 3x3 pixel matrix
        EffectMatrix<bool> m = new(3);

        // if it works for 3x3, it should generalise to NxN
        var (vertices, indices) = m.GeneratePixels();

        Assert.IsTrue( vertices.Length == 4 * 4 );
        Assert.IsTrue( vertices[0..4] == [-1f, -1f, 0f, 0f] );
        Assert.IsTrue( vertices[^4..^1] == [1f, 1f, 0f, 0f] );

        Assert.IsTrue( indices.Length == 3 * 3 * 6 );

        // left column
        Assert.IsTrue( indices[0..3] == [0, 1, 4] );
        Assert.IsTrue( indices[3..6] == [0, 2, 4] );
        Assert.IsTrue( indices[6..9] == [1, 2, 5] );
        Assert.IsTrue( indices[9..12] == [1, 4, 5] );
        Assert.IsTrue( indices[12..15] == [2, 3, 6] );
        Assert.IsTrue( indices[15..18] == [2, 5, 6] );

        // middle column

        // right column
    }
}

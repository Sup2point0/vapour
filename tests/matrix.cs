namespace Tests;

using Vapour.Effects;


[TestClass]
public class Test_EffectMatrix
{
    [TestMethod]
    public void Test_Init()
    {
        EffectMatrix<int> matrix;
        
        matrix = new(3, 3);
        Assert.IsTrue(matrix.width == 3);
        Assert.IsTrue(matrix.height == 3);

        matrix = new(4) {
            vertex_chunk_size = 5
        };
        Assert.IsTrue(matrix.width == 4);
        Assert.IsTrue(matrix.height == 4);
        Assert.IsTrue(matrix.centre == (2, 2));
        Assert.IsTrue(matrix.vertex_chunk_size == 5);
    }

    // test expected for 3x3 pixel matrix
    // if it works for 3x3, it should generalise to NxN
    [TestMethod]
    public void Test_GenerateVertices()
    {
        EffectMatrix<bool> m = new(3);

        var (vertices, indices) = m.GeneratePixels();
        // Console.WriteLine("vertices =");
        // foreach (var each in vertices) {
        //     Console.Write(each);
        //     Console.Write(", ");
        // }

        Assert.IsTrue( vertices.Length == 4 * 4 );
        Assert.IsTrue( vertices[0..4]   == new float[] { -1f, -1f, 0f, 0f } );
        Assert.IsTrue( vertices[^4..^1] == new float[] { 1f, 1f, 0f, 0f } );

        // left column

        // middle column

        // right column
    }
    [TestMethod]
    public void Test_GenerateIndices()
    {
        EffectMatrix<bool> m = new(3);

        var (vertices, indices) = m.GeneratePixels();
        Console.WriteLine("indices =");
        int i = 0;
        foreach (var each in indices[0..3]) {
            if (i % 3 == 0) {
                Console.Write("\n");
            }
            Console.Write(each);
            Console.Write(", ");
            i++;
        }

        Assert.IsTrue( indices.Length == 3 * 3 * 6 );

        // left column
        Assert.IsTrue( indices[ 0.. 3].SequenceEqual(new uint[] {0, 1, 5} ));
        Assert.IsTrue( indices[ 3.. 6].SequenceEqual(new uint[] {0, 4, 5} ));
        Assert.IsTrue( indices[ 6.. 9].SequenceEqual(new uint[] {1, 2, 6} ));
        Assert.IsTrue( indices[ 9..12].SequenceEqual(new uint[] {1, 5, 6} ));
        Assert.IsTrue( indices[12..15].SequenceEqual(new uint[] {2, 3, 7} ));
        Assert.IsTrue( indices[15..18].SequenceEqual(new uint[] {2, 6, 7} ));

        // middle column
        Assert.IsTrue( indices[18..21].SequenceEqual(new uint[] {4, 5, 9} ));
        Assert.IsTrue( indices[21..24].SequenceEqual(new uint[] {4, 8, 9} ));
        Assert.IsTrue( indices[24..27].SequenceEqual(new uint[] {5, 6, 10} ));
        Assert.IsTrue( indices[27..30].SequenceEqual(new uint[] {5, 9, 10} ));
        Assert.IsTrue( indices[30..33].SequenceEqual(new uint[] {6, 7, 11} ));
        Assert.IsTrue( indices[33..36].SequenceEqual(new uint[] {6, 10, 11} ));

        // right column
        Assert.IsTrue( indices[36..39].SequenceEqual(new uint[] {8, 9, 13} ));
        Assert.IsTrue( indices[39..42].SequenceEqual(new uint[] {8, 12, 13} ));
        Assert.IsTrue( indices[42..45].SequenceEqual(new uint[] {9, 10, 14} ));
        Assert.IsTrue( indices[45..48].SequenceEqual(new uint[] {9, 13, 14} ));
        Assert.IsTrue( indices[48..51].SequenceEqual(new uint[] {10, 11, 15} ));
        Assert.IsTrue( indices[51..54].SequenceEqual(new uint[] {10, 14, 15} ));
    }
}

namespace Tests;


[TestClass]
public class TestRandom
{
    [TestMethod]
    public void TestBinary()
    {
        Assert.IsTrue(Vapour.Utils.Rand.Binary() == 0 || Vapour.Utils.Rand.Binary() == 1);
    }

    [TestMethod]
    public void TestDirection()
    {
        Assert.IsTrue(Vapour.Utils.Rand.Direction() == -1 || Vapour.Utils.Rand.Direction() == 1);
    }
}

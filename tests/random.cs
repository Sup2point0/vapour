namespace Tests;


[TestClass]
public class Test_Random
{
    [TestMethod]
    public void Test_Binary()
    {
        Assert.IsTrue(Vapour.Utils.Rand.Binary() == 0 || Vapour.Utils.Rand.Binary() == 1);
    }

    [TestMethod]
    public void Test_Direction()
    {
        Assert.IsTrue(Vapour.Utils.Rand.Direction() == -1 || Vapour.Utils.Rand.Direction() == 1);
    }
}

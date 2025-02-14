namespace Tests;

using Vapour.Utils;


[TestClass]
public class Test_Random
{
    [TestMethod]
    public void Test_Binary()
    {
        var t = Rand.Binary();
        Assert.IsTrue(t == 0 || t == 1);
    }

    [TestMethod]
    public void Test_Direction()
    {
        var t = Rand.Direction();
        Assert.IsTrue(t == -1 || t == 1);
    }
}

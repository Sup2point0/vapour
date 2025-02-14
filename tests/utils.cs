namespace Tests;

using Vapour.Utils;


[TestClass]
public class Test_Prox
{
    [TestMethod]
    public void Test_Close()
    {
        Assert.IsTrue(Prox.IsClose(1f / 3, 0.33333f));

        float[] l1 = { 0.0f, 1.0f, -1.0f, 1f / 3 };
        float[] l2 = { 1.0f - 1.0f, 0.5f + 0.5f, 1.0f - 2.0f, 0.333333f };
        Assert.IsTrue(Prox.AreClose(l1, l2));
    }
}


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

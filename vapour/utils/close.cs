namespace Vapour.Utils;


public static class Prox
{
    public static bool IsClose(float x, float y)
        => (Math.Abs(x - y) < 0.001);

    public static bool AreClose(float[] prot, float[] deut)
    {
        if (prot.Length != deut.Length) {
            return false;
        }

        for (int i = 0; i < prot.Length; i++) {
            if (!IsClose(prot[i], deut[i])) {
                return false;
            }
        }

        return true;
    }
}

using UnityEngine;

public class MathParabola : MonoBehaviour
{
    public static Vector3 Parabola(Vector3 start, Vector3 end, float height, float t)
    {
        var mid = Vector3.Lerp(start, end, t);

        return new Vector3(mid.x, ParabolicFormula(t, height) + Mathf.Lerp(start.y, end.y, t), mid.z);
    }

    private static float ParabolicFormula(float x, float height)
    {
        return -4 * height * x * x + (4 * height * x);
    }
}

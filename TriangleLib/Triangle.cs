namespace TriangleLib;

public struct Triangle
{
    public enum TriangleType
    {
        Acute,
        Right,
        Obtuse,
        Invalid
    }

    public static TriangleType GetTriangleType(double sideA, double sideB, double sideC)
    {
        if (sideA <= 0 || sideB <= 0 || sideC <= 0 || sideA + sideB <= sideC || sideA + sideC <= sideB || sideB + sideC <= sideA)
            return TriangleType.Invalid;

        var maxSide = Math.Max(sideA, Math.Max(sideB, sideC));
        double otherSide1, otherSide2;

        if (maxSide == sideA) 
        {
            otherSide1 = sideB;
            otherSide2 = sideC;
        } 
        else if (maxSide == sideB) 
        {
            otherSide1 = sideA;
            otherSide2 = sideC;
        } 
        else
        {
            otherSide1 = sideA;
            otherSide2 = sideB;
        }

        var result = otherSide1 * otherSide1 + otherSide2 * otherSide2 - maxSide * maxSide;

        return result switch
        {
            0 => TriangleType.Right,
            > 0 => TriangleType.Acute,
            _ => TriangleType.Obtuse
        };
    }
}
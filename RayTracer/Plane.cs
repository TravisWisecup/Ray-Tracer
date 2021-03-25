public class Plane
{
    public double A { get; set; }
    public double B { get; set; }
    public double C { get; set; }
    public double D { get; set; }

    public Plane(double A, double B, double C, double D)
    {
        this.A = A;
        this.B = B;
        this.C = C;
        this.D = D;
    }

    public static Plane fromABCD(double A, double B, double C, double D)
    {
        return new Plane(A, B, C, D);
    }
    public static Plane fromABC(double A, double B, double C, Vector3 v3)
    {
        double D = -A * v3.x - B * v3.y - C * v3.z;
        return new Plane(A, B, C, D);
    }

    public Plane fromThreeVectors(Vector3 v1, Vector3 v2, Vector3 v3)
    {
        var deltaOne = Vector3.minus(v2, v1).normalize();
        var deltaTwo = Vector3.minus(v3, v1).normalize();
        var cross = Vector3.cross(deltaOne, deltaTwo).normalize();

        var A = cross.x;
        var B = cross.y;
        var C = cross.z;

        return fromABC(A, B, C, v1);
    }
}
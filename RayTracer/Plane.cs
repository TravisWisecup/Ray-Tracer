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

    public Plane fromABCD(double A, double B, double C, double D)
    {
        return new Plane(A, B, C, D);
    }
    public Plane fromABC(double A, double B, double C, Vector3 v3)
    {
        double D = -A * v3.x - B * v3.y - C * v3.z;
        return new Plane(A, B, C, D);
    }

    public Plane fromThreeVectors(Vector3 v1, Vector3 v2, Vector3 v3)
    {
        Vector3 one = v2.minus(v1);
        Vector3 two = v3.minus(v1);
        Vector3 normal = v3.cross(one, two);
        return fromABC(normal.x, normal.y, normal.z, v1);
    }
}
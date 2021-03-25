public class Ray
{
    public Vector3 start;
    public Vector3 end;
    public Vector3 direction { get { Vector3 v3 = new Vector3(0, 0, 0); return Vector3.minus(this.end, this.start); }  }

    public Ray(Vector3 start, Vector3 end)
    {
        this.start = start;
        this.end = end;
    }

    public Ray normalize()
    {
        this.end = Vector3.add(this.start, this.direction.scale(1 / this.length()));
        return this;
    }

    public static Vector3 directionM(Ray ray)
    {
        return ray.direction;
    }

    public double length()
    {
        return this.direction.length();
    }

    public static double length(Ray ray)
    {
        return ray.length();
    }

    public double distanceToPlane(Plane plane)
    {
        return -(plane.A * this.start.x + plane.B * this.start.y + plane.C * this.start.z + plane.D) / (plane.A * this.direction.x + plane.B * this.direction.y + plane.C * this.direction.z);
    }
}
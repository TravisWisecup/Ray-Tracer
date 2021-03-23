using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Vector3
{
    double[] v = new double[3];

    public static Vector3 Zero = new Vector3(0, 0, 0);
    public static Vector3 One = new Vector3(1, 1, 1);
    public static Vector3 positiveX = new Vector3(1, 0, 0);
    public static Vector3 positiveY = new Vector3(0, 1, 0);
    public static Vector3 positiveZ = new Vector3(0, 0, 1);
    public static Vector3 negativeX = new Vector3(-1, 0, 0);
    public static Vector3 negativeY = new Vector3(0, -1, 0);
    public static Vector3 negativeZ = new Vector3(0, 0, -1);

    public Vector3(double x, double y, double z)
    {
        v[0] = x;
        v[1] = y;
        v[2] = z;
    }
    private double _x = 0.0;
    public double x { get { return v[0]; } set { v[0] = value; } }
    public double y { get { return v[1]; } set { v[1] = value; } }
    public double z { get { return v[2]; } set { v[2] = value; } }
    public double r { get { return v[0]; } }
    public double g { get { return v[1]; } }
    public double b { get { return v[2]; } }


    public Vector3 clone()
    {
        return new Vector3(this.x, this.y, this.z);
    }

    public Vector3 clone(double x, double y, double z)
    {
        return new Vector3(x, y, z);
    }

    public double length()
    {
        return Math.Sqrt(v.Sum(a => Math.Pow(a, 2)));
    }

    public void normalize()
    {
        var l = this.length();

        v = v.Select(i => i / l).ToArray();
    }

    public void normalize(Vector3 v3)
    {
        var l = v3.length();
        v3.v = v3.v.Select(i => i / l).ToArray();
    }

    public Vector3 scale(double scalar)
    {
        v = this.v.Select(i => i * scalar).ToArray();
        return this;
    }

    public Vector3 scale(Vector3 v3, double scalar)
    {
        return new Vector3(v3.x, v3.y, v3.z).scale(scalar);
    }

    public Vector3 minus(Vector3 other)
    {
        this.x -= other.x;
        this.y -= other.y;
        this.z -= other.z;

        return this;
    }

    public Vector3 minus(Vector3 one, Vector3 two)
    {
        Vector3 returnV3 = one.clone().minus(two);

        return returnV3;
    }

    public Vector3 add(Vector3 other)
    {
        this.x += other.x;
        this.y += other.y;
        this.z += other.z;

        return this;
    }

    public Vector3 add(Vector3 one, Vector3 two)
    {
        Vector3 returnV3 = one.clone().add(two);
        return returnV3;
    }

    public double dot(Vector3 other)
    {
        return this.x * other.x + this.y * other.y + this.z * other.z;
    }

    public double dot(Vector3 one, Vector3 two)
    {
        return one.x * two.x + one.y * two.y + one.z * two.z;
    }

    public Vector3 cross(Vector3 other)
    {
        var _x = this.y * other.z - this.z * other.y;
        var _y = this.z * other.x - this.x * other.z;
        var _z = this.x * other.y - this.y * other.x;

        this.x = _x;
        this.y = _y;
        this.z = _z;

        return this;
    }

    public Vector3 cross(Vector3 one, Vector3 two)
    {
        Vector3 v3 = one.clone().cross(two);
        return v3;
    }
}

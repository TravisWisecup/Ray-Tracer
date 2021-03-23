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
        var _x = this.y*other.z - this.z*other.y;
        var _y = this.z*other.x - this.x*other.z;
        var _z = this.x*other.y - this.y*other.x;

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

public class Ray
{
    public Vector3 start;
    public Vector3 end;

    public Ray(Vector3 start, Vector3 end)
    {
        this.start = start;
        this.end = end;
    }

    public Ray normalize()
    {
        Vector3 v3 = new Vector3(0,0,0);
        this.end = v3.add(this.start, this.direction().scale(1/this.length()));
        return this;
    }

    public Vector3 direction()
    {
        Vector3 v3 = new Vector3(0, 0, 0);
        return  v3.minus(this.end, this.start);
    }

    public double length()
    {
        return this.direction().length();
    }
}

class Plane
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
class Program
{
    public static void Main()
    {
        try
        {
            string root = @"J:\Spring 2021 Classes\CSCI 4620 Computer Graphics\Ray Tracer\RayTracer";

            var vertices = new List<dynamic>();
            var uvs = new List<dynamic>();
            var normals = new List<dynamic>();
            var faces = new List<dynamic>();

            var objString = "";
            var objSplits = Array.Empty<string>();
            // Open the text file using a stream reader.
            using (var sr = new StreamReader(root + "\\plane.obj"))
            {
                objString = sr.ReadToEnd();
                objSplits = objString.Split("\n");

                foreach(var objLine in objSplits)
                {
                    Console.WriteLine(objLine);
                    if(objLine[0] == 'v')
                    {
                        if (objLine[1] == ' ')
                        {
                            var lineValues = objLine.Split(' ');
                            var vertex = new
                            {
                                x = +float.Parse(lineValues[1]),
                                y = +float.Parse(lineValues[2]),
                                z = +float.Parse(lineValues[3])
                            };
                            vertices.Add(vertex);
                        }
                        if (objLine[1] == 't')
                        {
                            var lineValues = objLine.Split(' ');
                            var uv = new
                            {
                                u = +float.Parse(lineValues[1]),
                                v = +float.Parse(lineValues[2])
                            };
                            uvs.Add(uv);
                        }
                        if (objLine[1] == 'n')
                        {
                            var lineValues = objLine.Split(' ');
                            var normal = new
                            {
                                x = +float.Parse(lineValues[1]),
                                y = +float.Parse(lineValues[2]),
                                z =  +float.Parse(lineValues[3])
                            };
                            normals.Add(normal);
                        }
                    }
                    else if (objLine[0] == 'f')
                    {
                        var lineValues = objLine.Split(' ');
                        var objVertices = new List<dynamic>();
                        for(var i = 1; i < 4; i++)
                        {
                            objVertices.Add(lineValues[i].Split('/'));
                        }
                        var face = new 
                        {
                            vertex = vertices[+int.Parse(objVertices[0][0]) - 1],
                            uvs = uvs[+int.Parse(objVertices[0][1]) - 1],
                            normals = normals[+int.Parse(objVertices[0][2]) - 1]
                        };
                        faces.Add(face);

                    }
                }
                foreach(dynamic a in vertices)
                Console.WriteLine(a.ToString());

                foreach (dynamic a in uvs)
                    Console.WriteLine(a.ToString());

                foreach (dynamic a in normals)
                    Console.WriteLine(a.ToString());

                foreach (dynamic a in faces)
                    Console.WriteLine(a.ToString());
                // Read the stream as a string, and write the string to the console.
                // Console.WriteLine(sr.ReadToEnd());
            }
        }
        catch (IOException e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }
    }
}
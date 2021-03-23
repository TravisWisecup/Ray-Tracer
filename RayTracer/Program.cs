using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
using System.IO;
using System;


class Program
{
    public static void Main()
    {
        string root = @"J:\Spring 2021 Classes\CSCI 4620 Computer Graphics\Ray Tracer\RayTracer";
        try
        {
            // Open the text file using a stream reader.
            using (var sr = new StreamReader("plane.obj"))
            {
                // Read the stream as a string, and write the string to the console.
                Console.WriteLine(sr.ReadToEnd());
            }
        }
        catch (IOException e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }
    }
}
﻿using RayCasting;

namespace ReadATextFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string source = Path.Combine(Environment.CurrentDirectory, @"..\..\..\Images\f-16.obj");

            ObjReader reader = new ObjReader();

            reader.ReadTriangles(source);
        }
    }
}
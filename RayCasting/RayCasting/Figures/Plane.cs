﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RayCasting.Objects;
using RayCasting.Transformations;

namespace RayCasting.Figures;
public class Plane : IIntersectable
{
    public Plane(Point3D point, Vector3D normalVector)
    {
        Point = point;
        NormalVector = normalVector.Normalized();
    }

    //TODO add check if points aren't on the same line
    public Plane(Point3D pointA, Point3D pointB, Point3D pointC)
    {
        Point = pointA;

        Vector3D vecAB = new(pointA, pointB);
        Vector3D vecBC = new(pointB, pointC);
        Vector3D normalVec = vecAB.Cross(vecBC).Normalized();

        NormalVector = normalVec;
    }

    public Point3D Point { get; }

    public Vector3D NormalVector { get; }

    public Point3D? GetIntersectionPoint(Ray3D ray)
    {
        float rayNormalVecDotProduct = ray.Direction.Dot(NormalVector);
        if (Math.Abs(rayNormalVecDotProduct) < 10e-6)
        {
            return null;
        }

        Vector3D planePointRadiusVec = new(Point);
        Vector3D rayOriginRadiusVec = new(ray.Origin);

        float t = (planePointRadiusVec - rayOriginRadiusVec).Dot(NormalVector) / rayNormalVecDotProduct;

        if (t < 0)
        {
            return null;
        }

        Point3D intersectPoint = ray.Origin + ray.Direction * t;
        return intersectPoint;
    }
    public Vector3D GetNormalVector(Point3D point)
    {
        // TODO: consider ray coming from one or the other side -- should NormalVector be the same?
        return NormalVector;
    }

    public void Transform(TransformationMatrix4x4 transformation)
    {
        // TODO: implement
        throw new NotImplementedException();
    }

    public IIntersectable[]? GetFiguresInside()
    {
        // TODO: if needed, change self-returning logic to smth else
        return new IIntersectable[] { this };
    }

    public Point3D GetCentralPoint()
    {
        return Point;
    }
    public List<Point3D> GetDiscretePoints()
    {
        return new List<Point3D> { Point };
    }
}


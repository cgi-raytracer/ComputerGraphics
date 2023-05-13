﻿using RayCasting.Objects;
using RayCasting.Scenes;

namespace RayCasting.Casters;
public class LightNeglectingCaster : ICaster
{
    //public byte Cast(Scene scene, Point3D screenPoint)
    //{
    //    Vector3D rayDirection = new Vector3D(scene.Camera.Position, screenPoint);
    //    //    .Normalized();
    //    Ray3D ray = new(scene.Camera.Position, rayDirection);

    //    Point3D? intersectionPoint = scene.Figure.GetIntersectionPoint(ray);
    //    if (intersectionPoint == null)
    //        return 0;
    //    return 255;
    //}
    public byte Cast(Scene scene, (float, float, float) pixelAngles)
    {
        Vector3D rayDirection = new(pixelAngles);

        Ray3D ray = new(scene.Camera.Position, rayDirection);

        Point3D? intersectionPoint = null;

        foreach (var figure in scene.Figures)
        {
            intersectionPoint = figure.GetIntersectionPoint(ray);
            if (intersectionPoint != null)
                break;
        }
        
        if (intersectionPoint == null)
            return 0;

        return 255;
    }
}
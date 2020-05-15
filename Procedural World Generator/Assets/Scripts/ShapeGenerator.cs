﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeGenerator
{
    ShapeSettings settings;
    NoiseFilter noiseFilter;

    public ShapeGenerator(ShapeSettings settings)
    {
        this.settings = settings;
        noiseFilter = new NoiseFilter();
    }

    public Vector3 CalculatePointOnPlanet(Vector3 pointOnUnitSphere)
    {
        float elevation = noiseFilter.Evaluate(pointOnUnitSphere);
        return pointOnUnitSphere * settings.planerRadious * (elevation + 1);
    }
}

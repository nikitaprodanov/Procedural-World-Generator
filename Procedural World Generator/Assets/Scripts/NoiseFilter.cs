using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseFilter
{
    Noise noise = new Noise();
    NoiseSettings noiseSettings;

    public NoiseFilter(NoiseSettings noiseSettings)
    {
        this.noiseSettings = noiseSettings;
    }

    public float Evaluate(Vector3 point)
    {
        float noiseValue = 0;

        float frequency = noiseSettings.baseRoughness;
        float amplitude = 1;

        for (int i = 0; i < noiseSettings.numLayers; i++)
        {
            float v = noise.Evaluate(point * frequency + noiseSettings.center);
            noiseValue += (v + 1) * .5f * amplitude;
            frequency *= noiseSettings.roughness;
            amplitude *= noiseSettings.persistance;
        }

        return noiseValue * noiseSettings.strenght;
    }
}

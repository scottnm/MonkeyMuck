using UnityEngine;
using System.Collections;

public class LightFlicker : MonoBehaviour
{
    Light lightSource;

    [SerializeField] float intensityMin;
    [SerializeField] float intensityMax;

    void Start()
    {
        lightSource = GetComponent<Light>();
    }

    void Update()
    {
        lightSource.intensity = Mathf.Clamp(lightSource.intensity * Random.Range(.7f, 1.2f), intensityMin, intensityMax);
    }
}
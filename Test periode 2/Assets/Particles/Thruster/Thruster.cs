using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thruster : MonoBehaviour
{
    public void SetOn()
    {
        ParticleSystem.EmissionModule psEmission = gameObject.GetComponent<ParticleSystem>().emission;
        psEmission.rateOverTime = 10;

    }
    public void SetOf()
    {
        ParticleSystem.EmissionModule psEmission = gameObject.GetComponent<ParticleSystem>().emission;
        psEmission.rateOverTime = 0;
    }
}

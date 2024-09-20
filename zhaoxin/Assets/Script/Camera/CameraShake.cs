using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Cinemachine.CinemachineImpulseSource myImpuse;
    private void Start()
    {
        myImpuse = GetComponent<Cinemachine.CinemachineImpulseSource>();
    }
    public void CinemaShake()
    {
        myImpuse.GenerateImpulse();
    }
}

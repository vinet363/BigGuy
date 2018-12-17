using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class CameraShake : MonoBehaviour
{
    public void Shake()
    {
        CameraShaker.Instance.ShakeOnce(10f, 0.4f, 0.2f, 2f);
    }
}

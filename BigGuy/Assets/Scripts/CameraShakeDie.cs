using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class CameraShakeDie : MonoBehaviour
{
    private CameraShakeInstance myShake;
    public void ShakeDieExplode()
    {
        CameraShaker.Instance.ShakeOnce(5f, 5f, 0f, 1f);
    }

    public void ShakeDieStarve()
    {
        myShake = CameraShaker.Instance.StartShake(1f, 1f, 2f);
    }

    public void ShakeDieStop()
    {
        myShake.StartFadeOut(1f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Colorful;

public class CameraScript : MonoBehaviour
{
    [SerializeField] int timer = 2;
    [SerializeField] float amount = 2f;
    [SerializeField] float removeAmount = 0.1f;
    public void SplitRGB()
    {
        var splitter = GetComponent<RGBSplit>();
        splitter.Amount = 1f;
        for (int i = timer - 1; i >= 0; i--)
        {
            amount -= removeAmount;
        }
    }
}

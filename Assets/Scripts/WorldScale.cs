﻿using UnityEngine;
using VRTK;

public class WorldScale : MonoBehaviour
{
    public float scale = 1.0f;
    public VRTK_SDKManager sdkManager;

    private void Start()
    {
        WorldScaleManager.Instance.ChangeWorldScale(this); ;
    }
}

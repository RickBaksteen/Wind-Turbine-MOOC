﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class LockUI : MonoBehaviour
{
    public static bool OverGui=false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void MouseDown()
    {
        OverGui = true;
        Debug.Log("begin");
    }

    public void MouseUp()
    {
        OverGui = false;
        Debug.Log("Over GUI");
    }

}

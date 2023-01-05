using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        ColorWorld.ChangeColor(GetComponent<ColorEnv>().GetColor());
    }
}

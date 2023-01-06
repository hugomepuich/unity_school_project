using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheVoid : MonoBehaviour
{
    void Update()
    {
        transform.position += Vector3.right * 0.2f * Time.deltaTime;
    }
}

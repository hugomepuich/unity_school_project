using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDetector : MonoBehaviour
{
    private CharacterController cc;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.transform.GetComponent<MovingPlatform>())
        {
            transform.parent = collisionInfo.transform;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

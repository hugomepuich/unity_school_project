using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class MovingPlatform : MonoBehaviour
{
    public float travel_distance = 60f;
    private Vector3 base_position;
    private bool retour = false;
    public float speed = 5f;
    
    private bool _break = false;
    
    public bool inv = false;
    
    // Start is called before the first frame update
    void Start()
    {
        base_position = transform.position;
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {

        if (_break)
        {
            return;
        }
        
        float dist = Vector3.Distance(transform.position, base_position);

        if (dist > travel_distance && !retour)
        {
            StartCoroutine(Pause());
        }
        else if (dist < 0.5f)
        {
            retour = false;
        }
        
        transform.position = transform.position + ((retour ? (inv ? Vector3.forward : Vector3.left) : (inv ? Vector3.back : Vector3.right)) * speed) * 0.5f *  Time.deltaTime;
        
    }

    IEnumerator Pause()
    {
        _break = true;
        yield return new WaitForSeconds(3);
        retour = true;
        _break = false;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escalator : MonoBehaviour
{
    private float travel_distance = 40f;
    private Vector3 base_position;
    private bool retour = false;
    public float speed = 100f;

    public List<GameObject> contact_objects;
    
    // Start is called before the first frame update
    void Start()
    {
        contact_objects = new List<GameObject>();
        contact_objects.Add(this.gameObject);
        base_position = transform.localPosition;
    }



    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position, base_position);

        if (dist > travel_distance)
        {
            retour = true;
        }
        else if (dist < 0.5f)
        {
            retour = false;
        }
        
        transform.position = transform.position + ((retour ? Vector3.down : Vector3.up) * speed) * 0.1f * Time.deltaTime;
        
    }
}

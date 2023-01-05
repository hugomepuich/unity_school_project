using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interacter : MonoBehaviour
{
    
    [SerializeField] private Text itemName;
    public Transform playerTarget;
    [SerializeField] private Camera c;

    public int skip = 0;
    
    void Update()
    {
        if (skip == 10)
        {
            skip = 0;
            return;
        }

        skip++;
        Transform target = CastRay();

        if (target != playerTarget)
        {
            playerTarget = target;
            if (target && target.TryGetComponent(out Item it))
            {
                DisplayItemName(it);
            }
            else if (itemName.text.Length > 0)
            {
                itemName.text = "";
            }
            
        }
        if (Input.GetKey(KeyCode.E) && target && target.TryGetComponent(out Interactable itrct))
        {
            itrct.Interact();
        }
    }

    Transform CastRay()
    {
        Ray ray = new Ray(c.transform.position + 0.5f * Vector3.forward, c.transform.TransformDirection(Vector3.forward));
        RaycastHit hit;
        //int layerMask = 1 << 8;
        if(Physics.SphereCast(ray, 0.5f, out hit, 2))
        {
            return hit.transform;
        }
        
        return null;
    }

    void DisplayItemName(Item it)
    {
        itemName.text = it.GetName();

    }
}

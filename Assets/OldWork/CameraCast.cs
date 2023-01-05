using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraCast : MonoBehaviour
{

    [SerializeField] private Text itemName;
    public Transform playerTarget;

    [SerializeField] private Killer killer;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        Transform target = CastRay();

        playerTarget = target;  
        DisplayItemName(target);

        if (Input.GetKey(KeyCode.E) && target && target.TryGetComponent(out Item targetItem))
        {
            targetItem.Interact();
            playerTarget = null;
        }
    }

    Transform CastRay()
    {
        Ray ray;
        RaycastHit hit;
        //int layerMask = 1 << 8;
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            return hit.transform;
        }
        
        return null;
    }

    void DisplayItemName(Transform target)
    {
        if (target && target.TryGetComponent(out Item targetItem))
        {
            itemName.text = targetItem.GetName();
            return;
        }
        itemName.text = "";
    }
}

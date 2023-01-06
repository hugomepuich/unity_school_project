using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;

public class Interacter : MonoBehaviour
{
    
    [SerializeField] private Text itemName;
    public Transform playerTarget;
    [SerializeField] private Camera c;

    private GameObject playerpos;
    
    public int skip = 0;

    public GameObject playerobj;
    
    public bool hasCube = false;
    [SerializeField] private GameObject cubeobject;
    [SerializeField] private GameObject cubeprefab;

    [SerializeField] private ColorEnv.ItemColor current_cube_color;
    
    private void Start()
    {
        playerobj = GameObject.FindWithTag("Player");
        cubeobject.SetActive(hasCube);
    }

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
        
        if (Input.GetKey(KeyCode.E) && target && target.TryGetComponent(out CubeObject cubeobj))
        {
            PickUpCube(cubeobj);
        }
        
        if (Input.GetKey(KeyCode.E) && target && target.TryGetComponent(out Receiver r))
        {
            r.Deposit(current_cube_color);
        }
        
        if (Input.GetKey(KeyCode.A) && hasCube)
        {
            DropCube();
        }
    }

    void PickUpCube(CubeObject c)
    {
        print(c.GetColor());
        current_cube_color = c.GetColor();
        cubeobject.GetComponent<CubeRotation>().ChangeColor(current_cube_color);
        hasCube = true;
        c.PickUp();
        cubeobject.SetActive(true);
    }

    void DropCube()
    {
        hasCube = false;
        GameObject cube = Instantiate(cubeprefab, playerobj.transform.position + 2*Vector3.up + Vector3.forward, Quaternion.identity);
        cube.GetComponent<CubeObject>().SetColor(current_cube_color);
        cubeobject.SetActive(false);
    }

    Transform CastRay()
    {
        Ray ray = new Ray(c.transform.position + 0.5f * Vector3.forward, c.transform.TransformDirection(Vector3.forward));
        RaycastHit hit;
        //int layerMask = 1 << 8;
        if(Physics.SphereCast(ray, 1f, out hit, 10))
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

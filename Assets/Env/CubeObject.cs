using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CubeObject : MonoBehaviour
{
    public ColorEnv.ItemColor cube_color;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetColor(ColorEnv.ItemColor c)
    {
        cube_color = c;
        CubeRotation r = GetComponentInChildren<CubeRotation>();
        r.cube_color = cube_color;
        r.ChangeColor(cube_color);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public ColorEnv.ItemColor GetColor()
    {
        return this.cube_color;
    }
    
    public void  PickUp()
    {
        Destroy(this.gameObject);
    }
}

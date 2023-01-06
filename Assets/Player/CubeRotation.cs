using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotation : MonoBehaviour
{
    private float speed = 150f;
    public ColorEnv.ItemColor cube_color;
    
    // Start is called before the first frame update
    void Start()
    {
        ChangeColor(cube_color);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate (Vector3.up * 50 * Time.deltaTime, Space.Self);
        transform.Rotate (Vector3.left * 50 * Time.deltaTime, Space.Self);
        transform.Rotate (Vector3.back * 50 * Time.deltaTime, Space.Self);
    }

    public void ChangeColor(ColorEnv.ItemColor c)
    {
        cube_color = c;
        transform.GetComponent<MeshRenderer>().material.color = ColorEnv.ItemColorToMaterialColor(c);
    }
}

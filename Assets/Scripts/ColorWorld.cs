using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorWorld : MonoBehaviour
{

    public static ColorEnv.ItemColor current_color = ColorEnv.ItemColor.White;
    
    
    static GameObject[] env_items;
    static GameObject[] color_items;
    // Start is called before the first frame update
    void Start()
    {
        env_items = GameObject.FindGameObjectsWithTag("env");
        color_items = GameObject.FindGameObjectsWithTag("coloritems");
        ChangeColor(ColorEnv.ItemColor.White);
    }

    public static void ChangeColor(ColorEnv.ItemColor c)
    {
        ColorWorld.current_color = c;
        
        foreach (GameObject e_item in env_items)
        {
            MeshRenderer mr = e_item.GetComponent<MeshRenderer>();
            if (mr)
            {
                mr.material.color = ColorEnv.ItemColorToMaterialColor(c);
            }
        }
        
        
        
        foreach (GameObject co in color_items)
        {
            ColorEnv cenv = co.GetComponent<ColorEnv>();
            ColorEnv.ItemColor item_color = cenv.GetColor();
            co.SetActive(item_color != c); //&& item_color != ColorEnv.ItemColor.White);
            if (cenv.inverted)
            {
                co.SetActive(!co.activeSelf);
            }
            if (cenv.trap)
            {
                co.GetComponent<MeshRenderer>().material.color = ColorEnv.ItemColorToMaterialColor(current_color);
            }

            if (cenv.transform.GetComponent<Portal>())
            {
                Color _c = co.GetComponent<MeshRenderer>().material.color;
                co.GetComponent<MeshRenderer>().material.color = new Color(_c.r, _c.g, _c.b, 100f);
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorEnv : MonoBehaviour
{
    [SerializeField]
    private ItemColor my_color;

    public bool inverted;
    public bool trap;
    
    // Start is called before the first frame update
    void Awake()
    {
        ApplyColorRecursive(my_color, this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public ItemColor GetColor()
    {
        return my_color;
    }

    public Color GetMaterialColor()
    {
        return ItemColorToMaterialColor(my_color);
    }

    void ApplyColorRecursive(ItemColor c, Transform obj)
    {
        MeshRenderer m = obj.GetComponent<MeshRenderer>();
        if (m && !obj.CompareTag("alwayswhite"))
        {
            m.material.color = ItemColorToMaterialColor(trap ? ColorWorld.current_color : c);
        }
        foreach (Transform child in obj)
        {
            ApplyColorRecursive(c, child);
        }
    }

    public static Color ItemColorToMaterialColor (ItemColor c)
    {
        switch (c)
        {
            case ItemColor.Blue:
                return Color.blue;
            case ItemColor.Green:
                return Color.green;
            case ItemColor.Red:
                return Color.red;
            case ItemColor.White:
                return Color.white;
            case ItemColor.Yellow:
                return Color.yellow;
            default:
                return Color.white;
        }
    }

    public enum ItemColor
    {
        Red, Blue, Green, Yellow, White
    }
}

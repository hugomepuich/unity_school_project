using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapState : MonoBehaviour
{

    [SerializeField] static MapColor currentMapColor;
    [SerializeField] static MapColor previousMapColor = MapColor.White;
    [SerializeField] private List<GameObject> redObjects;
    [SerializeField] private List<GameObject> blueObjects;
    [SerializeField] private List<GameObject> greenObjects;
    [SerializeField] private List<GameObject> yellowObjects;
    [SerializeField] static Material mainMapMaterial;
    [SerializeField] private Material m;
    
    private static List<GameObject>[] _mapObjects;

    static MapColor[] colors = new MapColor[]
        { MapColor.Red, MapColor.Blue, MapColor.Green, MapColor.Yellow, MapColor.White };
    
    static int GetIndexOfColor(MapColor c)
    {
        for (int i = 0; i < colors.Length; i++)
        {
            if (c == colors[i])
            {
                return i;
            }
        }

        return -1;
    }

    private void InitObjects()
    {
        Item[] allObjectsItems = GameObject.FindObjectsOfType<Item>();
        List<GameObject> allObjects = new List<GameObject>();
        foreach (var itm in allObjectsItems)
        {
            allObjects.Add(itm.gameObject);
        }
        MapColor[] colors = new MapColor[]
            { MapColor.Red, MapColor.Blue, MapColor.Green, MapColor.Yellow, MapColor.White };
        for (int i = 0; i < allObjects.Count; i++)
        {
            Item it = allObjectsItems[i];
            int colorIndex = GetIndexOfColor(it.GetItemColor());
            if (colorIndex != -1 && colorIndex != 4)
            {
                print("colorindex : " + colorIndex);
                _mapObjects[colorIndex].Add(it.gameObject);
            }
            
        }

    }
    
    // Start is called before the first frame update
    private void Start()
    {
        _mapObjects = new List<GameObject>[] { redObjects, blueObjects, greenObjects, yellowObjects};
        mainMapMaterial = m;
        InitObjects();
        currentMapColor = MapColor.White;
        previousMapColor = MapColor.None;
        UpdateMap();
    }

    private void OnDestroy()
    {
        SwitchColor(MapColor.White);
    }

    public static void UpdateMap()
    {
        SwitchColor(currentMapColor);
    }

    public static void ChangeMainMaterial(Color col, Material m)
    {
        m.SetColor("_Color", col);
    }
    
    public static void SwitchColor(MapColor col)
    {
        print("Switching Color");
        
        if (currentMapColor == col && currentMapColor != MapColor.None)
        {
            print("" + currentMapColor + " " + col);
            SwitchColor(previousMapColor);
            return; 
        }
        
        previousMapColor = currentMapColor;
        Color[] trueColors = new Color[]
            { Color.red, Color.blue, Color.green, Color.yellow, Color.white  };

        int currentColorIndex = GetIndexOfColor(col);
        if (currentColorIndex == -1)
        {
            currentColorIndex = 4;
        }
        print("Index found " + currentColorIndex);
        for (int i = 0; i < _mapObjects.Length; i++)
        {
            List<GameObject> objList = _mapObjects[i];
            foreach (var go in objList)
            {
                if (!go)
                {
                    return;
                }
                go.TryGetComponent(out Item it);
                go.SetActive(i == currentColorIndex || it.IsEnabler());
            }
        }

        currentMapColor = col;
        ChangeMainMaterial(trueColors[currentColorIndex], mainMapMaterial);
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public enum MapColor
    {
        Red, Blue, Green, Yellow, White, None
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    [SerializeField]
    private string name;

    [SerializeField] private List<GameObject> destroyedOnCollect;

    [SerializeField] private Killer killer;

    [SerializeField] private MapState.MapColor itemColor;

    [SerializeField] bool enabler;
    // Start is called before the first frame update

    public MapState.MapColor GetItemColor()
    {
        return itemColor;
    }

    public bool IsEnabler()
    {
        return enabler;
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (itemColor != MapState.MapColor.None)
        {
            MapState.SwitchColor(itemColor);
        }
    }

    public string GetName()
    {
        return name;
    }

    public bool HasKiller()
    {
        return killer != null;
    }

    public void Kill()
    {
        if (HasKiller())
        {
            killer.Kill();
        }
    }
    
    

    public void Interact()
    {
        if (destroyedOnCollect.Count > 0)
        {
            foreach (var go in destroyedOnCollect)
            {
                if (go.TryGetComponent(out Item goItem) && goItem.HasKiller())
                {
                    goItem.Kill();
                }
                else
                {
                    Destroy(go);
                }
            }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Receiver : MonoBehaviour
{
    [SerializeField] ColorEnv.ItemColor col;
    
    public void Deposit(ColorEnv.ItemColor co)
    {

        if (col == co)
        {
            ColorWorld.ChangeColor(ColorEnv.ItemColor.White);
        }
        
    }

}

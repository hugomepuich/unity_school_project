using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public void Interact()
    {
        ColorEnv my_env = this.transform.GetComponent<ColorEnv>();
        if (my_env)
        {
            ColorWorld.ChangeColor(my_env.GetColor());
        }
    }
}

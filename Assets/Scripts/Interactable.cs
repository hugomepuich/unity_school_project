using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        ColorEnv my_env = this.transform.GetComponent<ColorEnv>();
        if (my_env)
        {
            ColorWorld.ChangeColor(my_env.GetColor());
        }
    }
}

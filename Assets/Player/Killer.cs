using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killer : MonoBehaviour
{

    [SerializeField] private KilledKind kind;

    private bool killStarted = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Kill()
    {
        if (killStarted)
        {
            return;
        }
        print("Killing " + gameObject.name);
        switch (kind)
        {
            case KilledKind.Sliding_Door:
                StartCoroutine(SlidingDoor());
                return;
            
            default:
                Destroy(this.gameObject);
                return;
        }
    }

    enum KilledKind
    {
        Sliding_Door
    }

    IEnumerator SlidingDoor()
    {
        killStarted = true;
        float i = 10;
        while (i > 0)
        {
            transform.parent.localScale = new Vector3(1, this.gameObject.transform.parent.localScale.y - 0.01f,1);
            yield return new WaitForSeconds(0.05f);
            i -= 0.1f;
        }
        Destroy(this.gameObject);
    }
}

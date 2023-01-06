using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionMenu : MonoBehaviour
{
    public void SelectLevel(int x)
    {
        SceneManager.LoadScene(x);
    }
    
}

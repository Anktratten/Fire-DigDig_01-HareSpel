using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject menu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenMenu()
    {
        menu.SetActive(true);
        isPaused = true;
    }
    
    public void CloseMenu()
    {
        menu.SetActive(false);
        isPaused = false;
    }
}

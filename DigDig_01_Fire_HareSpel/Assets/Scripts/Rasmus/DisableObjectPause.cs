using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableObjectPause : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseController.isPaused == true)
        {
            gameObject.GetComponent<Button>().interactable = false;
        }

        if (PauseController.isPaused == false)
        {
            gameObject.GetComponent<Button>().interactable = true;
        }
    }
}

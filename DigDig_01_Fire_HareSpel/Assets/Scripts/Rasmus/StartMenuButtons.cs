using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuButtons : MonoBehaviour
{
    public GameObject helpMenu;
    public GameObject optionsMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenHelpMenu()
    {
        helpMenu.gameObject.SetActive(true);
    }
    public void OpenOptionsMenu()
    {
        optionsMenu.gameObject.SetActive(true);
    }
    public void CloseHelpMenu()
    {
        helpMenu.gameObject.SetActive(false);
    }
    public void CloseOptionsMenu()
    {
        optionsMenu.gameObject.SetActive(false);
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Arvid_scene");
    }
}

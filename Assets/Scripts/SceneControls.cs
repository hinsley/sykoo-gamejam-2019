using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControls : MonoBehaviour
{

    public bool cursorLocked = true;

    void Start()
    {
        Debug.Log("Created!");
    }

    void Update() 
    {

        if (Input.GetKeyDown (KeyCode.Escape))
        {
            Application.Quit();
        }
        
        if (Input.GetKeyDown (KeyCode.Space))
        {
            Debug.Log(gameObject.name);
            SceneManager.LoadScene("Main Scene");
        }
        
        if (cursorLocked == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            if (Input.GetKeyDown (KeyCode.F9))
            {
                cursorLocked = false;
            }
        }
        else if (cursorLocked == false)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            if (Input.GetKeyDown (KeyCode.F9))
            {
                cursorLocked = true;
            }
        }


        
        // SceneManager.LoadScene("Main Scene");
        // Debug.Log ("Text: ");
    } 
    
}

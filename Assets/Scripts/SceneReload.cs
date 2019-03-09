using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneReload : MonoBehaviour
{
    public string mainMenuScene = "StartMenu";
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            
            Application.LoadLevel(mainMenuScene);
        }
    }
}

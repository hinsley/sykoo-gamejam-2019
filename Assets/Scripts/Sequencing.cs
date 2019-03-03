using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sequencing : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       SceneManager.LoadScene("Core GameObjects", LoadSceneMode.Additive);
       SceneManager.LoadScene("Enemy Testing", LoadSceneMode.Additive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

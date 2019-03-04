using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    public GameObject[] levelPrefabs;

    void Awake()
    {
        LoadLevel(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadLevel(int levelIndex)
    {
        Instantiate(
            levelPrefabs[levelIndex],
            new Vector3(0, 5, 0),
            new Quaternion(0, 0, 0, 1)
        );
    }
}

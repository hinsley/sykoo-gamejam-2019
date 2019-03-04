using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    public GameObject levelPrefab;

    void Awake()
    {
        Instantiate(
            levelPrefab,
            new Vector3(0, 5, 0),
            new Quaternion(0, 0, 0, 1)
        );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

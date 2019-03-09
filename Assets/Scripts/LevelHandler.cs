using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    public GameObject[] levelPrefabs;
    public int nextLevel;
    public GameObject gameOverUI;

    private GameObject currentLevel;

    void Awake()
    {
        LoadLevel(nextLevel++ - 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Enemies").transform.childCount == 0)
        {
            LoadLevel(nextLevel++ - 1);
        }

        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            gameOverUI.SetActive(true);
        }
    }

    void LoadLevel(int levelIndex)
    {
        if (currentLevel != null)
        {
            GameObject.Destroy(currentLevel);
        }

        currentLevel = Instantiate(
            levelPrefabs[levelIndex],
            new Vector3(0, 5, 0),
            new Quaternion(0, 0, 0, 1)
        );
    }
}

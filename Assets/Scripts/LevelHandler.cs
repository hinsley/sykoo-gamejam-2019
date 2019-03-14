using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    public GameObject[] levelPrefabs;
    public int nextLevel;
    public GameObject gameOverUI;
    public float timeBetweenLevels = 0f;

    private GameObject currentLevel;

    void Awake()
    {
        Invoke("LoadLevel", timeBetweenLevels);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Enemies").transform.childCount == 0)
        {
            Invoke("LoadLevel", timeBetweenLevels);
        }

        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            gameOverUI.SetActive(true);
        }
    }

    void LoadLevel()
    {
        if (currentLevel != null)
        {
            GameObject.Destroy(currentLevel);
        }

        currentLevel = Instantiate(
            levelPrefabs[nextLevel++ - 1],
            new Vector3(0, 5, 0),
            new Quaternion(0, 0, 0, 1)
        );
    }
}

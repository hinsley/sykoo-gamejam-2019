using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    public GameObject[] levelPrefabs;
    public int nextLevel;
    public GameObject gameOverUI;
    public float timeBetweenLevels = 0f;
    public GameObject lifeCounter;
    public GameObject playerContainerPrefab;
    public float playerRespawnTime;

    GameObject currentLevel;
    bool respawningPlayer;
    bool loadingLevel;

    void Awake()
    {
        Invoke("LoadLevel", timeBetweenLevels);
        loadingLevel = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Enemies").transform.childCount == 0)
        {
            Invoke("LoadLevel", timeBetweenLevels);
            loadingLevel = true;
        }

        if (GameObject.FindGameObjectWithTag("Player") == null && !respawningPlayer)
        {
            if (lifeCounter.GetComponent<LifeCounter>().livesRemaining-- > 0)
            {
                // This is very ugly. Sorry!
                GameObject.Destroy(GameObject.Find(playerContainerPrefab.name));
                Invoke("PlayerRespawn", playerRespawnTime);
                respawningPlayer = true;
            }
            else
            {
                gameOverUI.SetActive(true);
            }
        }
    }

    void PlayerRespawn()
    {
        Instantiate(playerContainerPrefab);
        respawningPlayer = false;
    }

    void LoadLevel()
    {
        if (loadingLevel)
        {
            if (currentLevel != null)
            {
                GameObject.Destroy(currentLevel);
            }

            Debug.Log(levelPrefabs[nextLevel - 1].name);
            currentLevel = Instantiate(
                levelPrefabs[nextLevel++ - 1],
                new Vector3(0, 5, 0),
                new Quaternion(0, 0, 0, 1)
            );
            
            loadingLevel = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject enemiesContainer;
    public GameObject flyInSpawnerContainer;
    public float dispatchInterval;
    public float maxEnemiesPerDispatch;

    private float timeSinceLastDispatch;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastDispatch += Time.deltaTime;
        if (timeSinceLastDispatch >= dispatchInterval)
        {
            Dispatch();
            timeSinceLastDispatch = timeSinceLastDispatch % dispatchInterval;
        }
    }

    void Dispatch()
    {
        // Ensure all enemies are in have ƒinished their fly-in transits.
        foreach (GameObject child in Utils.GetChildren(enemiesContainer))
        {
            Tweening tweening = child.GetComponent<Tweening>();
            if (tweening.inFlyInTransit)
            {
                return;
            }
        }

        for (int i = 0; i < maxEnemiesPerDispatch; i++)
        {
            while (true)
            {
                GameObject enemy = Utils.GetRandomElement(Utils.GetChildren(enemiesContainer));
                Tweening tweening = enemy.GetComponent<Tweening>();
                if (tweening.isIdle)
                {
                    tweening.PlayRandomAnimation();
                    break;
                }
            }
        }
    }
}

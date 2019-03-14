using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCounter : MonoBehaviour
{
    public GameObject lifeCounterPrefab;
    public int livesRemaining;
    public float iconHorizontalSpacing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifeCounterInstanceCount = livesRemaining;
    }

    GameObject GetLifeCounterInstance(int index)
    {
        return transform.GetChild(index).gameObject;
    }

    int lifeCounterInstanceCount
    {
        get
        {
            return transform.childCount;
        }

        set
        {
            while (lifeCounterInstanceCount != value)
            {
                if (lifeCounterInstanceCount < value)
                {
                    GameObject lifeCounter = Instantiate(
                        lifeCounterPrefab,
                        transform
                    );
                    lifeCounter.transform.Translate(
                        iconHorizontalSpacing * (lifeCounterInstanceCount - 1),
                        0,
                        0
                    );
                }
                else
                {
                    GameObject.DestroyImmediate(GetLifeCounterInstance(lifeCounterInstanceCount-1));
                }
            }
        }
    }
}

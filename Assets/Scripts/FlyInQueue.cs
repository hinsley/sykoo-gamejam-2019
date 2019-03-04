using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyInQueue : MonoBehaviour
{
    [System.NonSerialized]
    public List<GameObject> queue;
    // releaseRate is in released objects per second.
    public float releaseRate;

    private float timeElapsed;

    void Start()
    {
        Awake();
    }

    void Awake()
    {
        timeElapsed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= 1 / releaseRate)
        {
            ReleaseItem();
            timeElapsed = timeElapsed % (1 / releaseRate);
        }
    }

    public void AddItem(GameObject item)
    {
        if (queue == null)
        {
            queue = new List<GameObject>();
        }
        item.transform.position = transform.position;
        item.transform.rotation = transform.rotation;
        item.SetActive(false);
        queue.Add(item);
    }

    void ReleaseItem()
    {
        if (queue.Count > 0)
        {
            queue[0].SetActive(true);
            queue.RemoveAt(0);
        }
    }
}

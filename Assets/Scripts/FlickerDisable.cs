using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerDisable : MonoBehaviour
{
    [Tooltip("Flicker rate per second.")]
    public float flickerRate;
    public GameObject flickeringGameObject;

    private float timeElapsed = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= 1 / flickerRate)
        {
            flickeringGameObject.SetActive(!flickeringGameObject.activeSelf);
        }
        timeElapsed = timeElapsed % (1 / flickerRate);
    }
}

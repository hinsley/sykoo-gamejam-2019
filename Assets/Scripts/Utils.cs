using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    private static System.Random random = new System.Random();

    public static AudioSource GetAudioSource()
    {
        return GameObject.FindGameObjectWithTag("AudioSource").GetComponent<AudioSource>();
    }

    public static GameObject[] GetChildren(GameObject parent)
    {
        List<GameObject> childList = new List<GameObject>();
        foreach (Transform childTransform in parent.transform)
        {
            GameObject child = childTransform.gameObject;
            if (child.name != "New Game Object")
            {
                childList.Add(child.gameObject);
            }
        }
        return childList.ToArray();
    }

    public static T GetRandomElement<T>(T[] array)
    {
        int index = random.Next(0, array.Length);
        return array[index];
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ElementContainer
{
    public GameObject[] elements;

    public void Activate(bool state)
    {
        foreach (GameObject g in elements)
        {
            g.SetActive(state);
        }
    }
}

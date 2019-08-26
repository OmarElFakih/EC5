using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance = null;

    [SerializeField]
    private ElementContainer[] _gameElements = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
    }

  /*  public void LoadRequest(int _index)
    {
        GameManager.instance.LoadScene(_index);
    }*/

    public void ShowElements(int _index)
    {
        foreach(ElementContainer e in _gameElements)
        {
            e.Activate(false);
        }

        _gameElements[_index].Activate(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameOverMenu : MonoBehaviour
{
    public static GameOverMenu Instance { get; private set; }

    void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
    }

    public void Display()
    {
        Controller.Instance.CanPause = false;
        gameObject.SetActive(true);
        GameSystem.Instance.StopTimer();
        Controller.Instance.DisplayCursor(true);
    }
}

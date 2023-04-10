using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class SettingsMenu : MonoBehaviour
{
    public static SettingsMenu Instance { get; private set; }

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
    }

    public void BackButton()
    {
        UIAudioPlayer.PlayPositive();
        Controller.Instance.CanPause = true;
        gameObject.SetActive(false);
        PauseMenu.Instance.Display();
    }
}
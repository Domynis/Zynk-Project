﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu Instance { get; private set; }

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

    public void Settings ()
    {
        gameObject.SetActive(false);
        SettingsMenu.Instance.Display();
    }

    public void OpenEpisode()
    {
        if(LevelSelectionUI.Instance.IsEmpty())
            return;
        
        UIAudioPlayer.PlayPositive();
        gameObject.SetActive(false);
        LevelSelectionUI.Instance.DisplayEpisode();
    }

    public void ReturnToGame()
    {
        UIAudioPlayer.PlayPositive();
        Controller.Instance.CanPause = true;
        GameSystem.Instance.StartTimer();
        gameObject.SetActive(false);
        Controller.Instance.DisplayCursor(false);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}

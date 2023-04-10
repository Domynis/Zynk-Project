using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{

    public Text buttonText;
    void Start()
    {
        buttonText.text = "Disable";
        AudioListener.volume = 0.5f;
    }

    public void ChangeVolume()
    {
        if (AudioListener.volume != 0)
        {
            buttonText.text = "Enable";
            AudioListener.volume = 0;
        }
        else
        {
            buttonText.text = "Disable";
            AudioListener.volume = 0.5f;
        }
    }
}

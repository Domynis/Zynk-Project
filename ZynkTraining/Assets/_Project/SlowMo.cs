using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlowMo : MonoBehaviour
{
    public Text buttonText;

    void Start()
    {
        buttonText.text = "Enable";
    }

    public void SlowMoButton()
    {
        GameSystem.Instance.CanSlowMo = !GameSystem.Instance.CanSlowMo;
        buttonText.text = GameSystem.Instance.CanSlowMo ? "Disable" : "Enable";
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StomachDamage : MonoBehaviour
{

    private bool isEven = false;

    private void OnTriggerStay(UnityEngine.Collider other)
    {
        if (other.gameObject.CompareTag("Player")){
            var timeSpan = DateTime.Now;
            if(timeSpan.Second % 2 == 0){
                if (isEven == false)
                {
                    PlayerHealthController.Instance.TakeDamage(1);
                }
                isEven = true;
            }else
            {
                isEven = false;
            }
            
        }
    }
}

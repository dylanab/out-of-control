using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanicMeter : Singleton<PanicMeter>
{
    public int value = 0;
    public Text numberDisplay;

    public void IncreasePanic() {
        this.value++;
        this.numberDisplay.text = this.value.ToString();
    }
}

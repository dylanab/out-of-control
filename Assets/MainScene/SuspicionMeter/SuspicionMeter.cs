using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuspicionMeter : MonoBehaviour
{

    public Slider suspicionBar;
    public RectTransform fillrect;
    public int totalSuspicion = 0;
    public int maxSuspicion = 100;
    public float barValue = 0;
    public float fillSpeed = 1.0f; 


    // Start is called before the first frame update
    void Start()
    {
        suspicionBar.wholeNumbers = false;
        suspicionBar.maxValue = (float)maxSuspicion;
        suspicionBar.minValue = 0.0f;
        suspicionBar.value = barValue;
    }

    // Update is called once per frame
    void Update()
    {
        barValue = Mathf.MoveTowards(barValue, (float)totalSuspicion, Time.deltaTime * fillSpeed);
        suspicionBar.value = barValue;
    }

    public void UpdateSuspicion(GameManager gameManager) {
        GuestList guests = gameManager.guests;
        int newSuspicion = guests.GetTotalSuspicion();

        if(newSuspicion > maxSuspicion) {
            newSuspicion = maxSuspicion;
            //TODO(Dylan): let the GameManager know that the game should end.
            // or does something else take care of that?
        } else if (newSuspicion < 0) {
            newSuspicion = 0;
        }

        totalSuspicion = newSuspicion;
    }

}

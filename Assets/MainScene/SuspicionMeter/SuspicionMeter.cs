using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuspicionMeter : MonoBehaviour
{

    public Transform mask;
    public int totalSuspicion = 0;
    public int maxSuspicion = 100;
    public float maskY = 0f;
    public float maxMaskY = 2.1f;
    public float maskSpeed = 1.0f; 

    public float destMaskY = 0f;

    public float maskYIncrement = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //mask.position = new Vector3(0,0,0);
        maskYIncrement = maxMaskY / maxSuspicion;
    }

    // Update is called once per frame
    void Update()
    {
        if(destMaskY != maskY) {
            maskY = Mathf.MoveTowards(maskY, destMaskY, Time.deltaTime * maskSpeed);
        }
        mask.position = new Vector3(mask.position.x, maskY, mask.position.z);

        if(mask.position.y == maskY && totalSuspicion == maxSuspicion) {
            //Trigger game over   
        }

    }

    public void UpdateSuspicion(GameManager gameManager) {
        GuestList guests = gameManager.guests;
        int newSuspicion = guests.GetTotalSuspicion();

        if(newSuspicion > maxSuspicion) {
            newSuspicion = maxSuspicion;
        } else if (newSuspicion < 0) {
            newSuspicion = 0;
        }

        totalSuspicion = newSuspicion;
        destMaskY = totalSuspicion * maskYIncrement;
    }

}

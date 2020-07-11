using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputOverlay : MonoBehaviour
{
    public Image overlay;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.phaseChanged += OnPhaseChange;   
    }

    private void OnPhaseChange(Phase newPhase) {
        Debug.Log("New Phase: " + newPhase);
        if (newPhase == Phase.Play)
            overlay.raycastTarget = false;
        else
            overlay.raycastTarget = true;
    }
}

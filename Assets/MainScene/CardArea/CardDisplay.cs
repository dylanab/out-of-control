using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Script for UI element that displays a card in the player's hand
public class CardDisplay : MonoBehaviour
{
    public Card card;
    public Animator animator;

    // Cached Components
    public Image icon;
    public GameObject cardBackground;
    public GameObject bloodlustOverlay;
    public Text titleText;
    public Text descriptionText;

    public void SetCard(Card c = null) {
        if (c == null) 
        {
            HideCard();
        }
        else if (c.name == "Bloodlust")
        {
            bloodlustOverlay.SetActive(true);
        }
        else
        {
            cardBackground.SetActive(true);
            bloodlustOverlay.SetActive(false);
            // icon.sprite = c.icon;
            titleText.text = c.name;
            descriptionText.text = c.description;
        }   
    }

    public void HideCard() {
        cardBackground.SetActive(false);
        bloodlustOverlay.SetActive(false);
    }

    public void OnClick() {
        Debug.Log("CLICKED CARD");
        // if (card.targetType != TargetType.None)
        //     GameManager.Instance.BeginTargeting(card);
        // else
        //     GameManager.Instance.UseCard(card);
    }
}

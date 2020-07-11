using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Script for UI element that displays a card in the player's hand
public class CardDisplay : MonoBehaviour
{
    public Card card;

    // Cached Components
    public Image icon;
    public Image cardBackground;
    public Text titleText;
    public Text descriptionText;

    public void SetCard(Card c) {
        cardBackground.enabled = true;
        icon.sprite = c.icon;
        titleText.text = c.name;
        descriptionText.text = c.description;
    }

    public void HideCard() {
        cardBackground.enabled = false;
    }

    public void OnClick() {
        Debug.Log("CLICKED CARD");
        // if (card.targetType != TargetType.None)
        //     GameManager.Instance.BeginTargeting(card);
        // else
        //     GameManager.Instance.UseCard(card);
    }
}

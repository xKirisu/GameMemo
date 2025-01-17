using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    static CardController cardController;

    SpriteRenderer spriteRenderer;

    Sprite frontSprite;
    Sprite backSprite;

    Card mached;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        backSprite = spriteRenderer.sprite;
    }

    public void ClickOn()
    {
        spriteRenderer.sprite = frontSprite;
        
    }
    public void ClickOff()
    {
        spriteRenderer.sprite = backSprite;
    }

    public GameObject MakeMachCard()
    {
        GameObject machedCard = Instantiate(gameObject);
        Card card;

        if(card = machedCard.GetComponent<Card>())
        {
            MachCards(card);
        }
        
        return machedCard;
    }

    void MachCards(Card card)
    {
        mached = card;
        card.mached = this;

        Sprite sprite = cardController.GetSprite();

        frontSprite = sprite;
        mached.frontSprite = sprite;
    }
    public bool CheckMach(Card card)
    {
        if(card == mached)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public static void SetDB(CardController cc)
    {
        cardController = cc;
    }

    private void OnMouseDown()
    {
        if (cardController.onCorutine)
            return;

        StartCoroutine(cardController.SelectCard(this));
    }
}

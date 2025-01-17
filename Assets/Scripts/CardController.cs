using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardController : MonoBehaviour
{
    [SerializeField] Card card;
    [SerializeField] GenerateBoard board;
    [SerializeField] UIManage uimanage;

    private HashSet<int> usedSpritesIndexes = new HashSet<int>();
    [SerializeField] List<Sprite> Sprites;

    [HideInInspector]
    public bool onCorutine = false;
    [HideInInspector]
    public bool onWin = false;

    Card SelectedCard1;
    Card SelectedCard2;

    public void Awake()
    {
        Card.SetDB(this);
    }
    public Sprite GetSprite()
    {
        if (usedSpritesIndexes.Count >= Sprites.Count)
        {
            Debug.LogWarning("All sprites have been used!");
            return null;
        }

        int index;
        do
        {
            index = UnityEngine.Random.Range(0, Sprites.Count);
        } while (usedSpritesIndexes.Contains(index));

        usedSpritesIndexes.Add(index);
        return Sprites[index];
    }

    public IEnumerator SelectCard(Card card)
    {
        onCorutine = true;

        card.ClickOn();

        if (SelectedCard1 != null)
        {
            yield return new WaitForSeconds(0.5f);

            SelectedCard2 = card;

            if (SelectedCard2.CheckMach(SelectedCard1))
            {
                board.cardsList.Remove(SelectedCard1.gameObject);
                board.cardsList.Remove(SelectedCard2.gameObject);

                Destroy(SelectedCard1.gameObject);
                Destroy(SelectedCard2.gameObject);

                
                if(board.cardsList.Count <= 0)
                {
                    onWin = true;
                    uimanage.DisplayMenu();
                }
            }
            else
            {
                SelectedCard1.ClickOff();
                SelectedCard2.ClickOff();

                SelectedCard1 = null;
                SelectedCard2 = null;
            }
        }
        else
        {
            SelectedCard1 = card;
        }

        onCorutine = false;
    }
}

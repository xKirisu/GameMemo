using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GenerateBoard : MonoBehaviour
{
    [SerializeField] GameObject CardPrefab;

    [SerializeField] float CardDistanceX = 80;
    [SerializeField] float CardDistanceY = 140;

    [SerializeField] int BoardHeight = 3;
    [SerializeField] int BoardWidth = 4;

    [HideInInspector]
    public List<GameObject> cardsList = new List<GameObject>();

    void Start()
    {
        if (BoardHeight * BoardWidth % 2 == 0)
        {
            int individual_card_count = BoardHeight * BoardWidth / 2;

            for(int i = 0; i < individual_card_count; i++)
            {
                GameObject cardObject = Instantiate(CardPrefab);
                Card card1 = cardObject.GetComponent<Card>();

                if(card1)
                {
                    GameObject cardObject2 = card1.MakeMachCard();
                    Card card2;

                    if(card2 = cardObject2.GetComponent<Card>())
                    {
                        cardsList.Add(cardObject2);
                        cardObject2.transform.parent = transform;
                    }
                }

                cardsList.Add(cardObject);
                cardObject.transform.parent = transform;
            }

            cardsList = Shuffle(cardsList);


            //Initalize list of positions
            List<Vector3> positions = new List<Vector3>();

            float startX = (BoardWidth - 1) * CardDistanceX / 2;
            float startY = (BoardHeight - 1) * CardDistanceY / 2;

            for (int y = 0; y < BoardHeight; y++)
            {
                for(int x = 0; x <  BoardWidth; x++)
                {
                    float dx = startX - x * CardDistanceX;
                    float dy = startY - y * CardDistanceY;

                    positions.Add(new Vector3(dx, dy));
                }
            }

            for(int i =0; i < cardsList.Count && i < positions.Count; i++)
            {
                cardsList[i].transform.position = positions[i];
            }
        }
        else
        {
            Debug.Log("Board must allow for the generation of an even number of cards");
        }
    }

    public List<GameObject> Shuffle(List<GameObject> list)
    {
        System.Random random = new System.Random();
        return list.OrderBy(x => random.Next()).ToList();
    }
}

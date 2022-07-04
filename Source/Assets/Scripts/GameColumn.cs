using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameColumn : Column
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    // Set the position of all cards from this column
    public override void SetPosition()
    {
        float yOffset = 0;
        float zOffset = -0.03f;
        foreach (GameObject card in cards)
        {
            card.transform.position = new Vector3(transform.position.x, transform.position.y + yOffset, transform.position.z + zOffset);
            yOffset -= 0.35f;
            zOffset -= 0.3f;
        }
    }
    // Check if the given card fits ontop of the top card of this column
    public override bool CheckIfSuitable(GameObject obj)
    {
        if (obj != null)
        {
                
            Card card = obj.GetComponent<Card>();
            Card topCard = null;
            if (cards.Count > 0)
            {
                topCard = cards[cards.Count - 1].GetComponent<Card>();
            }

            if (cards.Count == 0)
            {
                if (card.value == 12)
                {
                    return true;
                }
            }

            // Check if the "color" is possible
            else if ((card.suit.ToString() == "HEART" || card.suit.ToString() == "DIAMOND") &&
                (topCard.suit.ToString() == "CLUB" || topCard.suit.ToString() == "SPADE"))
            {
                // Check if the value is possible
                if (card.value == topCard.value - 1)
                {
                    return true;
                }
            }
            // Check if the "color" is possible
            else if ((card.suit.ToString() == "CLUB" || card.suit.ToString() == "SPADE") &&
                (topCard.suit.ToString() == "HEART" || topCard.suit.ToString() == "DIAMOND"))
            {
                // Check if the value is possible
                if (card.value == topCard.value - 1)
                {
                    return true;
                }
            }
        }
        return false;
    }
}

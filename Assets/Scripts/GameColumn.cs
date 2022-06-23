using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solitair {
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
        public override void SetPosition()
        {
            float yOffset = 0;
            float zOffset = -0.03f;
            foreach (GameObject card in cards)
            {
                card.transform.position = new Vector3(transform.position.x, transform.position.y + yOffset, transform.position.z + zOffset);
                yOffset -= 0.25f;
                zOffset -= 0.3f;
            }
        }
        public bool CheckIfSuitable(GameObject obj)
        {
            if (obj != null)
            {
                Card card = obj.GetComponent<Card>();
                Card topCard = cards[cards.Count - 1].GetComponent<Card>();
                if ((card.suit.ToString() == "HEART" || card.suit.ToString() == "DIAMOND") &&
                    (topCard.suit.ToString() == "CLUB" || topCard.suit.ToString() == "SPADE"))
                {
                    if (card.value == topCard.value - 1)
                    {
                        return true;
                    }
                }
                else if ((card.suit.ToString() == "CLUB" || card.suit.ToString() == "SPADE") &&
                    (topCard.suit.ToString() == "HEART" || topCard.suit.ToString() == "DIAMOND"))
                {
                    if (card.value == topCard.value - 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}

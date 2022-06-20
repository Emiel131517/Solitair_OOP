using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solitair
{
    public class DeckColumn : Column
    {
        private GameObject filledDeckBG;
        private int i = 0;
        private float zoffset = 0;
        // Start is called before the first frame update
        void Start()
        {
            filledDeckBG = GameObject.Find("Deck_closed");
        }

        // Update is called once per frame
        void Update()
        {
            SetBackground();
        }
        public override void SetPosition()
        {
            foreach (GameObject card in cards)
            {
                card.transform.position = new Vector3(transform.position.x - 100, transform.position.y, transform.position.z);
            }
        }
        private void SetBackground()
        {
            if (cards.Count == 0)
            {
                filledDeckBG.SetActive(false);
            }
            else
            {
                filledDeckBG.SetActive(true);
            }
        }
        private void FlipCardFromDeck()
        {
            if (i >= cards.Count)
            {
                // TODO::reset deck
                foreach (GameObject card in cards)
                {
                    card.GetComponent<Card>().CloseCard();
                    card.transform.position = new Vector3(transform.position.x - 10, transform.position.y, 0);
                }
                i = 0;
                zoffset = 0;
                Debug.Log("All cards flipped");
                return;
            }
            cards[i].transform.position = new Vector3(transform.position.x + 2, transform.position.y, transform.position.z + zoffset);
            cards[i].GetComponent<Card>().OpenCard();
            i++;
            zoffset -= 0.1f;
        }
        private void OnMouseDown()
        {
            FlipCardFromDeck();  
        }
    }
}
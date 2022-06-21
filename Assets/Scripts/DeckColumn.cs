using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solitair
{
    public class DeckColumn : Column
    {
        // Background
        private GameObject filledDeckBG;
        // Index
        private int i = 0;
        // Zoffset
        private float zoffset = 0;
        // Start is called before the first frame update
        void Start()
        {
            // Set background at start of the game
            filledDeckBG = GameObject.Find("Deck_closed");
        }

        // Update is called once per frame
        void Update()
        {
            // Set the background
            SetBackground();
        }
        // Set the position of each card
        public override void SetPosition()
        {
            foreach (GameObject card in cards)
            {
                card.transform.position = new Vector3(transform.position.x - 100, transform.position.y, transform.position.z);
            }
        }
        // Set the backgroud based on the amound of cards left
        private void SetBackground()
        {
            if (i == cards.Count)
            {
                filledDeckBG.SetActive(false);
            }
            else
            {
                filledDeckBG.SetActive(true);
            }
        }
        // Open a card from the deck
        private void OpenCardFromDeck()
        {
            if (i >= cards.Count)
            {
                // Reset the deck
                ResetDeck();
                return;
            }
            cards[i].transform.position = new Vector3(transform.position.x + 2, transform.position.y, transform.position.z + zoffset);
            cards[i].GetComponent<Card>().OpenCard();
            i++;
            zoffset -= 0.1f;
        }
        // Reset the deck
        private void ResetDeck()
        {
            foreach (GameObject card in cards)
            {
                card.GetComponent<Card>().CloseCard();
                card.transform.position = new Vector3(transform.position.x - 10, transform.position.y, 0);
            }
            i = 0;
            zoffset = 0;
            Debug.Log("All cards flipped");
        }
        private void OnMouseDown()
        {
            OpenCardFromDeck();  
        }
    }
}
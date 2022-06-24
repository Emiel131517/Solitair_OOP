﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solitair
{
    public class DeckColumn : Column
    {
        private GameObject filledDeckBG;
        private Vector3 pos;
        private int index;
        private float zoffset;
        // Start is called before the first frame update
        void Start()
        {
            // Set background at start of the game
            filledDeckBG = GameObject.Find("Deck_closed");
            index = 0;
            zoffset = 0;
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
            float lzoffset = 0.0f;
            foreach (GameObject card in cards)
            {
                if (card.GetComponent<Card>().isOpen)
                {
                    card.transform.position = new Vector3(transform.position.x + 2, transform.position.y, transform.position.z + lzoffset);
                    lzoffset -= 0.1f;
                }
                if (!card.GetComponent<Card>().isOpen)
                {
                    card.transform.position = new Vector3(transform.position.x - 5, transform.position.y, 0);
                }
            }
        }
        // Set the backgroud based on the amound of cards left
        private void SetBackground()
        {
            if (index == cards.Count)
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
            if (index >= cards.Count)
            {
                // Reset the deck
                ResetDeck();
            }
            else
            {
                cards[index].transform.position = new Vector3(transform.position.x + 2, transform.position.y, transform.position.z + zoffset);
                pos = cards[index].transform.position;
                cards[index].GetComponent<Card>().OpenCard();
                index++;
                zoffset -= 0.1f;
            }
        }
        // Reset the deck
        private void ResetDeck()
        {
            foreach (GameObject card in cards)
            {
                card.GetComponent<Card>().CloseCard();
                card.transform.position = new Vector3(transform.position.x - 5, transform.position.y, 0);
            }
            index = 0;
            zoffset = 0;
            Debug.Log("All cards flipped");
        }
        private void OnMouseDown()
        {
            OpenCardFromDeck();  
        }
    }
}
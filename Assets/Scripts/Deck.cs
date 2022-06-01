using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Solitair
{
    public class Deck : MonoBehaviour
    {
        private List<Card> deck;
        void Start()
        {
            deck = new List<Card>();
            GenerateDeck();
            ShuffleDeck(deck);
        }

        void Update()
        {

        }
        // Generate a deck
        private void GenerateDeck()
        {
            for (int i = 0; i < 52; i++)
            {
                // Add card rank
                Rank r = (Rank)Enum.ToObject(typeof(Rank), i / 13);
                // Create a card with the value and the rank
                Card c = new Card(i % 13, r);
                // Add the card to the list
                deck.Add(c);
            }
        }

        // Fisher-Yates shuffle
        private List<Card> ShuffleDeck (List<Card> list)
        {
            for (int i = list.Count - 1; i > 0; i--)
            {
                int rnd = UnityEngine.Random.Range(0, list.Count);
                Card c = list[i];
                list[i] = list[rnd];
                list[rnd] = c;
            }

            // Print list
            for (int i = 0; i < list.Count; i++)
            {
                list[i].PrintCardInfo();
            }
            return list;
        }
    }
}
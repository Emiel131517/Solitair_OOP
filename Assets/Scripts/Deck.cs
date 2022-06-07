using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Solitair
{
    public class Deck : MonoBehaviour
    {
        public List<Card> deck;
        [SerializeField]
        private Card prefab;
        void Start()
        {
            deck = new List<Card>();
            GenerateDeck();
            Shuffle(deck);

            // Print list
            for (int i = 0; i < deck.Count; i++)
            {
                deck[i].PrintCardInfo();
            }
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
                Suit s = (Suit)Enum.ToObject(typeof(Suit), i / 13);
                Instantiate(prefab, transform.position, Quaternion.identity);
                // Create a card with the value and the rank
                prefab.SetCardStats(i % 13, s);
                // Add the card to the list
                deck.Add(prefab);
            }
        }

        // Fisher-Yates shuffle
        private List<T> Shuffle<T> (List<T> list)
        {
            for (int i = list.Count - 1; i > 0; i--)
            {
                int rnd = UnityEngine.Random.Range(0, list.Count);
                T c = list[i];
                list[i] = list[rnd];
                list[rnd] = c;
            }
            return list;
        }
    }
}
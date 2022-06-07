using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Solitair
{
    public class Deck : MonoBehaviour
    {
        public List<Card> cards;
        void Start()
        {
            cards = new List<Card>();
            GenerateDeck();
            Shuffle(cards);
            CreateObjects();
        }

        void Update()
        {

        }
        // Generate a deck        
        private void GenerateDeck()
        {
            for (int i = 0; i < 52; i++)
            {
                Suit s = (Suit)Enum.ToObject(typeof(Suit), i / 13);
                int v = i % 13;
                Card c  = new Card();
                c.SetCardStats(v, s);
                cards.Add(c);
            }
        }
        // Fisher-Yates shuffle
        private List<T> Shuffle<T> (List<T> list)
        {
            for (int i = list.Count - 1; i > 0; i--)
            {
                int rnd = UnityEngine.Random.Range(0, list.Count);
                T s = list[i];
                list[i] = list[rnd];
                list[rnd] = s;
            }
            return list;
        }
        // Create objects of the cards from the list
        private void CreateObjects()
        {
            foreach (Card card in cards)
            {
                Card prefab = Resources.Load<Card>("Prefabs/Card");
                prefab.value = card.value;
                prefab.suit = card.suit;
                Instantiate(prefab, transform.position, Quaternion.identity);
            }
        }
        public List<Card>Deal(int amount)
        {
            List<Card> temp = new List<Card>();
            if (cards.Count < amount)
            {
                return temp;
            }
            for (int i = 0; i < amount; i++)
            {
                temp.Add(cards.RemoveAt(0));
            }
            return temp;
        }
    }
}
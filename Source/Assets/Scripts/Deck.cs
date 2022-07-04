using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Deck : MonoBehaviour
{
    public List<GameObject> cards;
    void Start()
    {
        cards = new List<GameObject>();
        GenerateDeck();
        Shuffle(cards);
    }
    // Generate a deck        
    private void GenerateDeck()
    {
        for (int i = 0; i < 52; i++)
        {
            // Create suit and value
            Suit s = (Suit)Enum.ToObject(typeof(Suit), i / 13);
            int v = i % 13;

            // Get prefab as gameobject
            GameObject prefab = Resources.Load<GameObject>("Prefabs/Card");

            // Get card component from gameobject and assign value and suit
            Card card = prefab.GetComponent<Card>();
            card.value = v;
            card.suit = s;
            prefab.name = card.value.ToString() + card.suit.ToString();
                
            // Instantiate as gameobject and put it in the list
            GameObject obj = Instantiate(prefab, transform.position, Quaternion.identity);
            cards.Add(obj);
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
    // Take a card from this list and put it in another list
    public List<GameObject> TakeCard(int amount)
    {
        List<GameObject> temp = new List<GameObject>();
        if (cards.Count < amount)
        {
            return temp;
        }
        for (int i = 0; i < amount; i++)
        {
            temp.Add(cards[0]);
            cards.Remove(cards[0]);
        }
        return temp;
    }
}
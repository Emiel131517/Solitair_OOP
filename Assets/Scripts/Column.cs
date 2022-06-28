using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Column : MonoBehaviour
{
    public List<GameObject> cards;
    void Start()
    {
        cards = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    // Add a list of cards to this list of cards
    public void AddCardsListToList(List<GameObject> list)
    {
        foreach (GameObject card in list)
        {
            cards.Add(card);
            card.GetComponent<Card>().parentColumn = this;
        }
    }
    // Add one card on top of this list
    public void AddCardToTopOfList(GameObject card)
    {
        cards.Insert(cards.Count, card);
        card.GetComponent<Card>().parentColumn = this;
    }
    // Add one card to this list
    public void AddCardToList(GameObject card)
    {
        cards.Add(card);
        card.GetComponent<Card>().parentColumn = this;
    }
    // Remove one card from this list
    public void RemoveCard(GameObject card)
    {
        cards.Remove(card);
    }
    // Remove and return the amount of cards given from this list
    public GameObject TakeCard(int index)
    {
        GameObject card = cards[index];
        cards.RemoveAt(index);
        return card;
    }
    // Base function to set the position of the cards as the position of the GameObject
    public virtual void SetPosition()
    {
        foreach (GameObject card in cards)
        {
            card.transform.position = this.transform.position;
        }
    }
    public virtual bool CheckIfSuitable(GameObject obj)
    {
        return false;
    }
}
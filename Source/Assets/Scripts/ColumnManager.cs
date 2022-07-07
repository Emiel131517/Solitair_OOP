using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColumnManager : MonoBehaviour
{
    private Deck deck;
    private DeckColumn deckColumn;
    [SerializeField]
    private List<GameColumn> gameColumns;
    private AudioSource flipSound;

    // Start is called before the first frame update
    void Start()
    {
        deck = GameObject.Find("Deck").GetComponent<Deck>();
        deckColumn = GameObject.Find("DeckButton").GetComponent<DeckColumn>();
        flipSound = gameObject.GetComponent<AudioSource>();
        StartCoroutine(DealDelay());
    }

    // Update is called once per frame
    void Update()
    {

    }
    // Delay befor dealing after the game started
    IEnumerator DealDelay()
    {
        yield return new WaitForSeconds(0.01f);
        StartCoroutine(Deal());
    }
    // Deal the cards to the right columns
    private IEnumerator Deal()
    {
        int i = 1;
        foreach (GameColumn gameColumn in gameColumns)
        {
            yield return new WaitForSeconds(0.3f);
            gameColumn.AddCardsListToList(deck.TakeCard(i));
            gameColumn.SetPosition();
            flipSound.Play();
            i++;
        }
        deckColumn.AddCardsListToList(deck.TakeCard(deck.cards.Count));
        OpenTopCard();
    }
    // Open the top card in a each column
    private void OpenTopCard()
    {
        foreach (GameColumn gameColumn in gameColumns)
        {
            int i = gameColumn.cards.Count - 1;
            gameColumn.cards[i].GetComponent<Card>().OpenCard();
        }
    }
}

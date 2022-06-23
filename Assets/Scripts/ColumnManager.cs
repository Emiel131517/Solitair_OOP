using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Solitair
{
    public class ColumnManager : MonoBehaviour
    {
        public Deck deck;
        public DeckColumn deckColumn;
        public List<GameColumn> gameColumns;

        // Start is called before the first frame update
        void Start()
        {
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
                yield return new WaitForSeconds(0.1f);
                gameColumn.AddCardsListToList(deck.TakeCard(i));
                gameColumn.SetPosition();
                i++;
            }
            deckColumn.AddCardsListToList(deck.TakeCard(deck.cards.Count));
            OpenTopCard();
        }
        private void OpenTopCard()
        {
            foreach (GameColumn gameColumn in gameColumns)
            {
                int i = gameColumn.cards.Count - 1;
                gameColumn.cards[i].GetComponent<Card>().OpenCard();
            }
        }
    }
}

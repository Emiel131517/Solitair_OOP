using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Solitair
{
    public class ColumnManager : MonoBehaviour
    {
        [SerializeField]
        public DeckColumn deckColumn = null;
        [SerializeField]
        public Deck deck = null;
        [SerializeField]
        public List<GameColumn> gameColumns = null;

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(DealDelay());
        }

        // Update is called once per frame
        void Update()
        {

        }
        IEnumerator DealDelay()
        {
            yield return new WaitForSeconds(0.01f);
            StartCoroutine(Deal());
        }
        private IEnumerator Deal()
        {
            int i = 1;
            foreach (GameColumn gameColumn in gameColumns)
            {
                yield return new WaitForSeconds(0.1f);
                gameColumn.AddCardsToList(deck.TakeCard(i));
                gameColumn.SetPosition();
                i++;
            }
            deckColumn.AddCardsToList(deck.TakeCard(deck.cards.Count));
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

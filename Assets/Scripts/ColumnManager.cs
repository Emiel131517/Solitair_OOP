using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Solitair
{
    public class ColumnManager : MonoBehaviour
    {
        [SerializeField]
        private DeckColumn deckColumn;
        [SerializeField]
        private Deck deck;
        [SerializeField]
        private List<GameColumn> gameColumns;

        private bool dealt;
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
            yield return new WaitForSeconds(0.05f);
            Deal();
        }
        private void Deal()
        {
            for (int i = 0; i < gameColumns.Count; i++)
            {
                gameColumns[i].AddCardToList(deck.TakeCard(i + 1));
            }
            deckColumn.AddCardToList(deck.TakeCard(deck.cards.Count));
            dealt = true;
        }
    }
}

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
            Deal();
            test();
        }

        // Update is called once per frame
        void Update()
        {

        }
        private void Deal()
        {
            for (int i = 0; i < gameColumns.Count; i++)
            {
                gameColumns[i].AddCardToList(deck.TakeCard(i + 1));
            }
        }
        private void test()
        {
            deckColumn.AddCardToList(deck.TakeCard(deck.cards.Count));
        }
    }
}

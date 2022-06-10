using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solitair
{
    public class ColumnManager : MonoBehaviour
    {
        [SerializeField]
        private Deck deck;
        [SerializeField]
        private List<GameColumn> gameColumns;
        // Start is called before the first frame update
        void Start()
        {
            Deal();
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
    }
}

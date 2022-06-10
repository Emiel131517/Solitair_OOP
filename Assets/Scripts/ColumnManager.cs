using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solitair
{
    public class ColumnManager : MonoBehaviour
    {
        public Deck deck;
        public Column gameColumn1;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        private void Deal()
        {
            gameColumn1.AddCardToList(deck.TakeCard(1));
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solitair
{
    public class Column : MonoBehaviour
    {
        public List<Card> cards;
        void Start()
        {
            cards = new List<Card>();
        }

        // Update is called once per frame
        void Update()
        {

        }
        public void AddCardToList(List<Card> list)
        {
            foreach (Card card in list)
            {
                cards.Add(card);
            }
        }
    }
}
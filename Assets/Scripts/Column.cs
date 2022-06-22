using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solitair
{
    public class Column : MonoBehaviour
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
        public void AddCardsToList(List<GameObject> list)
        {
            foreach (GameObject card in list)
            {
                cards.Add(card);
            }
        }
        public void AddCardToTopOfList(GameObject card)
        {
            cards.Insert(cards.Count, card);
        }
        public virtual void SetPosition()
        {
            foreach (GameObject card in cards)
            {
                card.transform.position = this.transform.position;
            }
        }
    }
}
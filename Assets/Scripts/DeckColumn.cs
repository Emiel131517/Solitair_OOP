using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solitair
{
    public class DeckColumn : Column
    {
        private GameObject filledDeckBG;
        // Start is called before the first frame update
        void Start()
        {
            filledDeckBG = GameObject.Find("Deck_closed");
        }

        // Update is called once per frame
        void Update()
        {
            SetBackground();
        }
        public override void SetPosition()
        {
            foreach (GameObject card in cards)
            {
                card.transform.position = new Vector3(transform.position.x - 100, transform.position.y, transform.position.z);
            }
        }
        private void SetBackground()
        {
            if (cards.Count == 0)
            {
                filledDeckBG.SetActive(false);
            }
            else
            {
                filledDeckBG.SetActive(true);
            }
        }
        private void OnMouseDown()
        {
            Debug.Log("test");
        }
    }
}
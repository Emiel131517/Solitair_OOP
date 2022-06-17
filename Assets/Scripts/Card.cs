using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solitair
{
    public enum Suit { HEART, DIAMOND, CLUB, SPADE };
    public class Card : MonoBehaviour
    {
        private SpriteRenderer sprRend;
        public int value;
        public Suit suit;
        [SerializeField]
        private bool isOpen;

        private void Start()
        {
            sprRend = GetComponentInChildren<SpriteRenderer>();
            sprRend.sprite = sprRend.sprite;
        }
        private void Update()
        {

        }
        // Print the type and the value of the card
        public void PrintCardInfo()
        {
            Debug.Log(value.ToString() + suit.ToString());
        }
        // Set the sprite of the card
        public void SetSprite()
        {
            if (!isOpen)
            {
                sprRend.sprite = Resources.Load<Sprite>("Sprites/" + value.ToString() + suit.ToString());
                isOpen = true;
            }
        }
        // Set the value and the suit of the card
        public void SetCardStats(int v, Suit s)
        {
            value = v;
            suit = s;
        }
    }
}
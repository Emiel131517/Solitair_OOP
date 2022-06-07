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

        private void Start()
        {
            sprRend = GetComponentInChildren<SpriteRenderer>();
            SetSprite();
        }
        public void PrintCardInfo()
        {
            Debug.Log(value.ToString() + suit.ToString());
        }
        public void SetSprite()
        {
            sprRend.sprite = Resources.Load<Sprite>("Sprites/" + value.ToString() + suit.ToString());
        }
        public void SetCardStats(int v, Suit s)
        {
            value = v;
            suit = s;
        }
    }
}
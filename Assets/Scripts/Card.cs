﻿using System;
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
        public bool isOpen;
        public bool isSuitable;

        private void Start()
        {
            sprRend = GetComponentInChildren<SpriteRenderer>();
            sprRend.sprite = sprRend.sprite;
        }
        private void Update()
        {

        }
        // Print the type and the value of the card || FOR DEBUGGING
        public void PrintCardInfo()
        {
            Debug.Log(value.ToString() + suit.ToString());
        }
        // Set the sprite of the card when opened
        public void OpenCard()
        {
            if (!isOpen)
            {
                sprRend.sprite = Resources.Load<Sprite>("Sprites/" + value.ToString() + suit.ToString());
                isOpen = true;
            }
        }
        // Set the sprite of the card when closed
        public void CloseCard()
        {
            if (isOpen)
            {
                sprRend.sprite = Resources.Load<Sprite>("Sprites/card_back");
                isOpen = false;
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
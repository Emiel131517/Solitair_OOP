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
        private bool isBeingDragged;
        public bool isDraggeble;
        public int value;
        public Suit suit;
        [SerializeField]
        public bool isOpen;

        private void Start()
        {
            sprRend = GetComponentInChildren<SpriteRenderer>();
            sprRend.sprite = sprRend.sprite;
        }
        private void Update()
        {
            // Check if this card is being dragged and drag this card
            if (isBeingDragged)
            {
                DragCard();
            }
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
                isDraggeble = true;
            }
        }
        // Set the sprite of the card when closed
        public void CloseCard()
        {
            if (isOpen)
            {
                sprRend.sprite = Resources.Load<Sprite>("Sprites/card_back");
                isOpen = false;
                isDraggeble = false;
                Debug.Log("Card Closed");
            }
        }
        // Set the value and the suit of the card
        public void SetCardStats(int v, Suit s)
        {
            value = v;
            suit = s;
        }
        // Drag this card
        private void DragCard()
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePos.x, mousePos.y, -5);
        }
    }
}
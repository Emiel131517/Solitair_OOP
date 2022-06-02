using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solitair
{
    public enum Rank { HEART, DIAMOND, CLUB, SPADE };
    public class Card : MonoBehaviour
    {
        private SpriteRenderer sprRend;
        private GameObject obj;
        private int value;
        private Rank rank;

        public Card(int v, Rank r)
        {
            value = v;
            rank = r;

            obj = new GameObject(value.ToString() + rank.ToString());
            obj.AddComponent<Card>();
            obj.AddComponent<SpriteRenderer>();

            sprRend = GetComponent<SpriteRenderer>();
        }
        public void PrintCardInfo()
        {
            Debug.Log(value + ": " + rank);
        }
        private void AttachSprites()
        {

        }
    }
}
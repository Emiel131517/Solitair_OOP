using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solitair
{
    public enum Rank { HEART, DIAMOND, CLUB, SPADE };
    public class Card
    {
        private int value;
        private Rank rank;
        private Sprite front;
        private Sprite back;

        public Card(int v, Rank r)
        {
            value = v;
            rank = r;
        }
        public void PrintCardInfo()
        {
            Debug.Log(value + ": " + rank);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solitair
{
    public class DeckColumn : Column
    {
        // Start is called before the first frame update
        void Start()
        {
            SetPosition();
        }

        // Update is called once per frame
        void Update()
        {

        }
        public override void SetPosition()
        {
            base.SetPosition();
        }
    }
}
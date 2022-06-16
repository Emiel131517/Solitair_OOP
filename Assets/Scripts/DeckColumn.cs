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
            
        }

        // Update is called once per frame
        void Update()
        {
            SetPosition();
        }
        public override void SetPosition()
        {
            float zOffset = 0.03f;
            foreach (GameObject card in cards)
            {
                card.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + zOffset);
                zOffset -= 0.3f;
            }
        }
    }
}
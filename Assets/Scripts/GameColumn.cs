using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solitair {
    public class GameColumn : Column
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
        private void SetPosition()
        {
            foreach (GameObject card in cards)
            {
                card.transform.position = transform.position;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solitair {
    public class GameColumn : Column
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        public override void SetPosition()
        {
            float yOffset = 0;
            float zOffset = 0.03f;
            foreach (GameObject card in cards)
            {
                card.transform.position = new Vector3(transform.position.x, transform.position.y + yOffset, transform.position.z + zOffset);
                yOffset -= 0.25f;
                zOffset -= 0.3f;
            }
        }
    }
}

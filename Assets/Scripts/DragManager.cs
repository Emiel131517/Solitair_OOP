using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solitair 
{
    public class DragManager : MonoBehaviour
    {
        private LayerMask cardMask;
        private LayerMask gameColumnMask;
        private bool isDragging;
        private GameObject selectedObj;
        // Start is called before the first frame update
        void Start()
        {
            cardMask = LayerMask.GetMask("Card");
            gameColumnMask = LayerMask.GetMask("GameColumn");
        }

        // Update is called once per frame
        void Update()
        {
            CheckForDragebleCard();
            if (isDragging)
            {
                DragCard(selectedObj);
            }
        }
        // Check for a card to drag
        private void CheckForDragebleCard()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 10, cardMask);
                if (hit.collider != null)
                {
                    Card card = hit.collider.gameObject.GetComponent<Card>();
                    if (card != null)
                    {
                        if (card.isOpen)
                        {
                            selectedObj = card.gameObject;
                            isDragging = true;
                        }
                    }
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                isDragging = false;
                DropToColumn();
            }
        }
        // Drag the given card
        private void DragCard(GameObject obj)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            obj.transform.position = new Vector3(mousePos.x, mousePos.y, -5);
        }
        // Drop the card to the new column if possible, otherwise return it to the old column
        private void DropToColumn()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 10, gameColumnMask);

            if (selectedObj != null)
            {
                if (hit.collider != null)
                {
                    GameColumn gameColumn = hit.collider.gameObject.GetComponent<GameColumn>();
                    if (gameColumn != null)
                    {
                        if (gameColumn.CheckIfSuitable(selectedObj))
                        {
                            Card card = selectedObj.GetComponent<Card>();

                            card.parentColumn.cards[card.parentColumn.cards.Count - 2].GetComponent<Card>().OpenCard();
                            card.parentColumn.RemoveCard(selectedObj);
                            gameColumn.AddCardToTopOfList(selectedObj);
                        }
                    }
                }
                selectedObj.GetComponent<Card>().parentColumn.SetPosition();
                selectedObj = null;
            }
        }
    }
}

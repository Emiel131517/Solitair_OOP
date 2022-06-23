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
        private List<GameObject> selectedObjs;
        // Start is called before the first frame update
        void Start()
        {
            cardMask = LayerMask.GetMask("Card");
            gameColumnMask = LayerMask.GetMask("GameColumn");
            selectedObjs = new List<GameObject>();
        }

        // Update is called once per frame
        void Update()
        {
            CheckForDragebleCard();
            if (isDragging)
            {
                DragCard(selectedObjs) ;
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
                    if (card != null && card.isOpen)
                    {
                        int cardIndex = card.parentColumn.cards.IndexOf(hit.collider.gameObject);
                        if (card.parentColumn.cards.Count - 1 == cardIndex ||
                            card.parentColumn.cards.Count - card.parentColumn.cards.Count + cardIndex == cardIndex)
                        {
                            Debug.Log("test");
                            selectedObjs.Add(card.gameObject);
                            isDragging = true;
                        }
                        // else get all the indexed above the hit card and add them to the list too
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
        private void DragCard(List<GameObject> objs)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            foreach(GameObject obj in objs)
            {
                obj.transform.position = new Vector3(mousePos.x, mousePos.y, -5);
            }
        }
        // Drop the card to the new column if possible, otherwise return it to the old column
        private void DropToColumn()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 10, gameColumnMask);

            if (selectedObjs.Count != 0)
            {
                if (hit.collider != null)
                {
                    GameColumn gameColumn = hit.collider.gameObject.GetComponent<GameColumn>();
                    if (gameColumn != null)
                    {
                        foreach (GameObject obj in selectedObjs)
                        {
                            if (gameColumn.CheckIfSuitable(obj))
                            {
                                Card card = obj.GetComponent<Card>();

                                card.parentColumn.cards[card.parentColumn.cards.Count - 2].GetComponent<Card>().OpenCard();
                                card.parentColumn.RemoveCard(obj);
                                gameColumn.AddCardToTopOfList(obj);
                            }
                        }
                    }
                }
                foreach (GameObject obj in selectedObjs)
                {
                    obj.GetComponent<Card>().parentColumn.SetPosition();
                }
                selectedObjs.Clear();
            }
        }
    }
}

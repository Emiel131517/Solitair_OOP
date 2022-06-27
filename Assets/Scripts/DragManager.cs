using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragManager : MonoBehaviour
{
    private LayerMask cardMask;
    private LayerMask columnMask;
    private bool isDragging;
    private List<GameObject> selectedObjs;
    // Start is called before the first frame update
    void Start()
    {
        cardMask = LayerMask.GetMask("Card");
        columnMask = LayerMask.GetMask("Column");
        selectedObjs = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckForDragebleCard();
        if (isDragging)
        {
            DragCard(selectedObjs);
        }
    }
    // Check for a card to drag
    private void CheckForDragebleCard()
    {
        // Check if clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Create and send a raycast that only hits object with the Card layermask
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 10, cardMask);
            // Check if the raycast hit something
            if (hit.collider != null)
            {
                // Card is the hit card
                Card card = hit.collider.gameObject.GetComponent<Card>();
                // Check if the raycast hit a card and if the hit card is open
                if (card != null && card.isOpen)
                {
                    // Create an index of the card hit by the raycast
                    int cardIndex = card.parentColumn.cards.IndexOf(hit.collider.gameObject);
                    // Check if the card belongs to the list of a GameColumn
                    if (card.parentColumn.GetType() == typeof(GameColumn))
                    {
                        // Check if the hit card is not the last card in the list from the column it was in
                        if (card.parentColumn.cards.Count > cardIndex)
                        {
                            // Add the hit card to the list of selected objects
                            selectedObjs.Add(card.gameObject);
                            // Forloop for all the cards above the card hit by the raycast
                            for (int i = cardIndex; i < card.parentColumn.cards.Count; i++)
                            {
                                // Add the other cards to the selected objects list
                                GameObject obj = card.parentColumn.cards[i];
                                selectedObjs.Add(obj);
                            }
                            isDragging = true;
                        }
                    }
                    if (card.parentColumn.GetType() == typeof(DeckColumn))
                    {
                        if (card.parentColumn.cards.Count - card.parentColumn.cards.Count + cardIndex == cardIndex)
                        {
                            selectedObjs.Add(card.gameObject);
                            isDragging = true;
                        }
                    }
                    // If there is only one card
/*                        else
                    {
                        selectedObjs.Add(card.gameObject);
                        isDragging = true;
                    }*/
                    /*                        if (card.parentColumn.cards.Count - 1 == cardIndex ||
                        card.parentColumn.cards.Count - card.parentColumn.cards.Count + cardIndex == cardIndex)
                                            {
                                                selectedObjs.Add(card.gameObject);
                                                isDragging = true;
                                            }*/
                }
            }
        }
        // Check if the player stopped dragging
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            DropToColumn();
        }
    }
    // Drag the given card
    private void DragCard(List<GameObject> objs)
    {
        // Set all the cards from the selected objects list to the position of the mouse
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        foreach (GameObject obj in objs)
        {
            obj.transform.position = new Vector3(mousePos.x, mousePos.y, -5);
        }
    }
    // Drop the card to the new column if possible, otherwise return it to the old column
    private void DropToColumn()
    {
        // Create a raycast that only hits columns
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 10, columnMask);

        // Check if ther are items in the selected objects list
        if (selectedObjs.Count != 0)
        {
            // Check if the raycast hit a collider
            if (hit.collider != null)
            {
                // Create a gamecolumn from the raycast hit and check if the gamecolumn is not null
                GameColumn gameColumn = hit.collider.gameObject.GetComponent<GameColumn>();
                if (gameColumn != null)
                {
                    foreach (GameObject obj in selectedObjs)
                    {
                        // Check if the dropped card fits ontop of the other card in the GameColumn
                        if (gameColumn.CheckIfSuitable(obj))
                        {
                            // Create a card from the object in the selected objects list
                            Card card = obj.GetComponent<Card>();

                            if (card.parentColumn.cards.Count > 1)
                            {
                                // Open a card on the old gamecolumn and remove the dragged cards from that list
                                card.parentColumn.cards[card.parentColumn.cards.Count - 2].GetComponent<Card>().OpenCard();
                                card.parentColumn.RemoveCard(obj);
                            }
                            else
                            {
                                card.parentColumn.cards.Clear();
                            }
                            // Add the cards to the top of the new list
                            gameColumn.AddCardToTopOfList(obj);
                        }
                    }
                }
            }
            // Always empty the list of selected objects even if no collider was hit
            foreach (GameObject obj in selectedObjs)
            {
                obj.GetComponent<Card>().parentColumn.SetPosition();
            }
            selectedObjs.Clear();
        }
    }
}
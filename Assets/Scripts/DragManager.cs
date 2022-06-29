using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragManager : MonoBehaviour
{
    private LayerMask cardMask;
    private LayerMask columnMask;
    private bool isDragging;
    [SerializeField] private List<GameObject> selectedObjs;
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
            // check if it hit a collider
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 10, cardMask);
            if (hit.collider != null)
            {
                // Create a card from the hit collider
                // Check if the card is assigned and if the card is open
                Card card = hit.collider.gameObject.GetComponent<Card>();
                if (card != null && card.isOpen)
                {

                    // Get the index of the card and assign it this cardIndex
                    // Check if the parent column of the card is a GameColumn
                    int cardIndex = card.parentColumn.cards.IndexOf(hit.collider.gameObject);
                    if (card.parentColumn.GetComponent<GameColumn>())
                    {
                        // Check if it is not the last card 
                        // Add the cards to the list of dragging cards
                        if (card.parentColumn.cards.Count > cardIndex)
                        {
                            for (int i = cardIndex; i < card.parentColumn.cards.Count; i++)
                            {
                                GameObject obj = card.parentColumn.cards[i];
                                selectedObjs.Add(obj);
                            }
                            isDragging = true;
                        }
                        else
                        {
                            selectedObjs.Add(card.gameObject);
                        }
                    }

                    // Check if you take a card from a deckcolumn
                    // Check the index and add it to the list of selected objects
                    if (card.parentColumn.GetComponent<DeckColumn>())
                    {
                        if (card.parentColumn.cards.Count - card.parentColumn.cards.Count + cardIndex == cardIndex)
                        {
                            selectedObjs.Add(card.gameObject);
                            isDragging = true;
                        }
                    }

                    // Check if you take a card from a finishcolumn
                    // Lower the indexvalue from the finishcolumn
                    // Add the card to the list of selected objects
                    if (card.parentColumn.GetComponent<FinishColumn>())
                    {
                        card.parentColumn.GetComponent<FinishColumn>().LowerIndexValue(1);
                        selectedObjs.Add(card.gameObject);
                        isDragging = true;
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
        float yoffset = 0;
        float zoffset = 0;
        foreach (GameObject obj in objs)
        {
            obj.transform.position = new Vector3(mousePos.x, mousePos.y + yoffset, -5 + zoffset);
            yoffset -= 0.35f;
            zoffset -= 0.1f;
        }
    }
    // Drop the card to the new column if possible, otherwise return it to the old column
    private void DropToColumn()
    {
        // Create a raycast that only hits columns
        // Check if ther are items in the selected objects list
        // Check if the raycast hit a collider
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 10, columnMask);
        if (selectedObjs.Count != 0)
        {
            if (hit.collider != null)
            {
                // Create a gamecolumn from the raycast hit
                // check if the column is not null
                Column column = hit.collider.gameObject.GetComponent<Column>();
                if (column != null)
                {
                    // Loop though the list of the selected objects
                    // Check if the card in the selected objects list fits ontop of the other card in the column
                    foreach (GameObject obj in selectedObjs)
                    {
                        if (column.CheckIfSuitable(obj))
                        {
                            // Create a card from the current object in the loop
                            // Check if there rare more than 1 cards in the parent list of the card
                            Card card = obj.GetComponent<Card>();
                            if (card.parentColumn.cards.Count > 1)
                            {
                                // Open a card on the old column a
                                // Remove the dragged cards from that list
                                if (!card.parentColumn.GetComponent<DeckColumn>())
                                {
                                    card.parentColumn.cards[card.parentColumn.cards.Count - 2].GetComponent<Card>().OpenCard();
                                }
                                card.parentColumn.RemoveCard(obj);
                            }
                            else
                            {
                                // Just clear the list instead of removing.
                                card.parentColumn.cards.Clear();
                            }
                            // Add the cards to the top of the new list
                            column.AddCardToTopOfList(obj);
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
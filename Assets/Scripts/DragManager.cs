using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solitair 
{
    public class DragManager : MonoBehaviour
    {
        private LayerMask cardMask;
        private bool isDragging;
        [SerializeField]
        private Vector3 oldPos;
        [SerializeField]
        private GameObject selectedObj;
        // Start is called before the first frame update
        void Start()
        {
            cardMask = LayerMask.GetMask("Card");
        }

        // Update is called once per frame
        void Update()
        {
            CheckForDragebleObject();
        }
        private void CheckForDragebleObject()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 10, cardMask);
                if (hit.collider.gameObject.GetComponent<Card>().isOpen)
                {
                    oldPos = hit.collider.gameObject.transform.position;
                    selectedObj = hit.collider.gameObject;
                    isDragging = true;
                }
            }
            if (isDragging)
            {
                DragObject(selectedObj);
            }
            if (Input.GetMouseButtonUp(0))
            {
                isDragging = false;
                ReleasedButton();
            }
        }
        private void DragObject(GameObject obj)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            obj.transform.position = new Vector3(mousePos.x, mousePos.y, -5);
        }
        private void ReleasedButton()
        {
            selectedObj.transform.position = oldPos;
            CheckAboveWhatColumn();
            selectedObj = null;
        }
        private void CheckAboveWhatColumn()
        {
            LayerMask gameColumnMask = LayerMask.GetMask("GameColumn");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 10, gameColumnMask);
            GameColumn gameColumn = hit.collider.gameObject.GetComponent<GameColumn>();
            if (gameColumn.CheckIfSuitable(selectedObj))
            {
                gameColumn.AddCardToTopOfList(selectedObj);
                gameColumn.SetPosition();
            }
        }
    }
}

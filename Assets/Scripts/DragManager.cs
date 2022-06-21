using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solitair 
{
    public class DragManager : MonoBehaviour
    {
        private bool isDragging;
        [SerializeField]
        private GameObject selectedObj;
        // Start is called before the first frame update
        void Start()
        {

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
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
                if (hit.collider.gameObject.GetComponent<Card>().isDraggeble)
                {
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
            }
        }
        private void DragObject(GameObject obj)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            obj.transform.position = new Vector3(mousePos.x, mousePos.y, -2);
        }
    }
}

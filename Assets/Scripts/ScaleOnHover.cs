using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleOnHover : MonoBehaviour
{
    private Vector2 scale;

    private void Start()
    {
        scale = transform.localScale;
    }
    public void IncreaseSize()
    {
        transform.localScale = new Vector2(transform.localScale.x + 0.25f, transform.localScale.y + 0.25f);
    }
    public void DecreaseSize()
    {
        transform.localScale = scale;
    }
}

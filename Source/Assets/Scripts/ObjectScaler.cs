using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectScaler : MonoBehaviour
{
    public void IncreaseSize(GameObject obj, float amount)
    {
        obj.transform.localScale = new Vector2(transform.localScale.x + amount, transform.localScale.y + amount);
    }
    public void DecreaseSize(GameObject obj, float amount)
    {
        obj.transform.localScale = new Vector2(transform.localScale.x - amount, transform.localScale.y - amount);
    }
}

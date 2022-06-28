﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishColumn : Column
{
    private bool isFinished;
    private int indexValue;
    [SerializeField] private Suit suit;
    // Start is called before the first frame update
    void Start()
    {
        indexValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void SetPosition()
    {
        float zOffset = -0.03f;
        foreach (GameObject card in cards)
        {
            card.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + zOffset);
            zOffset -= 0.3f;
        }
    }
    public void LowerIndexValue(int value)
    {
        if (indexValue > 0)
        {
            indexValue -= value;
        }
    }
    public override bool CheckIfSuitable(GameObject obj)
    {
        Card card = obj.GetComponent<Card>();
        if (card.suit == suit)
        {
            if (card.value == indexValue)
            {
                indexValue++;
                return true;
            }
        }
        return false;
    }
}
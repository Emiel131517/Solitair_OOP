using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private List<FinishColumn> finishColumns;
    private GameObject winScreen;
    public List<GameObject> cards;
    [SerializeField] private bool canAutoComplete;
    private int openCards;
    void Start()
    {
        cards = new List<GameObject>();
        finishColumns = new List<FinishColumn>();
        winScreen = GameObject.Find("WinScreen");
        openCards = 0;
        for (int i = 0; i < 4; i++)
        {
            finishColumns.Add(GameObject.Find("Finish_" + i.ToString()).GetComponent<FinishColumn>());
        }
        winScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (finishColumns[0].isFinished && finishColumns[1].isFinished && 
            finishColumns[2].isFinished && finishColumns[3].isFinished)
        {
            Finish();
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Finish();
        }
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            AutoComplete();
        }
        if (CanAutoComplete())
        {
            AutoComplete();
        }
        
    }
    private void Finish()
    {
        winScreen.SetActive(true);
        Time.timeScale = 0;
    }
    private bool CanAutoComplete()
    {
        openCards = 0;
        for (int i = 0; i < cards.Count; i++)
        {
            if (cards[i].GetComponent<Card>().IsOpen)
            {
                openCards++;
            }
        }
        if (openCards == 52)
        {
            return true;
        }
        return false;
    }
    private void AutoComplete()
    {
        Finish();
        Debug.Log("Autocomplete");
    }
}

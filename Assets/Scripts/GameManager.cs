using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private List<FinishColumn> finishColumns;
    private GameObject winScreen;
    void Start()
    {
        finishColumns = new List<FinishColumn>();
        winScreen = GameObject.Find("WinScreen");
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
    }
    private void Finish()
    {
        winScreen.SetActive(true);
    }
}

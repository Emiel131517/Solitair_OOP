using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeText : MonoBehaviour
{
    private TMP_Text txt;
    private float seconds;
    private float minutes;
    private float time;
    void Start()
    {
        seconds = 0;
        minutes = 0;
        time = 0;
        txt = gameObject.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        seconds = time%60;
        minutes = Mathf.Floor(time / 60);

        txt.text = "Time playing: " + minutes + ":" + (int)seconds;
    }
}

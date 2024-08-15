using System;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;
using UnityEngine.UI;

public class TimeManerer : MonoBehaviour
{
    public float timeLimit = 90;
    private int min;
    private int sec;

    public Text timeText;

    // Start is called before the first frame update
    void Start()
    {
       timeText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timeLimit -= Time.deltaTime;
        
        min = (int)timeLimit / 60;
        sec = (int)timeLimit % 60;
        timeText.text = min.ToString("00") + ":" + sec.ToString("00");

        if(timeLimit <= 0 )
        {
            Debug.Log("時間切れ");
        }
    }

}
/*
 * タイムマネージャーは死んだ
 */
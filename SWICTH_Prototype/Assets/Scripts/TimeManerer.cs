using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

public class TimeManerer : MonoBehaviour
{
    [SerializeField] float CountDownTime = 5.0f;//制限時間
    private float CurrentTime; //現在の時間

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartCountDown());//コルーチン
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartCountDown()//任意秒のカウントダウン
    {
        while(true)
        {
            CurrentTime = CountDownTime;

            while (CurrentTime > 0)
            {
                Debug.Log(CurrentTime);
                yield return new WaitForSeconds(1.0f);
                CurrentTime--;
            }

            Debug.Log("5秒経過");
            yield return new WaitForSeconds(1.0f); // 1秒待ってから再度カウントダウンを開始

        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using System.Security.Cryptography;

public class GameManager : MonoBehaviour
{
    bool toStage = false;
    [SerializeField] float fadeDuration = 1f;
    [SerializeField] float displayImageDroup = 1f;
    [SerializeField] CanvasGroup canvasGroup;

    float m_Timer;

    [SerializeField] Canvas canvas;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //収穫(成長)のボタン操作
        if (Input.GetKeyUp(KeyCode.L))
        {
            Debug.Log("収穫処理L");
            //中に処理を書く
           

         }

        if (toStage)
        {
            FadeOut();
        }
    }

    //機能していない。
    //void OnTriggerEnter(Collider other)
    //{
    //    for(int i = 0; i < decision.Length; i++)
    //    {
    //        //回したときに判定。
    //        if (other.CompareTag("Sunny"))
    //        {
    //            Debug.Log("天気" + decision[i].name + "はSunny");
    //        }
    //        if (other.CompareTag("Rainy"))
    //        {
    //            Debug.Log("天気" + decision[i].name + "はRainy");
    //        }
    //        if (other.CompareTag("Thunder"))
    //        {
    //            Debug.Log("天気" + decision[i].name + "はThunder");
    //        }
    //    }

    //}

    public void StartButton()
    {
        toStage = true;
    }

    public void TitlleButton()
    {
        SceneManager.LoadScene("titlle");//移動先のシーン名を入力
    }

    public void EndButton()
    {
        SceneManager.LoadScene("end");//移動先のシーン名を入力
    }

    public void ExitButton()//ゲーム自体の終了
    {

        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void FadeOut()
    {
        Debug.Log("作動");
        //canvas.sortingOrder = 2;

        m_Timer += Time.deltaTime;

        canvasGroup.alpha = m_Timer / fadeDuration;

        //Debug.Log(m_Timer);
        //Debug.Log(fadeDuration + displayImageDroup);

        if(m_Timer > fadeDuration+displayImageDroup)
        {
            Debug.Log("完了");
            SceneManager.LoadScene("SampleScene");
        }
    }
}

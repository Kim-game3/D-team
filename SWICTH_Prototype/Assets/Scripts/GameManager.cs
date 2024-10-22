using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using System.Security.Cryptography;
using UnityEditor;
using System.Security;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    bool toStage = false;
    [SerializeField] float fadeDuration = 1f;
    [SerializeField] float displayImageDroup = 1f;
    [SerializeField] CanvasGroup canvasGroup;

    float m_Timer;

    [SerializeField] Canvas canvas;

    public sunnyGrow sunnyGrow;
    [SerializeField] rainGrow rainGrow;
    [SerializeField] thunderGrow thunderGrow;
    [SerializeField] SetTriangleScript setTriangleScript;

    public GameObject[] seedBody;
    public GameObject[] sunSeeds;
    public GameObject[] rainSeeds;
    public GameObject[] thunderSeeds;
    int[] count;
    public float Position = 0;
    bool setPosition;

    Vector3[] spawnPosition = new Vector3[5];

    // Start is called before the first frame update
    void Start()
    {
        setPosition = true;
        count = new int[seedBody.Length];
    }

    // Update is called once per frame
    void Update()
    {
        if(setPosition)
        {
            setSeedPosition();
        }
        //収穫(成長)のボタン操作
        if (Input.GetKeyUp(KeyCode.L))
        {
            Debug.Log("L押した");
            //S_Readyの参照がうまくいきません。
            
            Debug.Log("天気は晴れ");
            for (int i = 0; i < seedBody.Length; i++)
            {
                if (seedBody[i] != null)
                {
                    sunnyGrow script = seedBody[i].GetComponent<sunnyGrow>();
                    if (script != null)
                    {
                        //Debug.Log("成功"+script.S_Ready);

                        if(script.S_Ready == true)
                        {
                            if (seedBody[i].tag == "Sunny")
                            {
                                //Debug.Log("植物もはれ");
                                //Debug.Log("成長");

                                Destroy(seedBody[i]);
                                count[i]++;

                                spawnPosition[i].y = Position;

                                //Debug.Log("最後の確認"+spawnPosition[i]);
                                seedBody[i] = Instantiate(sunSeeds[count[i]], spawnPosition[i], Quaternion.identity);
                                if (count[i] == 2)
                                {
                                    count[i] = -1;
                                }
                            }
                        }
                    }
                }
            }
        }

        if (toStage)
        {
            FadeOut();
        }
    }

    public void setSeedPosition()
    {
        for (int i = 0; i < seedBody.Length; i++)
        {
            //Debug.Log("入れる前" + spawnPosition[i]);
            count[i] = 0;
            if (seedBody[i] != null)//スタート時点ではessdがnull
            {
                spawnPosition[i] = seedBody[i].transform.position;
                //Debug.Log("入れたあと" + spawnPosition[i]);
                setPosition = false;
            }
        }
    }

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

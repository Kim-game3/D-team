using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using System.Security.Cryptography;
using UnityEditor;
using System.Security;
using UnityEngine.UIElements;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;

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

    private bool pause;
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private GameObject pausePanel;
    private int scoreCount = 0;
    private bool codeCheck = true;

    static public bool PAUSE = false;
    Vector3[] spawnPosition = new Vector3[5];

    // Start is called before the first frame update
    void Start()
    {
        setPosition = true;
        count = new int[seedBody.Length];
        pause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(setPosition)
        {
            setSeedPosition();
        }
        //���n(����)�̃{�^������
        if (Input.GetKeyUp(KeyCode.L) || Input.GetKeyDown(KeyCode.B))//Return���Ɠ��������B�v���؁B
        {
            for (int i = 0; i < seedBody.Length; i++)
            {
                if (seedBody[i] != null)
                {
                    Sunny(i);
                    Rain(i);
                    Thunder(i);
                }
            }
        }

        if(Input.GetKeyUp(KeyCode.Escape))
        {
            if(pause == false)
            {
                pauseGame();
            }
            else
            {
                resumeGame();
            }
        }
        //if (Input.GetKey(KeyCode.Return))//���n����p
        //{

        //}


        if (toStage)
        {
            FadeOut();
        }

        if (codeCheck)
        {
            codeCheck = false;
            inScore(scoreCount);
        }
    }

    public void Sunny(int i)
    {
        sunnyGrow script = seedBody[i].GetComponent<sunnyGrow>();
        if (script != null)
        {
            if (script.S_Ready == true)
            {
                if (seedBody[i].tag == "Sunny")
                {
                    Destroy(seedBody[i]);
                    count[i]++;
                    if (count[i] >= 2)
                    {
                        count[i] = 2;
                        script.S_Harvest = true;
                    }

                    spawnPosition[i].y = Position;
                    seedBody[i] = Instantiate(sunSeeds[count[i]], spawnPosition[i], Quaternion.identity);

                    if(script.S_Harvest == true)
                    {
                        StartCoroutine(Harvest(i));
                    }

                    
                }
            }
        }
    }

    public void Rain(int i)
    {
        rainGrow script = seedBody[i].GetComponent<rainGrow>();
        if (script != null)
        {
            if (script.R_Ready == true)
            {
                if (seedBody[i].tag == "Rainy")
                {
                    Destroy(seedBody[i]);
                    count[i]++;

                    if (count[i] >= 2)
                    {
                        count[i] = 2;
                        script.R_Harvest = true;
                    }
                    spawnPosition[i].y = Position;
                    seedBody[i] = Instantiate(rainSeeds[count[i]], spawnPosition[i], Quaternion.identity);

                    if (script.R_Harvest == true)
                    {
                        StartCoroutine(Harvest(i));
                    }
                }
            }
        }
    }

    public void Thunder(int i)
    {
        thunderGrow script = seedBody[i].GetComponent<thunderGrow>();
        if (script != null)
        {
            if (script.T_Ready == true)
            {
                if (seedBody[i].tag == "Thunder")
                {
                    Destroy(seedBody[i]);
                    count[i]++;

                    if (count[i] >= 2)
                    {
                        count[i] = 2;
                        script.T_Harvest = true;
                    }
                    spawnPosition[i].y = Position;
                    seedBody[i] = Instantiate(thunderSeeds[count[i]], spawnPosition[i], Quaternion.identity);

                    if (script.T_Harvest == true)
                    {
                        StartCoroutine(Harvest(i));
                    }
                }
            }
        }
    }


    private IEnumerator Harvest(int i)
    {
        yield return new WaitForSeconds(1.0f); ;
        Destroy(seedBody[i]);
        scoreCount++;
        //Score.score += 100;
    }

    public void setSeedPosition()
    {
        for (int i = 0; i < seedBody.Length; i++)
        {
            //Debug.Log("�����O" + spawnPosition[i]);
            count[i] = 0;
            if (seedBody[i] != null)//�X�^�[�g���_�ł�essd��null
            {
                spawnPosition[i] = seedBody[i].transform.position;
                //Debug.Log("���ꂽ����" + spawnPosition[i]);
                setPosition = false;
            }
        }
    }

    public void inScore(int i)
    {
        switch (i)
        {
            case 0:Score.score += 0;
                break;
            case 1:
                Score.score += 100;
                break;
            case 2:
                Score.score += 300;
                break;
            case 3:
                Score.score += 600;
                break;
            case 4:
                Score.score += 1200;
                break;
            case 5:
                Score.score += 3000;
                break;
        }

        scoreCount = 0;
        codeCheck = true;
    }

    public void StartButton()
    {
        toStage = true;
    }

    public void TitlleButton()
    {
        SceneManager.LoadScene("titlle");//�ړ���̃V�[���������
    }

    public void EndButton()
    {
        SceneManager.LoadScene("end");//�ړ���̃V�[���������
    }

    public void ExitButton()//�Q�[�����̂̏I��
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void pauseGame()
    {
        Debug.Log("�|�[�Y");
        PAUSE = true;
        pauseUI.SetActive(true);
        pausePanel.SetActive(true);
        Time.timeScale = 0;
        pause = true;
    }

    public void resumeGame()
    {
        Debug.Log("�|�[�Y����");
        PAUSE = false;
        pauseUI.SetActive(false);
        pausePanel.SetActive(false);
        Time.timeScale = 1.0f;
        pause = false;
    }

    public void FadeOut()
    {
        Debug.Log("�쓮");
        m_Timer += Time.deltaTime;

        canvasGroup.alpha = m_Timer / fadeDuration;

        //Debug.Log(m_Timer);
        //Debug.Log(fadeDuration + displayImageDroup);

        if(m_Timer > fadeDuration+displayImageDroup)
        {
            Debug.Log("����");
            SceneManager.LoadScene("mainGame");
        }
    }
}

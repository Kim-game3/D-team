using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

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
        //canvas = GetComponent<Canvas>();
        //canvas.sortingOrder = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(toStage)
        {
            FadeOut();
        }
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

    public void FadeOut()
    {
        Debug.Log("�쓮");
        //canvas.sortingOrder = 2;

        m_Timer += Time.deltaTime;

        canvasGroup.alpha = m_Timer / fadeDuration;

        //Debug.Log(m_Timer);
        //Debug.Log(fadeDuration + displayImageDroup);

        if(m_Timer > fadeDuration+displayImageDroup)
        {
            Debug.Log("����");
            SceneManager.LoadScene("SampleScene");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton()
    {
        SceneManager.LoadScene("SampleScene");//�ړ���̃V�[���������
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
}

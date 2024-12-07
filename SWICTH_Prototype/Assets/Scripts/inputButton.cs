using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class inputButton : MonoBehaviour
{
    private int selectIndex= 0;
    public TextMeshProUGUI[] menuItems;
    public RawImage[] Yazirusi;
    public Color normal = Color.white;
    public Color select = Color.red;
    public bool quickSeleckTitlle;
    public bool quickSeleckResult;
    public bool quickSeleckPause;
    [SerializeField] GameManager GM;
    private bool stopStick;

    // Start is called before the first frame update
    void Start()
    {
        stopStick = true;
        UpdateMenuVisuals();
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();

        if(Input.GetAxis("L_Stick_V") < 0)
        {
            Debug.Log("��ɓ�����");
        }
        if (Input.GetAxis("L_Stick_V") > 0)
        {
            Debug.Log("���ɓ�����");
        }
        if(Input.GetAxis("L_Stick_V") == 0)
        {
            stopStick = true;
        }
        //float lsv = Input.GetAxis("L_Stick_V");
        //if (lsv != 0)
        //{
        //    Debug.Log("L stick:" + "," + lsv);
        //}
    }

    void HandleInput()
    {
        // ��L�[�őI����Ɉړ�
        if ((stopStick && Input.GetAxis("L_Stick_V") < 0) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            selectIndex = (selectIndex - 1 + menuItems.Length) % menuItems.Length;
            stopStick = false;
            UpdateMenuVisuals();
        }

        // ���L�[�őI�����Ɉړ�
        if ((stopStick && Input.GetAxis("L_Stick_V") > 0) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            selectIndex = (selectIndex + 1) % menuItems.Length;
            stopStick = false;
            UpdateMenuVisuals();
        }

        // Enter�L�[�őI���m��
        if (Input.GetButtonDown("Decision") || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if(quickSeleckTitlle)
            {
                ExecuteSelectedOption_Titlle();
            }
            if (quickSeleckResult)
            {
                ExecuteSelectedOption_Result();
            }
            if (quickSeleckPause)
            {
                ExecuteSelectedOption_Pause();
            }
        }
    }

    void UpdateMenuVisuals()
    {
        for (int i = 0; i < menuItems.Length; i++)
        {
            if (i == selectIndex)
            {
                menuItems[i].color = select;
                Yazirusi[i].enabled = true;
            }
            else
            {
                menuItems[i].color = normal;
                Yazirusi[i].enabled = false;
            }
        }
    }

    void ExecuteSelectedOption_Titlle()
    {
        switch (selectIndex)
        {
            case 0: // �u�X�^�[�g�v
                Debug.Log("�Q�[���X�^�[�g");
                GM.StartButton();
                break;
            case 1: // �u�V�ѕ��v
                Debug.Log("�V�ѕ�����");
                break;
            case 2: // �u�I���v
                Debug.Log("�Q�[���I��");
                GM.ExitButton();
                break;
        }
    }

    void ExecuteSelectedOption_Result()
    {
        switch (selectIndex)
        {
            case 0: // �u�X�^�[�g�v
                Debug.Log("�Q�[���X�^�[�g");
                GM.TitlleButton();
                break;
            case 1: // �u�I���v
                Debug.Log("�Q�[���ŏI��");
                GM.ExitButton();
                break;
        }
    }

    void ExecuteSelectedOption_Pause()
    {
        if(GM._pause.activeSelf)
        {
            switch (selectIndex)
            {
                case 0: // �u�X�^�[�g�v
                    Debug.Log("�V�ѕ�");

                    break;
                case 1: // �u�I���v
                    Debug.Log("�ăX�^�[�g");
                    SceneManager.LoadScene("mainGame");
                    break;
                case 2: // �u�I���v
                    Debug.Log("�^�C�g����");
                    GM.TitlleButton();
                    break;
            }
        }
        
    }
}

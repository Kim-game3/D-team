using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class inputButton : MonoBehaviour
{
    private int selectIndex= 0;
    public TextMeshProUGUI[] menuItems;
    public RawImage[] Yazirusi;
    public Color normal = Color.white;
    public Color select = Color.red;
    public bool quickSeleckTitlle;
    public bool quickSeleckResult;
    [SerializeField] GameManager GM;

    // Start is called before the first frame update
    void Start()
    {
        UpdateMenuVisuals();
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        // ��L�[�őI������Ɉړ�
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            selectIndex = (selectIndex - 1 + menuItems.Length) % menuItems.Length;
            UpdateMenuVisuals();
        }

        // ���L�[�őI�������Ɉړ�
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            selectIndex = (selectIndex + 1) % menuItems.Length;
            UpdateMenuVisuals();
        }

        // Enter�L�[�őI�����m��
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if(quickSeleckTitlle)
            {
                ExecuteSelectedOption_Titlle();
            }
            if (quickSeleckResult)
            {
                ExecuteSelectedOption_Result();
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
                Debug.Log("�V�ѕ���\��");
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
}

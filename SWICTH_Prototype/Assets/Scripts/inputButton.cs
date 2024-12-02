using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
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
            Debug.Log("上に動いた");
        }
        if (Input.GetAxis("L_Stick_V") > 0)
        {
            Debug.Log("下に動いた");
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
        // 上キーで選択を上に移動
        if ((stopStick && Input.GetAxis("L_Stick_V") < 0) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            selectIndex = (selectIndex - 1 + menuItems.Length) % menuItems.Length;
            stopStick = false;
            UpdateMenuVisuals();
        }

        // 下キーで選択を下に移動
        if ((stopStick && Input.GetAxis("L_Stick_V") > 0) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            selectIndex = (selectIndex + 1) % menuItems.Length;
            stopStick = false;
            UpdateMenuVisuals();
        }

        // Enterキーで選択を確定
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
            case 0: // 「スタート」
                Debug.Log("ゲームスタート");
                GM.StartButton();
                break;
            case 1: // 「遊び方」
                Debug.Log("遊び方を表示");
                break;
            case 2: // 「終わる」
                Debug.Log("ゲーム終了");
                GM.ExitButton();
                break;
        }
    }

    void ExecuteSelectedOption_Result()
    {
        switch (selectIndex)
        {
            case 0: // 「スタート」
                Debug.Log("ゲームスタート");
                GM.TitlleButton();
                break;
            case 1: // 「終わる」
                Debug.Log("ゲームで終了");
                GM.ExitButton();
                break;
        }
    }
}

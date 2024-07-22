using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotationScript : MonoBehaviour
{
    float Rotation_angle;//角度(ここに速度が加算される)
    float Save_angle;//合計の角度(これで回転を終わらせるかどうか判定する)
    float Rotation_range;//何度回転するか
    float Center_angle;
    [SerializeField] Transform Center;//回転の中心となるオブジェクト
    GameObject[] whether = new GameObject[3];//回転するオブジェクト
    [SerializeField] float Speed = 10f;//回転の速度
    bool Right_rotating = false;//右回転
    bool Left_rotating = false;//左回転
    int whether_index = 0;

    // Start is called before the first frame update
    private void Start()
    {
        Exit_rotation();//ここで回転に必要な数値の初期化
        Center_angle = transform.localEulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(!InputScript.on_rotation)//InputScript上にある変数がfalseの時
        {
            Get_key();
        }

        if(InputScript.on_rotation)//InputScript上にある変数がtrueの時
        {
            if(Right_rotating)
            {
                Whether_rotation_Right();
            }
            if(Left_rotating) 
            {
                Whether_rotation_Left();
            }
        } 
    }

    void Whether_rotation_Right()//右回転
    {
        Rotation_angle += Time.deltaTime * Speed;
        Save_angle += Rotation_angle;
        Vector3 d = new Vector3(0, Rotation_angle, 0);
        transform.Rotate(d);
        Whether_rotation(d);

        if(Save_angle >= Rotation_range)
        {
            Vector3 c = Center.localEulerAngles;
            Center_angle += Rotation_range;
            c.y = Center_angle;
            Center.localEulerAngles = c;
            Whether_set(c);
            Exit_rotation();
        }
    }

    void Whether_rotation_Left()//左回転
    {
        Rotation_angle -= Time.deltaTime * Speed;
        Save_angle += -Rotation_angle;
        Vector3 d = new Vector3(0, Rotation_angle, 0);
        transform.Rotate(d);
        Whether_rotation(d);

        if (Save_angle >= Rotation_range)
        {
            Vector3 c = Center.localEulerAngles;
            Center_angle -= Rotation_range;
            c.y = Center_angle;
            Center.localEulerAngles = c;
            Whether_set(c);
            Exit_rotation();
        }
    }

    void Exit_rotation()//数値をリセットする関数
    {
        Rotation_angle = 0;
        Save_angle = 0;
        InputScript.on_rotation = false;
        Right_rotating = false;
        Left_rotating = false;
    }

    void Whether_rotation(Vector3 d)
    {
        for(int i = 0; i < whether.Length; i++)
        {
            whether[i].transform.Rotate(-d);
        }
    }

    void Whether_set(Vector3 d)
    {
        for(int i = 0; i < whether.Length;i++)
        {
            whether[i].transform.localEulerAngles = -d;
        }
    }

    void Set_rotation()
    {

        InputScript.on_rotation = true;
    }

    //ここから入力の判定
    void Get_key()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            Set_rotation();
            Right_rotating = true;
            Debug.Log("D");
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            Set_rotation();
            Left_rotating = true;
            Debug.Log("A");
        }

        //反応しなかったので何とかしてみせます
        if (Input.GetButtonDown("Right"))
        {
            Set_rotation();
            Right_rotating = true;
            Debug.Log("R2");
        }

        if (Input.GetButtonDown("Left"))
        {
            Set_rotation();
            Left_rotating = true;
            Debug.Log("L2");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Sunny" || other.tag == "Rainy" || other.tag == "Thunder")
        {
            Debug.Log("GetWhether");
            whether[whether_index] = other.gameObject;
            whether_index++;
            if(whether_index == 3) { whether_index = 0; }
        }
    }

}

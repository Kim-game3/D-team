using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiveRotationScript : MonoBehaviour
{
    GameObject[] Whether = new GameObject[3];
    [SerializeField] int Center_number;
    [SerializeField] GameObject Center;
    [SerializeField] float Speed;
    [SerializeField] float Rotation_range;
    GameObject Rotation;
    float Rotation_angle;
    float Save_angle;
    int Whether_index = 0;

    private bool Left_rotate;
    private bool Right_rotate;
    // Start is called before the first frame update
    void Start()
    {
        Exit_rotation();
    }

    // Update is called once per frame
    void Update()
    {
        if(Rotation == null && !InputScript.on_rotation)
        {
            Get_key();
        }

        if(Left_rotate)
        {
            Left_rotation();
            //Right_rotation();
        }
        else if(Right_rotate)
        {
            Right_rotation();
            //Left_rotation();
        }
    }

    void Get_key()
    {
        switch(Center_number)
        {
            case 1:
                {
                    if(Input.GetKeyDown(KeyCode.A))
                    {
                        Set_rotation();
                        Left_rotate = true;
                    }
                }
                break;
            case 2: 
                {
                    if(Input.GetKeyDown(KeyCode.D))
                    {
                        Set_rotation();
                        Right_rotate = true;
                    }
                }
                break;
        }
    }

    void Left_rotation()
    {
        Rotation_angle -= Time.deltaTime * Speed;
        Save_angle += -Rotation_angle;
        Vector3 w = new Vector3(0, Rotation_angle, 0);
        Rotation.transform.Rotate(w);
        Whether_rotation(w);

        if(Save_angle >= Rotation_range)
        {
            Debug.Log("Rotate Left");
            Exit_rotation();
        }
       
    }

    void Right_rotation()
    {
        Rotation_angle += Time.deltaTime * Speed;
        Save_angle += Rotation_angle;
        Vector3 w = new Vector3(0, Rotation_angle, 0);
        Rotation.transform.Rotate(w);
        Whether_rotation(w);

        if(Save_angle >= Rotation_range)
        {
            Debug.Log("Rotation Right");
            Exit_rotation();
        }
        
    }

    void Exit_rotation()
    {
        Rotation_angle = 0;
        Save_angle = 0;
        Whether_index = 0;
        Rotation = null;
        InputScript.on_rotation = false;
        Left_rotate = false;
        Right_rotate = false;
    }

    void Whether_rotation(Vector3 w)
    {
        for(int i = 0; i < Whether.Length; i ++)
        {
            Whether[i].transform.Rotate(-w);
        }
    }
    void Set_rotation()
    {
        Rotation = Center;
        for(int i = 0; i < Whether.Length; i++) 
        {
            Whether[i].transform.parent = Rotation.transform; 
        }
        InputScript.on_rotation = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Sunny" || other.tag == "Rainy" || other.tag == "Thunder")
        {
            Debug.Log("Set whether");
            Whether[Whether_index] = other.gameObject;
            Whether_index++;
            if(Whether_index == Whether.Length)
            {
                Whether_index = 0;
            }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.Oculus.Input;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UIElements;

public class sunnyGrow : MonoBehaviour
{
    public GameObject[] seeds;//���Ɏ킪�����Ă܂��B
    public bool S_Ready = false;

    int count;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnTriggerEnter(Collider other)//�������͋@�\����
    {
        if (other.CompareTag("Sunny"))
        {
            S_Ready = true;
            Debug.Log("����퐬�����܂�!");
            //Debug.Log(S_Ready);
        }
    }

    void OnTriggerExit(Collider other)//�������͋@�\����
    {
        if (other.CompareTag("Sunny"))
        {
            S_Ready = false;
            //Debug.Log("����퐬�����܂�!");
            //Debug.Log(S_Ready);
        }
    }

}

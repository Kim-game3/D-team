using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UIElements;

public class sunnyGrow : MonoBehaviour
{
    public GameObject[] seeds;//���Ɏ킪�����Ă܂��B
    public GameManager GM;
    private Renderer objectRenderer;
    public bool S_Ready = false;

    int count;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        activeSeed(count);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void sunnyGrowing()
    {
        int j;
        Debug.Log("�e�X�g�P");//�����܂ŗ��Ă�B
        
        count = (count + 1) % seeds.Length;
        activeSeed(count);

    }

    private void activeSeed(int index)
    {
        
    }

    void OnTriggerEnter(Collider other)//�������͋@�\����
    {
        if (other.CompareTag("Sunny"))
        {
            S_Ready = true;
            Debug.Log("����퐬�����܂�!");
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UIElements;

public class sunnyGrow : MonoBehaviour
{
    public GameObject[] seeds;//���Ɏ킪�����Ă܂��B
    public GameManager GM;

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

    public void sunnyGrowing()
    {
        Debug.Log("�e�X�g�P");//�����܂ŗ��Ă�B
        for (int i = 0; i < seeds.Length; i++)
        {
            
            count++;
        }

    }

    void OnTriggerEnter(Collider other)//�������͋@�\����
    {
        if (other.CompareTag("Sunny"))
        {
            for(int i = 0;i < seeds.Length;i++)
            {
                Debug.Log(seeds[i].name);
            }
            Debug.Log("����퐬�����܂�!");
        }//�T�j�[����
    }

}

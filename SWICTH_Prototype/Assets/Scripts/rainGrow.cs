using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rainGrow : MonoBehaviour
{
    public GameObject[] seeds;//���Ɏ킪�����Ă܂��B
    public bool R_Ready = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void rainGrowing()
    {

    }

    void OnTriggerEnter(Collider other)//�������͋@�\����
    {
        if (other.CompareTag("Rainy"))
        {
            R_Ready = true;
            //Debug.Log("�J�퐬�����܂�!");
        }
    }

    void OnTriggerExit(Collider other)//�������͋@�\����
    {
        if (other.CompareTag("Sunny"))
        {
            R_Ready = false;
            //Debug.Log("����퐬�����܂�!");
            //Debug.Log(S_Ready);
        }
    }
}

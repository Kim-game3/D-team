using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thunderGrow : MonoBehaviour
{
    public GameObject[] seeds;//���Ɏ킪�����Ă܂��B
    public bool T_Ready = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)//�������͋@�\����
    {
        if (other.CompareTag("Thunder"))
        {
            T_Ready = true;
            Debug.Log("���퐬�����܂�!");
        }
    }

    void OnTriggerExit(Collider other)//�������͋@�\����
    {
        if (other.CompareTag("Thunder"))
        {
            T_Ready = false;
            //Debug.Log("���퐬�����܂���!");
            //Debug.Log(S_Ready);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thunderGrow : MonoBehaviour
{
    //public GameObject[] seeds;//���Ɏ킪�����Ă܂��B
    public bool T_Ready = false;
    public bool T_Harvest = false;
    private Vector3 seedScale;

    // Start is called before the first frame update
    void Start()
    {
        //seedScale = transform.localScale;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //transform.localScale = seedScale;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sunnyGrow : MonoBehaviour
{
    public GameObject aaa;//����̃I�u�W�F�N�g�p

    // Start is called before the first frame update
    void Start()
    {
        //aaa = transform.Find("hitPosition").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void sunnyGrowing()
    {
        
    }

    void OnTriggerEnter(Collider other)//�������͋@�\����
    {
        if (other.CompareTag("Sunny"))
        {
            Debug.Log("����퐬�����܂�!");
            Debug.Log(aaa.name);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rainGrow : MonoBehaviour
{
    public GameObject aaa;//����̃I�u�W�F�N�g�p

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
        if (other.CompareTag("Rainy"))
        {

            Debug.Log("�J�퐬�����܂�!");
        }
    }
}

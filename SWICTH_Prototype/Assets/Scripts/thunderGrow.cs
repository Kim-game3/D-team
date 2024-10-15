using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thunderGrow : MonoBehaviour
{
    public GameObject aaa;//からのオブジェクト用

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)//こっちは機能する
    {
        if (other.CompareTag("Thunder"))
        {

            Debug.Log("雷種成長します!");
        }
    }
}

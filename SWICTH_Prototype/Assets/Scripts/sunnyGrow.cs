using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sunnyGrow : MonoBehaviour
{
    public GameObject aaa;//からのオブジェクト用

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

    void OnTriggerEnter(Collider other)//こっちは機能する
    {
        if (other.CompareTag("Sunny"))
        {
            Debug.Log("晴れ種成長します!");
            Debug.Log(aaa.name);
        }
    }

}

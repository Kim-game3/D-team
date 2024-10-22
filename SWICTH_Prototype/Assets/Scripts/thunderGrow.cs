using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thunderGrow : MonoBehaviour
{
    public GameObject[] seeds;//中に種が入ってます。
    public bool T_Ready = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void thunderGrowing()
    {

    }

    void OnTriggerEnter(Collider other)//こっちは機能する
    {
        if (other.CompareTag("Thunder"))
        {
            T_Ready = true;
            //Debug.Log("雷種成長します!");
        }
    }

    void OnTriggerExit(Collider other)//こっちは機能する
    {
        if (other.CompareTag("Sunny"))
        {
            T_Ready = false;
            //Debug.Log("晴れ種成長します!");
            //Debug.Log(S_Ready);
        }
    }
}

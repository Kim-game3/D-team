using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rainGrow : MonoBehaviour
{
    public GameObject[] seeds;//中に種が入ってます。
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

    void OnTriggerEnter(Collider other)//こっちは機能する
    {
        if (other.CompareTag("Rainy"))
        {
            R_Ready = true;
            //Debug.Log("雨種成長します!");
        }
    }

    void OnTriggerExit(Collider other)//こっちは機能する
    {
        if (other.CompareTag("Sunny"))
        {
            R_Ready = false;
            //Debug.Log("晴れ種成長します!");
            //Debug.Log(S_Ready);
        }
    }
}

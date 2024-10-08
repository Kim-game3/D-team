using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weather_Judgment : MonoBehaviour
{
    public GameObject fieldname;

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
        //あったったときに判定。
        if (other.CompareTag("Sunny"))
        {
           
            Debug.Log("天気" + fieldname.name + "はSunny");
        }
        if (other.CompareTag("Rainy"))
        {
            
            Debug.Log("天気" + fieldname.name + "はRainy");
        }
        if (other.CompareTag("Thunder"))
        {
            
            Debug.Log("天気" + fieldname.name+"はThunder");
        }
    }

    //いらない子
}

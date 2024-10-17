using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UIElements;

public class sunnyGrow : MonoBehaviour
{
    public GameObject[] seeds;//中に種が入ってます。
    public GameManager GM;

    int count;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void sunnyGrowing()
    {
        Debug.Log("テスト１");//ここまで来てる。
        for (int i = 0; i < seeds.Length; i++)
        {
            
            count++;
        }

    }

    void OnTriggerEnter(Collider other)//こっちは機能する
    {
        if (other.CompareTag("Sunny"))
        {
            for(int i = 0;i < seeds.Length;i++)
            {
                Debug.Log(seeds[i].name);
            }
            Debug.Log("晴れ種成長します!");
        }//サニーおけ
    }

}

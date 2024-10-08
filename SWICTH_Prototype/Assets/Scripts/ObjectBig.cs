using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ObjectBig : MonoBehaviour
{
    [SerializeField] GameObject sphere;

    //private Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Sunny()
    {
        //Weather_Judgment.getSunny = true;
        //Debug.Log("晴れになりました。");
    }

    public void Rainy()
    {
        //Debug.Log("雨です。");
        
    }

    public void Thunder()
    {
        //Debug.Log("雷です。");
        
    }

    //いらない子
}

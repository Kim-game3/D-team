using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ObjectBig : MonoBehaviour
{
    [SerializeField] GameObject sphere;
    [SerializeField] float SunnySeed = 0.5f;

   

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
        Debug.Log("晴れです");
        // オブジェクトをY軸にSunnySeed分f大きくする
        //sphere.transform.localScale += new Vector3(0, SunnySeed, 0);
    }

    public void Rainy()
    {
        Debug.Log("雨です");
        // オブジェクトをY軸に0.1f大きくする
        //sphere.transform.localScale += new Vector3(0, SunnySeed, 0);
    }

    public void Thunder()
    {
        Debug.Log("雷です");
        // オブジェクトをY軸に0.1f大きくする
        //sphere.transform.localScale += new Vector3(0, -SunnySeed*2, 0);
    }

}

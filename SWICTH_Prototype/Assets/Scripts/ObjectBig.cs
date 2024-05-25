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
        // 0.1秒ごとにScaleObjectを繰り返す
        InvokeRepeating("ScaleObject", 0f, 0.1f);

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Sunny()
    {
        
        // オブジェクトをY軸にSunnySeed分f大きくする
        //sphere.transform.localScale += new Vector3(0, SunnySeed, 0);
    }

    public void Rainy()
    {
        // オブジェクトをY軸に0.1f大きくする
        //sphere.transform.localScale += new Vector3(0, SunnySeed, 0);
    }

    public void Thunder()
    {
        // オブジェクトをY軸に0.1f大きくする
        //sphere.transform.localScale += new Vector3(0, -SunnySeed*2, 0);
    }

    void ScaleObject()
    {
        // オブジェクトを少し大きくする
        transform.localScale += new Vector3(0f, 0.1f, 0f);
    }

    public void myEnd()
    {
        CancelInvoke();
    }

}

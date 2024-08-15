using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject seeds;
    [SerializeField] GameObject spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(seeds,transform.position,transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

/*
 * 空のオブジェクトの位置にseedsをスポーンさせる。
 * 
 */

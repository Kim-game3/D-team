using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject seeds;//種
    [SerializeField] GameObject[] fieid;//畑の位置
    [SerializeField] GameObject[] spawnSeeds;//格納場所

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < fieid.Length; i++)
        {
            if (fieid[i] != null)
            {
                Vector3 spawnPosition = fieid[i].transform.position;
                spawnSeeds[i] = Instantiate(seeds, spawnPosition, Quaternion.identity);
            }
        }

        spawnSeeds[0].tag = "Sunny";
        Instantiate(seeds,transform.position,transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Set_Random()
    {

    }
}

/*
 * 空のオブジェクトの位置にseedsをスポーンさせる。
 * fieldの要素数とspawnSeedsの要素数は同じにしてください。
 * fieldにからのオブジェクトを入れてその位置にseedsがスポーンします。
 * スポーンしたseedsはspawnSeedsに格納されます。
 */

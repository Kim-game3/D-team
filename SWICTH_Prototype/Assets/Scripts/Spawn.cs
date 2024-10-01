using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject seeds;//種
    [SerializeField] GameObject[] fieid;//畑の位置
    [SerializeField] GameObject[] spawnSeeds;//格納場所

    private Renderer[] seedsRenderers = new Renderer[5];


    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < fieid.Length; i++)
        {
            if (fieid[i] != null)
            {
                Vector3 spawnPosition = fieid[i].transform.position;
                spawnSeeds[i] = Instantiate(seeds, spawnPosition, Quaternion.identity);
                seedsRenderers[i] = spawnSeeds[i].GetComponent<Renderer>();
            }
        }

        //Instantiate(seeds,transform.position,transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        //収穫のボタン操作
        if(Input.GetKeyUp(KeyCode.L))
        {
            Debug.Log("収穫処理L");
            //中に処理を書く
            for (int i = 0;i < fieid.Length;i++) 
            {
                if (Weather_Judgment.getSunny)
                {
                    seedsRenderers[i].material.color = Color.blue;
                }
                
            }
            Weather_Judgment.getSunny = false;
        }
    }
}

/*
 * 空のオブジェクトの位置にseedsをスポーンさせる。
 * fieldの要素数とspawnSeedsの要素数は同じにしてください。
 * fieldにからのオブジェクトを入れてその位置にseedsがスポーンします。
 * スポーンしたseedsはspawnSeedsに格納されます。
 */

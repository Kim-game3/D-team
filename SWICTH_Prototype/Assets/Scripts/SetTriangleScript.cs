using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(GameManager))]

public class SetTriangleScript : MonoBehaviour
{
    [SerializeField] Transform[] vertices;//配置するオブジェクト
    [SerializeField] float sideLength;//正三角形の一辺の長さ
    [SerializeField] float Hieght;


    [SerializeField] public bool apawnPosition = false;
    [SerializeField] public GameObject[] Seeds; 

    private GameObject[] spawnSeeds;//格納場所→GMに格納しました。いらない子かも
    private GameObject randomSeed;//仮の肉体
    public float Position = 0;

    public GameManager GM;

    private Renderer[] seedsRenderers = new Renderer[5];

    private int seedLottery;
    public RandomSet RS;

    void Start()
    {
        Vector3[] positions = CalculateFiveVertices(sideLength);

        for (int i = 0; i < vertices.Length && i < positions.Length; i++)
        {
            vertices[i].position = positions[i];
        }

        Set_Seeds();
        
    }

    private void Update()
    {
        /*if(GM.Null_Set)
        {
            Set_Seeds();
            GM.Null_Set = false;
        }*/
    }

    //それぞれの座標を計算で指定する関数
    Vector3[] CalculateFiveVertices(float sideLength)
    {
        float Side = Mathf.Sqrt(3) / 2 * sideLength;

        //Truncated(Side, 2);

        Vector3[] vertices = new Vector3[5];
        vertices[0] = new Vector3(0, Hieght, 0);
        vertices[1] = new Vector3(Side, Hieght, sideLength / 2);
        vertices[2] = new Vector3(Side, Hieght, -sideLength / 2);
        vertices[3] = new Vector3(-Side, Hieght, sideLength / 2);
        vertices[4] = new Vector3(-Side, Hieght, -sideLength / 2);

        return vertices;
    }

    //四捨五入をする関数
    /*float Truncated(float Side, float num)
    {
        float Rounding;
        float DecPart = Side - Mathf.FloorToInt(Side);

        int Dec1 = Mathf.FloorToInt(DecPart * Mathf.Pow(10, num));
        int Dec2 = Dec1 - Mathf.FloorToInt(Dec1 / 10) * 10;

        if(Dec2 >= 5)
        {
            Rounding = Mathf.CeilToInt(Side * Mathf.Pow(10, num - 1));
            Rounding /= Mathf.Pow(10, num - 1);
        }
        else
        {
            Rounding = Mathf.FloorToInt(Side * Mathf.Pow(10, num - 1));
            Rounding /= Mathf.Pow(10, num - 1);
        }
        return Rounding;
    }*/

    public void Set_Seeds()
    {
        if (apawnPosition)
        {
            for (int i = 0; i < vertices.Length; i++)
            {
                if (vertices[i] != null)
                {
                    seedLottery = UnityEngine.Random.Range(0, 3);
                    //RS.HO_Random(seedLottery);

                    Vector3 spawnPosition = vertices[i].transform.position;
                    spawnPosition.y = Position;
                    GM.seedBody[i] = Instantiate(Seeds[seedLottery], spawnPosition, Quaternion.identity);
                    /*spawnSeeds[i] = Instantiate(Seeds[seedLottery], spawnPosition, Quaternion.identity);
                    GM.seedBody[i] = spawnSeeds[i];*/
                    seedsRenderers[i] = GM.seedBody[i].GetComponent<Renderer>();
                }
            }
        }
    }
}

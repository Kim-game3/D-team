using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;

public class SetTriangleScript : MonoBehaviour
{
    [SerializeField] Transform[] vertices;//配置するオブジェクト
    [SerializeField] float sideLength;//正三角形の一辺の長さ
    [SerializeField] float Hieght;


    [SerializeField] public bool apawnPosition = false;
    [SerializeField] GameObject[] spawnSeeds;//格納場所
    [SerializeField] GameObject seeds;//種
    public float Position = 0;

    private Renderer[] seedsRenderers = new Renderer[5];


    void Start()
    {
        Vector3[] positions = CalculateFiveVertices(sideLength);

        for (int i = 0; i < vertices.Length && i < positions.Length; i++)
        {
            vertices[i].position = positions[i];
        }

        if (apawnPosition)
        {
            for(int i = 0; i<vertices.Length; i++)
            {
                if (vertices[i] != null)
                {
                    Vector3 spawnPosition = vertices[i].transform.position;
                    spawnPosition.y = Position;
                    spawnSeeds[i] = Instantiate(seeds, spawnPosition, Quaternion.identity);
                    seedsRenderers[i] = spawnSeeds[i].GetComponent<Renderer>();
                }
            }
        }
    }

    //それぞれの座標を計算で指定する関数
    Vector3[] CalculateFiveVertices(float sideLength) 
    {
        float Side = Mathf.Sqrt(3) / 2 * sideLength;

        Truncated(Side, 2);

        Vector3[] vertices = new Vector3[5];
        vertices[0] = new Vector3(0, Hieght, 0);
        vertices[1] = new Vector3(Side, Hieght, sideLength / 2);
        vertices[2] = new Vector3(Side, Hieght, -sideLength / 2);
        vertices[3] = new Vector3(-Side, Hieght, sideLength / 2);
        vertices[4] = new Vector3(-Side, Hieght, -sideLength / 2);

        return vertices;
    }

    //四捨五入をする関数
    float Truncated(float Side, float num)
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
    }
}

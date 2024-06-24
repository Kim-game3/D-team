using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTriangleScript : MonoBehaviour
{
    [SerializeField] Transform center;//中心となるオブジェクト
    [SerializeField] Transform[] vertices;//配置するオブジェクト
    [SerializeField] float sideLength = 25f;//正三角形の一辺の長さ
    [SerializeField] float rotate;//中心であるcenterの角度

    void Start()
    {
        //この関数で正三角形の頂点を計算して配置する
        Vector3[] positions = CalculateTriangleVertices(center.position, sideLength);

        for(int i = 0; i < vertices.Length && i < positions.Length; i++)
        {
            vertices[i].position = positions[i];
            vertices[i].parent = center;//ここで頂点のオブジェクト3つの親をcenterに設定
        }

        center.transform.Rotate(0, rotate, 0);
    }

    Vector3[] CalculateTriangleVertices(Vector3 center, float sideLength)
    {
        //高さを計算
        float height = Mathf.Sqrt(3) / 2 * sideLength;

        //頂点を計算
        Vector3[] vertices = new Vector3[3];
        vertices[0] = center + new Vector3(-sideLength / 2, 10, height / 3);
        vertices[1] = center + new Vector3(sideLength / 2, 10, height / 3);
        vertices[2] = center + new Vector3(0, 10, -2 * height / 3);

        return vertices;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SetTriangleScript : MonoBehaviour
{
    //[SerializeField] Transform center;//中心となるオブジェクト
    [SerializeField] Transform[] vertices;//配置するオブジェクト
    [SerializeField] float sideLength;//正三角形の一辺の長さ
    [SerializeField] float Hieght;
    [SerializeField] Transform[] Center;
    [SerializeField] bool Set;
   

    void Start()
    {
        Vector3[] positions = CalculateFiveVertices(sideLength);

        for (int i = 0; i < vertices.Length && i < positions.Length; i++)
        {
            vertices[i].position = positions[i];
        }
    }

    Vector3[] CalculateFiveVertices(float sideLength) 
    {
        float Side = Mathf.Sqrt(3) / 2 * sideLength;

        Vector3[] vertices = new Vector3[5];
        vertices[0] = new Vector3(0, Hieght, 0);
        vertices[1] = new Vector3(Side, Hieght, sideLength / 2);
        vertices[2] = new Vector3(Side, Hieght, -sideLength / 2);
        vertices[3] = new Vector3(-Side, Hieght, sideLength / 2);
        vertices[4] = new Vector3(-Side, Hieght, -sideLength / 2);


        if(Set)
        {
            Vector3[] Centers = new Vector3[2];
            Centers[0] = new Vector3((Side * 2) / 3, 0, 0);
            Centers[1] = new Vector3((-Side * 2) / 3, 0, 0);
        }
        return vertices;
    }
}

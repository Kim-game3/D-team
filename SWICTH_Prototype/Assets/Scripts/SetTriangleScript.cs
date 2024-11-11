using UnityEngine;

public class SetTriangleScript : MonoBehaviour
{
    [SerializeField] Transform[] vertices;//配置するオブジェクト
    [SerializeField] float sideLength;//正三角形の一辺の長さ
    [SerializeField] float Hieght;

    void Start()
    {
        Vector3[] positions = CalculateFiveVertices(sideLength);

        for (int i = 0; i < vertices.Length && i < positions.Length; i++)
        {
            vertices[i].position = positions[i];
        } 
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
}

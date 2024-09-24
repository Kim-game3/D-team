using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SetTriangleScript : MonoBehaviour
{
    //[SerializeField] Transform center;//���S�ƂȂ�I�u�W�F�N�g
    [SerializeField] Transform[] vertices;//�z�u����I�u�W�F�N�g
    [SerializeField] float sideLength;//���O�p�`�̈�ӂ̒���
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

    //���ꂼ��̍��W���v�Z�Ŏw�肷��֐�
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


        if(Set)//���ꂪInspector���true�ɂȂ��Ă����璆�S�̍��W�̌v�Z���s��
        {
            Vector3[] Centers = new Vector3[2];
            Centers[0] = new Vector3((Side * 2) / 3, 0, 0);
            Centers[1] = new Vector3((-Side * 2) / 3, 0, 0);
        }
        return vertices;
    }

    //�l�̌ܓ�������֐�
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

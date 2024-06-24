using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTriangleScript : MonoBehaviour
{
    [SerializeField] Transform center;//���S�ƂȂ�I�u�W�F�N�g
    [SerializeField] Transform[] vertices;//�z�u����I�u�W�F�N�g
    [SerializeField] float sideLength = 25f;//���O�p�`�̈�ӂ̒���
    [SerializeField] float rotate;//���S�ł���center�̊p�x

    void Start()
    {
        //���̊֐��Ő��O�p�`�̒��_���v�Z���Ĕz�u����
        Vector3[] positions = CalculateTriangleVertices(center.position, sideLength);

        for(int i = 0; i < vertices.Length && i < positions.Length; i++)
        {
            vertices[i].position = positions[i];
            vertices[i].parent = center;//�����Œ��_�̃I�u�W�F�N�g3�̐e��center�ɐݒ�
        }

        center.transform.Rotate(0, rotate, 0);
    }

    Vector3[] CalculateTriangleVertices(Vector3 center, float sideLength)
    {
        //�������v�Z
        float height = Mathf.Sqrt(3) / 2 * sideLength;

        //���_���v�Z
        Vector3[] vertices = new Vector3[3];
        vertices[0] = center + new Vector3(-sideLength / 2, 10, height / 3);
        vertices[1] = center + new Vector3(sideLength / 2, 10, height / 3);
        vertices[2] = center + new Vector3(0, 10, -2 * height / 3);

        return vertices;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject seeds;//��
    [SerializeField] GameObject[] fieid;//���̈ʒu
    [SerializeField] GameObject[] spawnSeeds;//�i�[�ꏊ

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
        //���n�̃{�^������
        if(Input.GetKeyUp(KeyCode.L))
        {
            Debug.Log("���n����L");
            //���ɏ���������
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
 * ��̃I�u�W�F�N�g�̈ʒu��seeds���X�|�[��������B
 * field�̗v�f����spawnSeeds�̗v�f���͓����ɂ��Ă��������B
 * field�ɂ���̃I�u�W�F�N�g�����Ă��̈ʒu��seeds���X�|�[�����܂��B
 * �X�|�[������seeds��spawnSeeds�Ɋi�[����܂��B
 */

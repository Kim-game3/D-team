using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thunderGrow : MonoBehaviour
{
    public GameObject[] seeds;//���Ɏ킪�����Ă܂��B
    public GameManager GM;

    int count;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void thunderGrowing()
    {

    }

    void OnTriggerEnter(Collider other)//�������͋@�\����
    {
        if (other.CompareTag("Thunder"))
        {

            Debug.Log("���퐬�����܂�!");
        }
    }
}

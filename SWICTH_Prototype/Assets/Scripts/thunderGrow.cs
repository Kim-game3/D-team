using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thunderGrow : MonoBehaviour
{
    public GameObject[] seeds;//���Ɏ킪�����Ă܂��B
    public GameManager GM;

    // Start is called before the first frame update
    void Start()
    {
        
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

            //Debug.Log("���퐬�����܂�!");
        }
    }
}

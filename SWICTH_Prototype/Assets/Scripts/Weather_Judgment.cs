using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�V�C����pscript
public class Weather_Judgment : MonoBehaviour
{

    public GameObject fieldname;
    public ObjectBig objectBig;

    private bool Sunny = false;

    // Start is called before the first frame update
    void Start()
    {
        //objectBig.set();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        //�e�^�O��擾�����Ƃ�
        if (other.CompareTag("Sunny"))
        {
            mygameObject.Sunny();
            Debug.Log("����" + fieldname.name + "��Sunny");
        }
        if (other.CompareTag("Rainy"))
        {
            mygameObject.Rainy();
            Debug.Log("����" + fieldname.name + "��Rainy");
        }
        if (other.CompareTag("Thunder"))
        {
            mygameObject.Thunder();
            Debug.Log("����"+fieldname.name+"��Thunder");
        }
    }

    
}

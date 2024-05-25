using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�V�C����pscript
public class Weather_Judgment : MonoBehaviour
{

    public GameObject fieldname;
    public ObjectBig mygameObject;

    private bool Sunny = false;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Sunny"))
        {
            mygameObject.myEnd();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        //�e�^�O���擾�����Ƃ�
        if (other.CompareTag("Sunny"))
        {
            Sunny = true;
            if (Sunny)
            {
                mygameObject.Sunny();
            }
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

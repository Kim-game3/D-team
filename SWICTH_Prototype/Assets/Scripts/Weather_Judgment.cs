using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�V�C����pscript
public class Weather_Judgment : MonoBehaviour
{

    public GameObject fieldname;
    public ObjectBig objectBig;

    private bool Sunny = false;

    public static bool getSunny = false;

    // Start is called before the first frame update
    void Start()
    {
        //objectBig.set();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)//入っているときにずっと回してる。
    {
        
        if (other.CompareTag("Sunny"))
        {
            objectBig.Sunny();
            Debug.Log("天気" + fieldname.name + "はSunny");
        }
        if (other.CompareTag("Rainy"))
        {
            objectBig.Rainy();
            //Debug.Log("天気" + fieldname.name + "はRainy");
        }
        if (other.CompareTag("Thunder"))
        {
            objectBig.Thunder();
            //Debug.Log("天気" + fieldname.name+"はThunder");
        }
    }

    
}

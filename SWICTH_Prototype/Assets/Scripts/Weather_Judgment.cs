using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//天気判定用script
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
        //各タグを取得したとき
        if (other.CompareTag("Sunny"))
        {
            Sunny = true;
            if (Sunny)
            {
                mygameObject.Sunny();
            }
            Debug.Log("現在" + fieldname.name + "はSunny");
        }
        if (other.CompareTag("Rainy"))
        {
            mygameObject.Rainy();
            Debug.Log("現在" + fieldname.name + "はRainy");
        }
        if (other.CompareTag("Thunder"))
        {
            mygameObject.Thunder();
            Debug.Log("現在"+fieldname.name+"はThunder");
        }
    }

    
}

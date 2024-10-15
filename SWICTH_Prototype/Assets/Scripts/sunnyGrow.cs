using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sunnyGrow : MonoBehaviour
{
    public GameObject[] bbb;//’†‚Éí‚ª“ü‚Á‚Ä‚Ü‚·B
    public GameObject seed;

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

    public void sunnyGrowing()
    {
        for (int i = 0; i < bbb.Length; i++)
        {
            count++;
            seed = GameObject.Instantiate(bbb[count])as GameObject;
        }

    }

    void OnTriggerEnter(Collider other)//‚±‚Á‚¿‚Í‹@”\‚·‚é
    {
        if (other.CompareTag("Sunny"))
        {
            Debug.Log("°‚êí¬’·‚µ‚Ü‚·!");
            Debug.Log(bbb[0].name);
        }
    }

}

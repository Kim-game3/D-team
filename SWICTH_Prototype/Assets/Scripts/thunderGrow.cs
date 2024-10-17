using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thunderGrow : MonoBehaviour
{
    public GameObject[] seeds;//’†‚Éí‚ª“ü‚Á‚Ä‚Ü‚·B
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

    void OnTriggerEnter(Collider other)//‚±‚Á‚¿‚Í‹@”\‚·‚é
    {
        if (other.CompareTag("Thunder"))
        {

            Debug.Log("—‹í¬’·‚µ‚Ü‚·!");
        }
    }
}

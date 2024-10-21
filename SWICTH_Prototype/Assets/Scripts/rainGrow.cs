using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rainGrow : MonoBehaviour
{
    public GameObject[] seeds;//’†‚Éí‚ª“ü‚Á‚Ä‚Ü‚·B
    public GameManager GM;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void rainGrowing()
    {

    }

    void OnTriggerEnter(Collider other)//‚±‚Á‚¿‚Í‹@”\‚·‚é
    {
        if (other.CompareTag("Rainy"))
        {

            //Debug.Log("‰Jí¬’·‚µ‚Ü‚·!");
        }
    }
}

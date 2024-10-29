using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rainGrow : MonoBehaviour
{
    public GameObject[] seeds;//’†‚Éí‚ª“ü‚Á‚Ä‚Ü‚·B
    public bool R_Ready = false;
    public bool R_Harvest = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rainy"))
        {
            R_Ready = true;
            Debug.Log("‰Jí¬’·‚µ‚Ü‚·!");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Rainy"))
        {
            R_Ready = false;
            //Debug.Log("‰Jí¬’·‚µ‚Ü‚¹‚ñ!");
            //Debug.Log(S_Ready);
        }
    }
}

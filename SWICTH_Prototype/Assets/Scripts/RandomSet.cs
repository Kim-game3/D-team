using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSet : MonoBehaviour
{

    [SerializeField] GameObject[] Seeds;
    [SerializeField] Transform[] Garden;

    
    private int Lottery;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Plant_Random()
    {
        Lottery = UnityEngine.Random.Range(0, 3);
    }
}

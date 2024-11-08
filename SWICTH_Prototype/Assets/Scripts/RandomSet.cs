using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSet : MonoBehaviour
{
    public int[] Random = { 3, 3, 3 };

    void Update()
    {
        //Set_Random();
    }

    public void Set_Random()
    {
        Debug.Log("ê∂ê¨äJén");

        for (int i = 0; i < 3; i++)
        {
            if (Random[i] == 3)
            {
                Random[i] = UnityEngine.Random.Range(0, 3);
            }
        }
    }

    public int HO_Random(int x)
    {
        Debug.Log("ìnÇµÇƒÇ‹Ç∑");
        x = Random[0];
        for(int i = 0; i < 2; i ++)
        {
            Random[i] = Random[i + 1];
            Random[i + 1] = 3;
        }
        return x;
    }
}

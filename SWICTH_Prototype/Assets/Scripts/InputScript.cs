using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputScript : MonoBehaviour
{
    public static bool on_rotation;
    public static bool IsDecision;
    // Start is called before the first frame update
    void Start()
    {
        on_rotation = false;//これがtrueの間は別の回転のキーを押しても反応しない
        IsDecision = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

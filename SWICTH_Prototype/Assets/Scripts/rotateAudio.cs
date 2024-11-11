using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateAudio : MonoBehaviour
{
    public AudioClip clip;
    public AudioSource L_Rotate;
    public AudioSource R_Rotate;

    // Start is called before the first frame update
    void Start()
    {
        L_Rotate = GetComponent<AudioSource>();
        R_Rotate = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("ê¨ìcîˆ");
        L_RotateAudio();
    }

    public void L_RotateAudio()
    {
        Debug.Log("âπÇ™Ç»ÇËÇ‹Ç∑");
        L_Rotate.PlayOneShot(clip);
    }

    public void R_RotateAudio()
    {
        Debug.Log("âπÇ™Ç»ÇËÇ‹Ç∑");
        L_Rotate.PlayOneShot(clip);
    }
}

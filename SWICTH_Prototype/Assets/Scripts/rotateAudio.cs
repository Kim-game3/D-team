using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateAudio : MonoBehaviour
{
    public AudioClip clip;
    public AudioSource L_Rotate;
    public AudioSource R_Rotate;
    [SerializeField] GameManager GM;

    // Start is called before the first frame update
    void Start()
    {
        L_Rotate = GetComponent<AudioSource>();
        R_Rotate = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       if(GM.controlButton && Input.GetKeyDown(KeyCode.A))
        {
            L_RotateAudio();
        }

        if (GM.controlButton && Input.GetKeyDown(KeyCode.D))
        {
            R_RotateAudio();
        }
    }

    public void L_RotateAudio()
    {
        Debug.Log("‰¹‚ª‚È‚è‚Ü‚·");
        L_Rotate.PlayOneShot(clip);
    }

    public void R_RotateAudio()
    {
        Debug.Log("‰¹‚ª‚È‚è‚Ü‚·");
        L_Rotate.PlayOneShot(clip);
    }
}

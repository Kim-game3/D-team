using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    bool endFadeIn = false;
    [SerializeField] float fadeDuration = 1f;
    CanvasGroup CanvasGroup;

    float m_Timer;
    // Start is called before the first frame update
    void Start()
    {
        CanvasGroup = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!endFadeIn)
        {
            myFadeIn();
        }
    }

    void myFadeIn()
    {
        m_Timer += Time.deltaTime;

        CanvasGroup.alpha = 1 - (m_Timer / fadeDuration);

        if(m_Timer > fadeDuration )
        {
            endFadeIn = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

public class TimeManerer : MonoBehaviour
{
    [SerializeField] float CountDownTime = 5.0f;//��������
    private float CurrentTime; //���݂̎���

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartCountDown());//�R���[�`��
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartCountDown()//�C�ӕb�̃J�E���g�_�E��
    {
        while(true)
        {
            CurrentTime = CountDownTime;

            while (CurrentTime > 0)
            {
                Debug.Log(CurrentTime);
                yield return new WaitForSeconds(1.0f);
                CurrentTime--;
            }

            Debug.Log("5�b�o��");
            yield return new WaitForSeconds(1.0f); // 1�b�҂��Ă���ēx�J�E���g�_�E�����J�n

        }

    }
}

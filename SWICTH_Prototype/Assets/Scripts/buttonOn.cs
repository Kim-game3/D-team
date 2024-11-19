using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class buttonOn : MonoBehaviour
{
    [SerializeField] Button focusButton;

    // Start is called before the first frame update
    void Start()
    {
        focusButton = focusButton.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        EventSystem.current.SetSelectedGameObject(null);
        focusButton.Select();
    }

}

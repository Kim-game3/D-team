using System.Collections;
using System.Collections.Generic;
//using UnityEditor.TerrainTools;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScrpt : MonoBehaviour
{
    [SerializeField] private GameObject _loadingUI;
    [SerializeField] private Slider _slider;
    public void LoadNextScene()
    {
        Debug.Log("ロード開始");
        _loadingUI.SetActive(true);
        StartCoroutine(LoadScene());
    }
    IEnumerator LoadScene()
    {
        Debug.Log("ロード完了");
        AsyncOperation async = SceneManager.LoadSceneAsync("end");
        while (!async.isDone)
        {
            _slider.value = async.progress;
            yield return null;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

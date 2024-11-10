using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    [SerializeField] private List<Image> Slide_Seeds;
    private List<Image> Slide_Data_Seeds;

    [SerializeField] Canvas canvas;
    [SerializeField] SetTriangleScript settriangle;
    public int Keep_Index { get; private set; } = 0;
    public bool Flag_Slide;

    private void Start()
    {
        Flag_Slide = false;
        InitializeSlideDataSeeds();
        SetSlideSeedsWhite();
        for(int i = 0; i < Slide_Seeds.Count; i++)
        {
            Shift_SeedsData();
        }
    }

    private void Update()
    {
        if(Flag_Slide)
        {
            Shift_SeedsData();
        }
    }

    private void InitializeSlideDataSeeds()
    {
        Slide_Data_Seeds = new List<Image>();

        for(int i = 0; i < Slide_Seeds.Count; i++)
        {
            Image image = Instantiate(Slide_Seeds[i], canvas.transform);
            Slide_Data_Seeds.Add(image);
        }
    }

    private void SetSlideSeedsWhite()
    {
        foreach(var image in Slide_Data_Seeds)
        {
            if (image == null)
            {
                Debug.LogError("‰æ‘œƒf[ƒ^‚ª‚ ‚è‚Ü‚¹‚ñ"); 
            }

            image.color = Color.white;
        }
    }

    public int Shift_SeedsData()
    {
        if (Slide_Data_Seeds.Count <= 0)
        {
            return -1;
        }

        List<Vector3> saved_Positions = new List<Vector3>();

        foreach(var image in Slide_Data_Seeds)
        {
            saved_Positions.Add(image.rectTransform.localPosition);
        }

        for(int i = 0; i < Slide_Data_Seeds.Count; i++)
        {
            if(i == Slide_Data_Seeds.Count - 1)
            {
                Destroy(Slide_Data_Seeds[i].gameObject);
                Slide_Data_Seeds.RemoveAt(i);
                int Random_Index = Random.Range(0, Slide_Seeds.Count);
                Keep_Index = Random_Index;
                Flag_Slide = false;
                Image Random_Seeds = Instantiate(Slide_Seeds[Random_Index], canvas.transform);
                Random_Seeds.color = Color.white;
                Slide_Data_Seeds.Insert(0, Random_Seeds);
                Slide_Data_Seeds[0].rectTransform.localPosition = saved_Positions[0];
                return Random_Index;
            }
            Slide_Data_Seeds[i].rectTransform.localPosition = saved_Positions[i + 1];
        }
        return -1;
    }
}

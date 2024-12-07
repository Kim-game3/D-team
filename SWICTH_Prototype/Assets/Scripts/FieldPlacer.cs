using UnityEngine;

public class FieldPlacer : MonoBehaviour
{
    [SerializeField] GameObject[] Field;
    public FiveObjectPlacer fiveobjectplacer;
    public int SeedNum { get; private set; }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SeedsJudge(int i)
    {
        if(i < 0 || i >= Field.Length)
        {
            Debug.LogWarning("�͈͊O�ł�" + i);
            return;
        }
        SeedNum = CompareSeeds(Field[i]);
        Debug.Log(SeedNum + "��n���܂���");
        fiveobjectplacer?.ReplaceInstanceAtIndex(i, SeedNum);
    }

    public int CompareSeeds(GameObject obj)
    {
        Vector3 boxSize = new Vector3(2, 2, 2);
        Collider[] hitcolliders = Physics.OverlapBox(obj.transform.position, boxSize / 2,Quaternion.identity);

        if (hitcolliders.Length == 0)
        {
            Debug.Log("���������Ă��Ȃ��̂ŋ�����Ԃ��܂���");
            return -1;
        }

        foreach (var hitcollider in hitcolliders)
        {
            Debug.Log("�����܂œ��B���܂���");
            switch (hitcollider.tag)
            {
                
                case "Sunny":
                    Debug.Log("���ꂱ���܂œ��B���܂���");
                    return 1;
                case "Rainy":
                    Debug.Log("�J�����܂œ��B���܂���"); 
                    return 2;
                case "Thunder":
                    Debug.Log("�������܂œ��B���܂���");
                    return 0;
                default:
                    Debug.Log($"�s���ȃ^�O�F{hitcollider.tag}");
                    break;
            }
        }

        Debug.Log("�Y������^�O��������Ȃ������̂Ńf�t�H���g�l��Ԃ��܂���");
        return -1;
    }

    private void OnDrawGizmos()
    {
        if (Field == null) return;

        Gizmos.color = Color.cyan;
        foreach(var obj in Field)
        {
            if(obj != null)
            {
                Vector3 boxSize = new Vector3(2, 2, 2);
                Gizmos.DrawWireCube(obj.transform.position, boxSize);
            }
        }
    }
}
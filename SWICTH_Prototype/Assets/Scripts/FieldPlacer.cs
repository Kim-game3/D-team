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
        if (i < 0 || i >= Field.Length)
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
        Collider[] hitcolliders = Physics.OverlapBox(obj.transform.position, boxSize / 2, Quaternion.identity);

        if (hitcolliders.Length == 0)
        {
            Debug.Log("����擾���Ă��Ȃ��̂�-1��Ԃ��܂���");
            return -1;
        }

        foreach (var hitcollider in hitcolliders)
        {
            switch (hitcollider.tag)
            {

                case "Sunny":
                    Debug.Log("�������m���܂���");
                    return 1;
                case "Rainy":
                    Debug.Log("�J����m���܂���");
                    return 2;
                case "Thunder":
                    Debug.Log("������m���܂���");
                    return 0;
                default:
                    Debug.Log($"�s���ȃ^�O{hitcollider.tag}");
                    break;
            }
        }

        Debug.Log("������m����Ȃ������̂�-1��Ԃ��܂���");
        return -1;
    }

    private void OnDrawGizmos()
    {
        if (Field == null) return;

        Gizmos.color = Color.cyan;
        foreach (var obj in Field)
        {
            if (obj != null)
            {
                Vector3 boxSize = new Vector3(2, 2, 2);
                Gizmos.DrawWireCube(obj.transform.position, boxSize);
            }
        }
    }
}
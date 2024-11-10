using UnityEngine;

public class FiveObjectPlacer : MonoBehaviour
{
    // �z�u����GameObject�̃v���n�u�𕡐��w��ł���悤�ɂ���
    [SerializeField] private GameObject[] objectPrefabs;

    // �z�u����5�̈ʒu
    [SerializeField] private Vector3[] positions = new Vector3[5];
    [SerializeField] private Quaternion[] rotations = new Quaternion[5];

    // �I�u�W�F�N�g�z�u�̂��߂̕ӂ̒��� (�C���X�y�N�^�[�Őݒ�)
    [SerializeField] private float sideLength = 1.0f;

    // �쐬�����C���X�^���X��ۑ�����z��
    private GameObject[] instantiatedObjects = new GameObject[5];

    // 5�̃I�u�W�F�N�g�̈ʒu���v�Z���郁�\�b�h
    private Vector3[] CalculateFiveObjectPositions()
    {
        float side = Mathf.Sqrt(3) / 2 * sideLength;
        float height = 0f;  // �K�v�ɉ����č�����ݒ�

        Vector3[] vertices = new Vector3[5];
        vertices[0] = new Vector3(0, height, 0);
        vertices[1] = new Vector3(side, height, sideLength / 2);
        vertices[2] = new Vector3(side, height, -sideLength / 2);
        vertices[3] = new Vector3(-side, height, sideLength / 2);
        vertices[4] = new Vector3(-side, height, -sideLength / 2);

        return vertices;
    }

    // �����_���ȃv���n�u��5�̈ʒu�ɃC���X�^���X�����A�ۑ����郁�\�b�h
    public void InstantiateRandomObjects()
    {
        Vector3[] positions = CalculateFiveObjectPositions();

        for (int i = 0; i < positions.Length; i++)
        {
            // objectPrefabs�̒����烉���_���ȃv���n�u��I��
            GameObject randomPrefab = objectPrefabs[Random.Range(0, objectPrefabs.Length)];
            Quaternion rotation = (i < rotations.Length) ? rotations[i] : Quaternion.identity;

            // �v���n�u���C���X�^���X�����ĕۑ�
            instantiatedObjects[i] = Instantiate(randomPrefab, positions[i], rotation);
        }
    }

    // �w�肳�ꂽ�C���f�b�N�X�̃|�C���g���擾���郁�\�b�h
    public Vector3 GetPointAtIndex(int index)
    {
        if (index < 0 || index >= positions.Length)
        {
            Debug.LogError("Index out of bounds");
            return Vector3.zero;  // �͈͊O�̏ꍇ�̓[���x�N�g����Ԃ�
        }

        return positions[index];
    }

    // �w�肳�ꂽ�C���f�b�N�X�̃C���X�^���X���擾���郁�\�b�h
    public GameObject GetInstanceAtIndex(int index)
    {
        if (index < 0 || index >= instantiatedObjects.Length)
        {
            Debug.LogError("Index out of bounds");
            return null;  // �͈͊O�̏ꍇ��null��Ԃ�
        }

        return instantiatedObjects[index];
    }

    // �w�肳�ꂽ�C���f�b�N�X�̃C���X�^���X���폜���A���̈ʒu�ɐV�����C���X�^���X���쐬���郁�\�b�h
    public void ReplaceInstanceAtIndex(int indexToDelete, int indexToCreate)
    {
        if (indexToDelete < 0 || indexToDelete >= instantiatedObjects.Length || indexToCreate < 0 || indexToCreate >= objectPrefabs.Length)
        {
            Debug.LogError("Index out of bounds");
            return;  // �͈͊O�̏ꍇ�͏������I��
        }

        // �폜����C���X�^���X�����݂���ꍇ�͔j��
        if (instantiatedObjects[indexToDelete] != null)
        {
            Destroy(instantiatedObjects[indexToDelete]);
        }

        // �V�����C���X�^���X���w�肳�ꂽ�ʒu�ɃC���X�^���X��
        GameObject prefabToCreate = objectPrefabs[indexToCreate];
        Vector3 positionToCreate = positions[indexToDelete];
        Quaternion rotationToCreate = (indexToDelete < rotations.Length) ? rotations[indexToDelete] : Quaternion.identity;

        instantiatedObjects[indexToDelete] = Instantiate(prefabToCreate, positionToCreate, rotationToCreate);
    }
}

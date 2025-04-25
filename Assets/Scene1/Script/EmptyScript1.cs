using UnityEngine;
using UnityEngine.UI;

public class EmptyScript1 : MonoBehaviour
{
    public Dropdown genderDropdown;
    public Dropdown hairDropdown;
    public InputField nameInput;
    public Button createButton;

    public GameObject malePrefab;
    public GameObject femalePrefab;
    private GameObject currentPreview;

    private void Start()
    {
        createButton.onClick.AddListener(CreateCharacter);
        genderDropdown.onValueChanged.AddListener(delegate { UpdatePreview(); });
        UpdatePreview();
    }

    void UpdatePreview()
    {
        if (currentPreview != null)
            Destroy(currentPreview);

        GameObject prefabToUse = (genderDropdown.value == 0) ? malePrefab : femalePrefab;
        currentPreview = Instantiate(prefabToUse, new Vector3(0, 0, 0), Quaternion.identity);
        currentPreview.transform.rotation = Quaternion.Euler(0, 180, 0); // ���� ����
    }

    void CreateCharacter()
    {
        // string characterName = nameInput.text;
        // int gender = genderDropdown.value;
        // int hair = hairDropdown.value;
        //
        // Debug.Log($"ĳ���� ������: �̸� = {characterName}, ���� = {(gender == 0 ? "��" : "��")}, ��� = {hair}");

        // ���� ���� �����Ϳ� �����ϰų� ���� ������ �ѱ�� ���� �߰�
    }
}

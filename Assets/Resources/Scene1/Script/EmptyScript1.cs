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
        currentPreview.transform.rotation = Quaternion.Euler(0, 180, 0); // 정면 보기
    }

    void CreateCharacter()
    {
        string characterName = nameInput.text;
        int gender = genderDropdown.value;
        int hair = hairDropdown.value;

        Debug.Log($"캐릭터 생성됨: 이름 = {characterName}, 성별 = {(gender == 0 ? "남" : "여")}, 헤어 = {hair}");

        // 실제 게임 데이터에 저장하거나 다음 씬으로 넘기는 로직 추가
    }
}

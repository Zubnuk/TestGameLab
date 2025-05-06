// Assets/2_UI/Scripts/QuestLogUI.cs
using UnityEngine;
using TMPro;

public class QuestLogUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _questDescriptionText;
    [SerializeField] private Transform _questListContainer;

    public void Show()
    {
        gameObject.SetActive(true);
        UpdateQuestList();
    }

    public void Hide() => gameObject.SetActive(false);

    private void UpdateQuestList()
    {
        // ���������� ������ ������� (������)
        foreach (Transform child in _questListContainer)
            Destroy(child.gameObject);

        // �����: �������� ������� �� ScriptableObjects � �������� ��������� UI
    }
}
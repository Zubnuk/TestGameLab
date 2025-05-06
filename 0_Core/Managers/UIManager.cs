// 2_UI/Scripts/UIManager.cs
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("������")]
    [SerializeField] private GameObject _eventPopup;
    [SerializeField] private TMP_Text _dateText;
    [SerializeField] private TMP_Text _goldText;
    [SerializeField] private TMP_Text _foodText;
    [SerializeField] private BuildingUI _buildingPanel;
    [SerializeField] private QuestLogUI _questLogPanel;

    public static UIManager Instance { get; private set; }

    private void Awake() => Instance = this;

    private void Start()
    {
        GameManager.Instance.ResourceManager.OnResourceChanged += UpdateResourceUI;
        GameManager.Instance.TimeManager.OnDayPassed += UpdateDateUI;
    }
  

    // ������� ������ ������������� ��� ���������
    public void OpenBuildingPanel(Province province)
    {
        _buildingPanel.Show(province);
    }

    // ������� ������ �������
    public void OpenQuestLog()
    {
        _questLogPanel.Show();
    }

    // ������� ��� ������ (���������� ��� ������� �� "�������")
    public void CloseAllPanels()
    {
        _buildingPanel.Hide();
        _questLogPanel.Hide();
    }

    private void UpdateDateUI()
    {
        _dateText.text = GameManager.Instance.TimeManager.GetFormattedDate();
    }

    private void UpdateResourceUI()
    {
        _goldText.text = GameManager.Instance.ResourceManager.Gold.ToString();
        _foodText.text = GameManager.Instance.ResourceManager.Food.ToString();
    }

    public void ShowEventPopup(GameEvent gameEvent)
    {
        _eventPopup.SetActive(true);
        // ���������� ������ �������...
    }
}
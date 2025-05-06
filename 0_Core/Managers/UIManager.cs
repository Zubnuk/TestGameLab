// 2_UI/Scripts/UIManager.cs
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Панели")]
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
  

    // Открыть панель строительства для провинции
    public void OpenBuildingPanel(Province province)
    {
        _buildingPanel.Show(province);
    }

    // Открыть журнал заданий
    public void OpenQuestLog()
    {
        _questLogPanel.Show();
    }

    // Закрыть все панели (вызывается при нажатии на "Закрыть")
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
        // Заполнение текста события...
    }
}
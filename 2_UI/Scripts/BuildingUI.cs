// Assets/2_UI/Scripts/BuildingUI.cs
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BuildingUI : MonoBehaviour
{
    [Header("����������")]
    [SerializeField] private TMP_Text _buildingNameText;
    [SerializeField] private TMP_Text _buildingCostText;
    [SerializeField] private Button _buildButton;

    private Province _currentProvince;
    private BuildingSO _selectedBuilding;

    public void Show(Province province)
    {
        _currentProvince = province;
        gameObject.SetActive(true);
    }

    public void Hide() => gameObject.SetActive(false);

    // ���������� ��� ������ ������ �� ������
    public void SelectBuilding(BuildingSO building)
    {
        _selectedBuilding = building;
        _buildingNameText.text = building.BuildingName;
        _buildingCostText.text = $"���������: {building.GoldCost} ������, {building.FoodCost} ���";
    }

    // ���������� ��� ������� �� ������ "���������"
    public void OnBuildButtonClick()
    {
        if (_currentProvince != null && _selectedBuilding != null)
        {
            var building = new GameObject(_selectedBuilding.BuildingName).AddComponent<Building>();
            building.Data = _selectedBuilding;
            building.ParentProvince = _currentProvince;
            building.Construct();
            Hide();
        }
    }
}
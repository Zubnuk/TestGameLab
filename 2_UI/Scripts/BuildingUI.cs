// Assets/2_UI/Scripts/BuildingUI.cs
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BuildingUI : MonoBehaviour
{
    [Header("Компоненты")]
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

    // Вызывается при выборе здания из списка
    public void SelectBuilding(BuildingSO building)
    {
        _selectedBuilding = building;
        _buildingNameText.text = building.BuildingName;
        _buildingCostText.text = $"Стоимость: {building.GoldCost} золота, {building.FoodCost} еды";
    }

    // Вызывается при нажатии на кнопку "Построить"
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
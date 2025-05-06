using System.Collections.Generic;
using UnityEngine;

public class Province : MonoBehaviour
{
    // ��������� ��������� ���� ��� ������������
    public string Name;
    public int Population;
    public int Stability;

    [Header("�������")]
    public int BaseTax = 50;
    public int BaseFood = 30;
    public int UpkeepPerBuilding = 10;

    public List<Building> Buildings = new List<Building>();

    // ����� ��� ������� ��������������
    public int CalculateFoodProduction() => Mathf.RoundToInt(BaseFood * (Population / 500f));

    // ����� ��� ������� ���������� ��������
    public int CalculateUpkeep() => Buildings.Count * UpkeepPerBuilding;

    // ����� ��� ���������� ������
    public ProvinceSaveData GetSaveData() => new ProvinceSaveData(Name, Population, Stability);
    public int CalculateTax()
    {
        return Mathf.RoundToInt(BaseTax * (Population / 1000f) * (Stability / 100f));
    }

    // ����� ��� �������� ������
    public void LoadData(ProvinceSaveData data)
    {
        Name = data.Name;
        Population = data.Population;
        Stability = data.Stability;
    }

    // ���������� ��������� ������ �����
    public void OnMonthUpdate()
    {
        Population += Mathf.RoundToInt(Random.Range(-0.1f, 0.2f) * Population);
        Stability = Mathf.Clamp(Stability + Random.Range(-5, 5), 0, 100);
    }
}
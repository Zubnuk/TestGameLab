using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class ProvinceManager : MonoBehaviour
{
    public List<Province> Provinces = new List<Province>();

    // ������ ������ ������
    public int CalculateTotalTax()
    {
        return Provinces.Sum(province => province.CalculateTax());
    }

    // ������ ������ ��������������
    public int CalculateTotalFood()
    {
        return Provinces.Sum(province => province.CalculateFoodProduction());
    }

    // ������ ������ ����������
    public int CalculateTotalUpkeep()
    {
        return Provinces.Sum(province => province.CalculateUpkeep());
    }

    // ���������� ���� ���������
    public void UpdateProvinces()
    {
        Provinces.ForEach(province => province.OnMonthUpdate());
    }

    // ���������� ������
    public ProvinceSaveData[] GetSaveData()
    {
        return Provinces.ConvertAll(p => p.GetSaveData()).ToArray();
    }

    // �������� ������
    public void LoadData(ProvinceSaveData[] data)
    {
        for (int i = 0; i < Provinces.Count; i++)
        {
            Provinces[i].LoadData(data[i]);
        }
    }
}

[System.Serializable]
public class ProvinceSaveData
{
    public string Name;
    public int Population;
    public int Stability;

    public ProvinceSaveData(string name, int population, int stability)
    {
        Name = name;
        Population = population;
        Stability = stability;
    }
}
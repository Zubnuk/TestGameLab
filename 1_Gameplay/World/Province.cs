using System.Collections.Generic;
using UnityEngine;

public class Province : MonoBehaviour
{
    // Добавляем публичные поля для сериализации
    public string Name;
    public int Population;
    public int Stability;

    [Header("Ресурсы")]
    public int BaseTax = 50;
    public int BaseFood = 30;
    public int UpkeepPerBuilding = 10;

    public List<Building> Buildings = new List<Building>();

    // Метод для расчета продовольствия
    public int CalculateFoodProduction() => Mathf.RoundToInt(BaseFood * (Population / 500f));

    // Метод для расчета содержания построек
    public int CalculateUpkeep() => Buildings.Count * UpkeepPerBuilding;

    // Метод для сохранения данных
    public ProvinceSaveData GetSaveData() => new ProvinceSaveData(Name, Population, Stability);
    public int CalculateTax()
    {
        return Mathf.RoundToInt(BaseTax * (Population / 1000f) * (Stability / 100f));
    }

    // Метод для загрузки данных
    public void LoadData(ProvinceSaveData data)
    {
        Name = data.Name;
        Population = data.Population;
        Stability = data.Stability;
    }

    // Обновление провинции каждый месяц
    public void OnMonthUpdate()
    {
        Population += Mathf.RoundToInt(Random.Range(-0.1f, 0.2f) * Population);
        Stability = Mathf.Clamp(Stability + Random.Range(-5, 5), 0, 100);
    }
}
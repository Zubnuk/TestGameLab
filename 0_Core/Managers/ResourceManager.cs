// 0_Core/Managers/ResourceManager.cs
using UnityEngine;
using System;

public class ResourceManager : MonoBehaviour
{
    public event Action OnResourceChanged; // Добавляем событие

    [Header("Начальные ресурсы")]
    [SerializeField] private int _initialGold = 1000;
    [SerializeField] private int _initialFood = 500;
    [SerializeField] private int _initialTroops = 2000;

    public int Gold { get; private set; }
    public int Food { get; private set; }
    public int Troops { get; private set; }

    private void Start()
    {
        Gold = _initialGold;
        Food = _initialFood;
        Troops = _initialTroops;

        GameManager.Instance.TimeManager.OnMonthPassed += OnMonthPassed;
    }

    private void OnMonthPassed()
    {
        Gold -= GameManager.Instance.ProvinceManager.CalculateTotalUpkeep();
        Food -= Troops / 10;
        OnResourceChanged?.Invoke(); // Уведомляем об изменении
    }

    public void UpdateResources()
    {
        Gold += GameManager.Instance.ProvinceManager.CalculateTotalTax();
        Food += GameManager.Instance.ProvinceManager.CalculateTotalFood();
        OnResourceChanged?.Invoke(); // Уведомляем об изменении
    }

    public void AddGold(int amount)
    {
        Gold += amount;
        OnResourceChanged?.Invoke(); // Уведомляем при ручном изменении
    }

    public void AddFood(int amount)
    {
        Food += amount;
        OnResourceChanged?.Invoke(); // Уведомляем при ручном изменении
    }
    // Методы для сохранения/загрузки
    public ResourceSaveData GetSaveData() => new ResourceSaveData(Gold, Food, Troops);
    public void LoadData(ResourceSaveData data)
    {
        Gold = data.Gold;
        Food = data.Food;
        Troops = data.Troops;
        OnResourceChanged?.Invoke();
    }
}
[System.Serializable]
public class ResourceSaveData
{
    public int Gold;
    public int Food;
    public int Troops;

    public ResourceSaveData(int gold, int food, int troops)
    {
        Gold = gold;
        Food = food;
        Troops = troops;
    }
}
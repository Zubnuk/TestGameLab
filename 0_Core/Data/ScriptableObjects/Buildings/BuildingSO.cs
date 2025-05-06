// 0_Core/Data/ScriptableObjects/Buildings/BuildingSO.cs
using UnityEngine;

[CreateAssetMenu(fileName = "Building_", menuName = "Game/Buildings")]
public class BuildingSO : ScriptableObject
{
    [Header("���������")]
    public string BuildingName;
    public Sprite Icon;

    [Header("�������")]
    public int GoldCost;
    public int FoodCost;
    public int TroopBonus;
    public int FoodProduction;
}
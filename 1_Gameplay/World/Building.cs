// 1_Gameplay/World/Building.cs
using UnityEngine;

public class Building : MonoBehaviour
{
    public BuildingSO Data;
    public Province ParentProvince;

    public void Construct()
    {
        if (!CanAfford()) return;

        GameManager.Instance.ResourceManager.AddGold(-Data.GoldCost);
        GameManager.Instance.ResourceManager.AddFood(-Data.FoodCost);
        ApplyEffects();
    }

    private bool CanAfford()
    {
        return GameManager.Instance.ResourceManager.Gold >= Data.GoldCost
            && GameManager.Instance.ResourceManager.Food >= Data.FoodCost;
    }

    private void ApplyEffects()
    {
        ParentProvince.BaseTax += Data.TroopBonus;
        ParentProvince.BaseFood += Data.FoodProduction;
    }
}
// 0_Core/Data/ScriptableObjects/Events/EventSO.cs
using UnityEngine;

[CreateAssetMenu(fileName = "Event_", menuName = "Game/Events")]
public class EventSO : ScriptableObject
{
    public string EventID;
    public string Title;
    [TextArea] public string Description;

    [Header("Ёффекты")]
    public int GoldEffect;
    public int FoodEffect;
    public int StabilityEffect;
}
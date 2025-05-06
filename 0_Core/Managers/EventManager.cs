// 0_Core/Managers/EventManager.cs
using UnityEngine;
using System.Collections.Generic;

public class EventManager : MonoBehaviour
{
    [SerializeField] private List<GameEvent> _monthlyEvents;

    private void Start()
    {
        GameManager.Instance.TimeManager.OnMonthPassed += TriggerMonthlyEvent;
    }

    private void TriggerMonthlyEvent()
    {
        if (_monthlyEvents.Count == 0) return;

        var randomEvent = _monthlyEvents[Random.Range(0, _monthlyEvents.Count)];
        ApplyEventEffects(randomEvent);
        UIManager.Instance.ShowEventPopup(randomEvent);
    }

    private void ApplyEventEffects(GameEvent gameEvent)
    {
        GameManager.Instance.ResourceManager.AddGold(gameEvent.GoldEffect);
        GameManager.Instance.ResourceManager.AddFood(gameEvent.FoodEffect);
        // Дополнительные эффекты для провинций...
    }
}

[System.Serializable]
public class GameEvent
{
    public string Title;
    public string Description;
    public int GoldEffect;
    public int FoodEffect;
}
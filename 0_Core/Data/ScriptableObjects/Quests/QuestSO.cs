// Assets/0_Core/Data/ScriptableObjects/Quests/QuestSO.cs
using UnityEngine;

[CreateAssetMenu(fileName = "Quest_", menuName = "Game/Quests")]
public class QuestSO : ScriptableObject
{
    public string QuestTitle;
    [TextArea] public string QuestDescription;
    public int GoldReward;
    public int FoodReward;
}
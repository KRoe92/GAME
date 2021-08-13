using UnityEngine;
using GramGames.CraftingSystem.DataContainers;

[CreateAssetMenu(fileName = "GameSettings", menuName = "GameSettings", order = 1)]
public class GameSettings : ScriptableObject
{
    public int CellPercentSpawnChance;
    public NodeContainer[] GameRecipes;
}

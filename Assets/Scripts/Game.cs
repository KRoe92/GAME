using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Game : MonoBehaviourSingleton<Game>
{
	public MergableItem DraggableObjectPrefab;
	public GridHandler MainGrid;
    public GameSettings GameSettings;

    private List<string> _ActiveRecipes = new List<string>();

    protected override void Awake()
    {
        base.Awake();
        Screen.fullScreen =
			false; // https://issuetracker.unity3d.com/issues/game-is-not-built-in-windowed-mode-when-changing-the-build-settings-from-exclusive-fullscreen

		// load all item definitions
		ItemUtils.InitializeMap();
	}

	private void Start()
	{
		ReloadLevel();
	}

	public void ReloadLevel()
	{
		// clear the board
		var fullCells = MainGrid.GetFullCells.ToArray();
		for (int i = fullCells.Length - 1; i >= 0; i--)
			MainGrid.ClearCell(fullCells[i]);

        // choose new recipes
        _ActiveRecipes.Clear();
        int numberOfRecipes = GameSettings.GameRecipes.Length;
        for (int i = 0; i < numberOfRecipes; i++)
        {
            var recipe = GameSettings.GameRecipes[i].MainNodeData.NodeGUID;
            // a 'recipe' has more than 1 ingredient, else it is just a raw ingredient.
            if (GameSettings.GameRecipes[i].NodeData.Count > 1)
            {
                _ActiveRecipes.Add(recipe);
            }
            else
            {
                Debug.LogError("Stop adding " + GameSettings.GameRecipes[i].MainNodeData.NodeText + " to the reicpe list, it's an ingredient", GameSettings);
            }
        }

        if (_ActiveRecipes.Count == 0)
        {
            Debug.LogError("No recipes added to " + GameSettings.name, GameSettings);
            return;
        }

        // populate the board
        var emptyCells = MainGrid.GetEmptyCells.ToArray();
		foreach (var cell in emptyCells)
		{
            if (Random.Range(1, 100) <= GameSettings.CellPercentSpawnChance)
            {
                var chosenRecipe = _ActiveRecipes[Random.Range(0, _ActiveRecipes.Count)];
                var ingredients = ItemUtils.RecipeMap[chosenRecipe].ToArray();
                var ingredient = ingredients[Random.Range(0, ingredients.Length)];
                var item = ItemUtils.ItemsMap[ingredient.NodeGUID];
                cell.SpawnItem(item);
            }
		}
	}
}

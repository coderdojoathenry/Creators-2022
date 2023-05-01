using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GemManager : MonoBehaviour
{
  public GemDefinition[] GemDefinitions;
  public GemRecipe[] GemRecipes;

  public GemDefinition RandomDefinition()
  {
      int index = Random.Range(0, GemDefinitions.Length);
      return GemDefinitions[index];
  }

  public GemDefinition CraftingInputsMatchRecipe(IEnumerable<GemDefinition> craftingInputs)
  {
    if (craftingInputs == null || craftingInputs.Count() != 3)
      return null;

    foreach (GemRecipe recipe in GemRecipes)
    {
      if (recipe.MatchesInput(craftingInputs))
        return recipe.Output;
    }

    return null;
  }
}

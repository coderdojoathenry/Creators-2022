using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "RecipeSystem/Recipe")]
public class Recipe : ScriptableObject
{
    public Ingredient[] inputs;
    public Ingredient output;
}

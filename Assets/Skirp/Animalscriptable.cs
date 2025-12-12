using UnityEngine;

public enum animal
{
    sapi,
    ayam,
    domba    
}

public enum mood
{
    happy,
    ngamuk,
    soso,
    betmut,
    mischevious,
    greedy,
    freaky,
    skibidi,
    senyumboblox,

}

[CreateAssetMenu(fileName ="Animal", menuName ="Scriptable/animal")]
public class Animalscriptable : ScriptableObject
{
    public animal hewan;
    public float weight;
    public float height;
    public mood esmosi;
}

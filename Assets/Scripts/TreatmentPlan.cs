using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Plan", menuName = "ScriptableObjects/TreatmentPlan", order = 1)]
public class TreatmentPlan : ScriptableObject
{
    public string Name;
    public string Description;
    public List<TreatmentStep> Steps;
    public Sprite WoundSprite;
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Step", menuName = "ScriptableObjects/TreatmentStep", order = 1)]
public class TreatmentStep : ScriptableObject
{
    public string Name;
    public string Description;
    public Sprite Sprite;
}

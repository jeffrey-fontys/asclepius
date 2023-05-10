using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Yarn.Unity;

public class ProgressManager : MonoBehaviour
{
    public TreatmentPlan TreatmentPlan;
    public List<TreatmentStepTaken> StepsTaken { get; private set; }
    public UnityEvent StepAdded;

    public int TotalScore { get; private set; } = 0;
    public int TreatmentScore { get; private set; } = 0;
    public int DialogueScore { get; private set; } = 0;
    public int DialogueTotal { get; private set; } = 0;

    private void Start()
    {
        StepsTaken = new List<TreatmentStepTaken>();
    }

    public void TreatmentAction(TreatmentStep step)
    {
        // if step already exists in StepsTaken, ignore step
        if (StepsTaken.Find(x => x.TreatmentStep == step) != null) return;

        TreatmentStepTaken newEntry = new TreatmentStepTaken { TreatmentStep = step };
        if (TreatmentPlan.Steps.Contains(step))
        {
            newEntry.StepValid = true;
            if (TreatmentPlan.Steps[StepsTaken.Count] == step) newEntry.StepInOrder = true;
        }
        StepsTaken.Add(newEntry);
        CalculateScore();
        StepAdded?.Invoke();
    }

    [YarnCommand("set_dialogue_total")]
    public void SetDialogueTotal(int amount)
    {
        DialogueTotal = amount;
    }

    [YarnCommand("add_dialogue_points")]
    public void AddDialoguePoints(int amount = 1)
    {
        DialogueScore += amount;
        CalculateScore();
    }

    private void CalculateScore()
    {
        TreatmentScore = 0;

        foreach (TreatmentStepTaken step in StepsTaken)
        {
            TreatmentScore += (step.StepValid ? 1 : 0) + (step.StepInOrder ? 1 : 0);
        }

        TotalScore = Mathf.CeilToInt((TreatmentScore + DialogueScore) / (TreatmentPlan.Steps.Count * 2f + DialogueTotal) * 100);
    }
}

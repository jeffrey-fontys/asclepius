using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProgressManager : MonoBehaviour
{
    public TreatmentPlan TreatmentPlan;
    public List<TreatmentStepTaken> StepsTaken { get; private set; }
    public int Score { get; private set; } = 0;
    public UnityEvent StepAdded;

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

    private void CalculateScore()
    {
        float score = 0f;
        float increment = 50f / TreatmentPlan.Steps.Count;

        foreach (TreatmentStepTaken step in StepsTaken)
        {
            score += (step.StepValid ? increment : 0) + (step.StepInOrder ? increment : 0);
        }

        Score = Mathf.RoundToInt(score);
    }
}

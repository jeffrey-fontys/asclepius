using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms.Impl;

public class ProgressManager : MonoBehaviour
{
    public TreatmentPlan TreatmentPlan;
    public List<(TreatmentStep, int)> StepsTaken { get; private set; }
    public int Score { get; private set; } = 0;
    public UnityEvent ScoreChanged;

    public void TreatmentAction(TreatmentStep step)
    {
        (TreatmentStep, int) newEntry = (step, 0);
        if (TreatmentPlan.Steps.Contains(step))
        {
            newEntry.Item2 += 1;
            if (TreatmentPlan.Steps[StepsTaken.Count] == step) newEntry.Item2 += 1;
        }
        StepsTaken.Add(newEntry);
        CalculateScore();
    }

    private void CalculateScore()
    {
        float score = 0f;
        float increment = 50f / TreatmentPlan.Steps.Count;

        foreach ((TreatmentStep, int) step in StepsTaken)
        {
            score += step.Item2 * increment;
        }

        Score = Mathf.RoundToInt(score);
        ScoreChanged.Invoke();
    }
}

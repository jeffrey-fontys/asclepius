using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreatmentPlan : MonoBehaviour
{
    public string Name;
    public List<TreatmentStep> Steps;
    public List<TreatmentStep> StepsTaken { get; private set; }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TreatmentAction(TreatmentStep step)
    {
        StepsTaken.Add(step);
    }

    public int CalculateScore()
    {
        float score = 0f;
        float increment = 50f / Steps.Count;

        foreach (TreatmentStep step in Steps)
        {
            if (StepsTaken.Contains(step)) score += increment;
        }
        for (int i = 0; i < Steps.Count; i++)
        {
            if (Steps[i] == StepsTaken[i]) score += increment;
        }

        return Mathf.RoundToInt(score);
    }
}

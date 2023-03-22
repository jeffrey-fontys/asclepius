using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TreatmentDisplay : MonoBehaviour
{
    public TextMeshProUGUI PlanName;
    public GameObject NewStepPrefab;
    public TreatmentPlan Plan;
    public ProgressManager ProgressManager;
    public List<StepDisplay> DisplaySteps { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        DisplaySteps = new List<StepDisplay>();
        PlanName.text = Plan.Name;
        int stepCount = 1;
        foreach (TreatmentStep step in Plan.Steps)
        {
            GameObject newStep = Instantiate(NewStepPrefab, gameObject.transform, true);
            StepDisplay stepDisplay = newStep.GetComponent<StepDisplay>();
            stepDisplay.TreatmentStep = step;
            stepDisplay.SetText(stepCount + ". " + step.Name);
            DisplaySteps.Add(stepDisplay);
            stepCount++;
        }
    }

    public void UpdateDisplay()
    {
        foreach (StepDisplay stepDisplay in DisplaySteps)
        {
            if (stepDisplay.Completed) continue;
            stepDisplay.UpdateStatus(ProgressManager.StepsTaken);
        }
    }
}

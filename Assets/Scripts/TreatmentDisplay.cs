using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TreatmentDisplay : MonoBehaviour
{
    public TextMeshProUGUI PlanName;
    public GameObject NewStepPrefab;
    public TreatmentPlan Plan;
    public List<GameObject> DisplaySteps { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        DisplaySteps = new List<GameObject>();
        PlanName.text = Plan.Name;
        foreach (TreatmentStep step in Plan.Steps)
        {
            GameObject newStep = Instantiate(NewStepPrefab, gameObject.transform, true);
            newStep.GetComponentInChildren<TextMeshProUGUI>().text = "• " + step.Name;
            DisplaySteps.Add(newStep);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

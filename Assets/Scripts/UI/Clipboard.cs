using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Clipboard : MonoBehaviour
{
    public TreatmentPlan TreatmentPlan;
    public TextMeshProUGUI PatientName;
    public TextMeshProUGUI CaseDescription;
    public Image CaseImage;

    // Start is called before the first frame update
    void Start()
    {
        PatientName.text = RandomisePatientName();
        CaseDescription.text = TreatmentPlan.Description;
        CaseImage.sprite = TreatmentPlan.WoundSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private string RandomisePatientName()
    {
        // implement later
        return "Jane Doe";
    }
}

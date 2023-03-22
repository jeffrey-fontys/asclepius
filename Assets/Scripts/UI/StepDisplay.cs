using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StepDisplay : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public TreatmentStep TreatmentStep;
    public Color InOrderColor;
    public Color OutOfOrderColor;
    public bool Completed { get; private set; } = false;

    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    public void SetText(string text)
    {
        Text.text = text;
    }

    public void UpdateStatus(List<TreatmentStepTaken> stepsTaken)
    {
        TreatmentStepTaken step = stepsTaken.Find(x => x.TreatmentStep == TreatmentStep);
        if (step != null)
        {
            _image.color = step.StepInOrder ? InOrderColor : OutOfOrderColor;
            Completed = true;
        }
    }
}

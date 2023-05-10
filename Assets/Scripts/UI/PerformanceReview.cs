using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PerformanceReview : MonoBehaviour
{
    [Serializable]
    public class AwardSpriteSet
    {
        [Range(0, 100)] public int StartValue;
        public Sprite Sprite;
    }

    public GameObject StepPrefab;
    public GameObject StepPanel;
    [Min(0.1f)]public float ScoreAnimationSpeed = 1f;
    public TextMeshProUGUI DialogueScoreText;
    public TextMeshProUGUI TreatmentScoreText;
    public TextMeshProUGUI TotalScoreText;
    public ProgressManager ProgressManager;
    public Image AwardImage;
    public Color OutOfOrderColor = Color.yellow;
    public Color InvalidColor = Color.red;
    public AwardSpriteSet[] AwardSprites;

    private void OnEnable()
    {
        if (DialogueScoreText != null) StartCoroutine(SubScoreAnimation(ProgressManager.DialogueScore, ProgressManager.DialogueTotal, DialogueScoreText));
        if (TreatmentScoreText != null) StartCoroutine(SubScoreAnimation(ProgressManager.TreatmentScore, ProgressManager.TreatmentPlan.Steps.Count * 2, TreatmentScoreText));
        StartCoroutine(TotalScoreAnimation(ProgressManager.TotalScore, TotalScoreText));
    }

    private IEnumerator SubScoreAnimation(int finalScore, int maxScore, TextMeshProUGUI targetText)
    {
        for (int currentDisplayedScore = 0; currentDisplayedScore <= finalScore; currentDisplayedScore++)
        {
            targetText.text = currentDisplayedScore.ToString() + " / " + maxScore.ToString();
            yield return new WaitForSeconds(5f / maxScore * ScoreAnimationSpeed);
        }
    }

    private IEnumerator TotalScoreAnimation(int finalScore, TextMeshProUGUI targetText)
    {
        for (int currentDisplayedScore = 0; currentDisplayedScore <= finalScore; currentDisplayedScore++)
        {
            targetText.text = currentDisplayedScore.ToString() + "%";
            yield return new WaitForSeconds(0.05f * ScoreAnimationSpeed);
        }
        SetAwardSprite();
        PopulateStepPanel();
    }

    private void SetAwardSprite()
    {
        int index = -1;
        foreach (AwardSpriteSet set in AwardSprites) if (ProgressManager.TotalScore >= set.StartValue) index++;
        AwardImage.sprite = AwardSprites[index].Sprite;
    }

    private void PopulateStepPanel()
    {
        foreach (TreatmentStep step in ProgressManager.TreatmentPlan.Steps)
        {
            GameObject newStep = Instantiate(StepPrefab, StepPanel.transform, false);
            newStep.GetComponentInChildren<TextMeshProUGUI>().text = step.Name;
            Image image = newStep.GetComponentInChildren<Image>();
            image.sprite = step.Sprite;
            TreatmentStepTaken stepTaken = ProgressManager.StepsTaken.Find(x => x.TreatmentStep == step);
            if (stepTaken != null && stepTaken.StepValid)
            {
                if (stepTaken.StepInOrder) image.color = Color.white;
                else image.color = OutOfOrderColor;
            }
            else image.color = InvalidColor;
        }
    }
}

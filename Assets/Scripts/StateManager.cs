using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class StateManager : MonoBehaviour
{
    public bool TrainingMode = false;
    public GameObject PerformanceReview;

    [YarnCommand("show_performance_review")]
    public void ShowPerformanceReview()
    {
        PerformanceReview.SetActive(true);
    }

    public void EndLevel()
    {
        SceneManager.LoadScene("Menu");
    }    
}

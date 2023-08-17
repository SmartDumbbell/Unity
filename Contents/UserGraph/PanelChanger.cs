using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelChanger : MonoBehaviour
{
    public GameObject userGraphPanel;
    public GameObject userScorePanel;

    private void Start()
    {
        userGraphPanel.SetActive(true);
        userScorePanel.SetActive(false);
    }
    public void TurnOnScore()
    {
        userGraphPanel.SetActive(false);
        userScorePanel.SetActive(true);
    }

    public void TurnOnGraph()
    {
        userScorePanel.SetActive(false);
        userGraphPanel.SetActive(true);
    }


    public void GoMain()
    {
        SceneManager.LoadScene("Main");
    }
}

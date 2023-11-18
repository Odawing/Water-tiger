using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInterface : MonoBehaviour
{
    public TextMeshProUGUI collectedShellfishText;

    [SerializeField]
    private GameObject pauseMenuPanel;
    [SerializeField]
    private GameObject endGamePanel;
    [SerializeField]
    private TextMeshProUGUI collectedPearlsEndMenu, recordText;

    public void UpdateShellfishCounter(int count)
    {
        collectedShellfishText.text = count.ToString();
    }

    public void PauseBtn()
    {
        pauseMenuPanel.SetActive(!pauseMenuPanel.activeSelf);
        Time.timeScale = pauseMenuPanel.activeSelf ? 0 : 1;
    }

    public void ShowEndGameMenu()
    {
        collectedPearlsEndMenu.text = GameManagerScr.Instance.collectedShellfish.ToString();

        if (PlayerPrefs.GetInt("CollectedPearlsRecord") < GameManagerScr.Instance.collectedShellfish)
        {
            PlayerPrefs.SetInt("CollectedPearlsRecord", GameManagerScr.Instance.collectedShellfish);
            recordText.gameObject.SetActive(true);
        }

        endGamePanel.SetActive(true);
    }

    public void RestartGameBtn()
    {
        SceneManager.LoadScene(0);
    }
}
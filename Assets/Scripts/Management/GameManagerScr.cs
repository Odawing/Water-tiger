using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScr : MonoBehaviour
{
    public static GameManagerScr Instance;

    public GameInterface gameInterface;

    public Tiger tigerPlayer;

    public int collectedShellfish;

    private void Awake()
    {
        Instance = this;
    }

    public void CollectShellFish()
    {
        collectedShellfish++;
        gameInterface.UpdateShellfishCounter(collectedShellfish);
    }

    public void LoseGame()
    {
        if (!PlayerPrefs.HasKey("CollectedPearlsRecord"))
            PlayerPrefs.SetInt("CollectedPearlsRecord", collectedShellfish);

        gameInterface.ShowEndGameMenu();
    }
}
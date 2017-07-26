using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ScoreManager : NetworkBehaviour {

    [SyncVar(hook="UpdateScoreOne")]
    private int playerOneScore;

    [SyncVar(hook="UpdateScoreTwo")]
    private int playerTwoScore;

    public GameObject scoreOneText;
    public GameObject scoreTwoText;
	// Use this for initialization
	void Start () {
        playerOneScore = 0;
        playerTwoScore = 0;
	}
    public void PlayerOneScores()
    {
        UpdateScoreOne(++playerOneScore);
    }
    public void PlayerTwoScores()
    {
        UpdateScoreTwo(++playerTwoScore);
    }
    public void UpdateScoreOne(int value)
    {
        scoreOneText.GetComponent<Text>().text = value.ToString();
    }
    public void UpdateScoreTwo(int value)
    {
        scoreTwoText.GetComponent<Text>().text = value.ToString();
    }

    public int GetPlayerOneScore()
    {
        return playerOneScore;
    }
    public int GetPlayerTwoScore()
    {
        return playerTwoScore;
    }
}

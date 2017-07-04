using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private BrickManager BrickManager;

	private void Start () {
        BrickManager = FindObjectOfType<BrickManager>();
        StartGame();
	}

	private void StartGame()
    {
        BrickManager.CreateBrick();
    }

    public void CheckIsWill()
    {
        if(BrickManager.IsWill())
        {
            Debug.Log("You Will!");
        }
    }

    public void Lost()
    {
        BrickManager.ShowAllMine();
        Debug.Log("You Lost!");
    }
}

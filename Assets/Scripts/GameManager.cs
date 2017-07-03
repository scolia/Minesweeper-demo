using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public int Width = 15;
    public int Height = 15;
    public float IsMinePercent = 0.15f;

    private BrickManager BrickManager;

	void Start () {
        BrickManager = FindObjectOfType<BrickManager>();

        StartGame();
	}
	
    void StartGame()
    {
        BrickManager.CreateBrick(Width, Height);
    }
}

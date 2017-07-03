using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {

    public static Brick[,] GridDate;

    private void Start()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        int x = gameManager.Width;
        int y = gameManager.Height;
        GridDate = new Brick[x, y];
    }

}

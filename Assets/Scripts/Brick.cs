using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public bool IsMine;

    private GameManager GameManager;
    private BrickManager BrickManager;

    private void Start()
    {
        GameManager = FindObjectOfType<GameManager>();
        BrickManager = FindObjectOfType<BrickManager>();

        IsMine = Random.value <= GameManager.IsMinePercent; //设置本身是否为地雷
        Vector2 originPoint = BrickManager.transform.position;
        int x = (int)(transform.position.x - originPoint.x);
        int y = (int)(transform.position.y - originPoint.y);
        Grid.GridDate[x, y] = this;
    }

    private void OnMouseUp()
    {
        Debug.Log(IsMine);
    }
}

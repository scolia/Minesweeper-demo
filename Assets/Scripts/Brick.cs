using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public bool IsMine;
    public bool IsCover = true;

    private BrickManager BrickManager;
    private GameManager GameManager;
    private Vector2 PositionInGrid;

    private void Start()
    {
        BrickManager = FindObjectOfType<BrickManager>();
        GameManager = FindObjectOfType<GameManager>();
        Vector2 originPoint = BrickManager.transform.position;
        int x = (int)(transform.position.x - originPoint.x);
        int y = (int)(transform.position.y - originPoint.y);
        PositionInGrid = new Vector2(x, y);

        IsMine = Random.value <= BrickManager.IsMinePercent; //设置本身是否为地雷
        BrickManager.GridDate[x, y] = this; //将自己添加到网格数据中去
    }

    private void OnMouseUp()
    {
        if(IsMine)
        {
            BrickManager.ShowAllMine();
            GameManager.Lost();
        }
        else
        {
            BrickManager.FloodFill((int)PositionInGrid.x, (int)PositionInGrid.y, new bool[BrickManager.Width, BrickManager.Height]);
            GameManager.CheckIsWill();
        }
    }


}

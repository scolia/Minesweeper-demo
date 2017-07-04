using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour {

    public int Width = 15;
    public int Height = 15;
    public static Brick[,] GridDate;
    public float IsMinePercent = 0.15f;

    public GameObject Brick;
    public Sprite[] Sprite;
    public Sprite MineSprite;

    private void Start()
    {
        GridDate = new Brick[Width, Height];    // 初始化网格数据
    }

    /// <summary>
    /// 生成砖块
    /// </summary>
    public void CreateBrick()
    {
        Vector2 originPoint = transform.position;
        for (int y = 0; y < Height; y++)
        {
            for(int x = 0; x < Width; x++)
            {
                Instantiate(Brick, new Vector2(originPoint.x + x, originPoint.y + y), Quaternion.identity);      
            }
            
        }
    }

    /// <summary>
    /// 显示所有的地雷
    /// </summary>
    public void ShowAllMine()
    {
        foreach(Brick brick in GridDate)
        {
            if (brick.IsMine)
            {
                brick.gameObject.GetComponent<SpriteRenderer>().sprite = MineSprite;
                brick.IsCover = false;
            }
        }
    }

    /// <summary>
    /// 检查网格数据中, 特定的砖块是否为地雷
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    private bool BrickIsMine(int x, int y)
    {
        if (x >= 0 && x < Width && y >= 0 && y < Height)
        {
            return GridDate[x, y].IsMine;
        }
        return false;
    }

    /// <summary>
    /// 检查特定位置的砖块的附近8个砖块中地雷的数量
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public int NearbyMineCount(int x, int y)
    {
        int count = 0;
        if(BrickIsMine(x, y + 1)) // 上方
        {
            count++;
        }
        if(BrickIsMine(x - 1, y + 1)) // 左上
        {
            count++;
        }
        if (BrickIsMine(x + 1, y + 1))  // 右上
        {
            count++;
        }
        if(BrickIsMine(x - 1, y))  // 左
        {
            count++;
        }
        if (BrickIsMine(x + 1, y))  //  右
        {
            count++;
        }
        if(BrickIsMine(x - 1, y - 1))  // 左下
        {
            count++;
        }
        if(BrickIsMine(x, y - 1))  // 下
        {
            count++;
        }
        if(BrickIsMine(x + 1, y - 1))  // 右下
        {
            count++;
        }

        return count;
    }

    /// <summary>
    /// 通过临近的地雷的数量来修改sprite
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    public void ChangeSpriteByNearbyMineCount(int x, int y, int count)
    {
        GridDate[x, y].GetComponent<SpriteRenderer>().sprite = Sprite[count];
        GridDate[x, y].IsCover = false;
    }

    /// <summary>
    /// 使用漫水算法递归翻开空白的格子
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="visited"></param>
    public void FloodFill(int x, int y, bool[,] visited)
    {
        if (x >= 0 && y >= 0 && x < Width && y < Height)
        {
            if (visited[x, y])
            {
                return;
            }
            visited[x, y] = true;

            int count = NearbyMineCount(x, y);
            ChangeSpriteByNearbyMineCount(x, y, count);
            if (count > 0)
            {
                return;
            }

            FloodFill(x, y + 1, visited);  //  上
            FloodFill(x - 1, y, visited);  //  左
            FloodFill(x, y - 1, visited);  //  下
            FloodFill(x + 1, y, visited);  //  右
        }

    }

    /// <summary>
    /// 判断是否胜利
    /// </summary>
    /// <returns></returns>
    public bool IsWill()
    {
        foreach(Brick brick in GridDate)
        {
            if(brick.IsCover && !brick.IsMine)      // 当还有覆盖的非地雷砖块时, 就还不算胜利
            {
                return false;
            }
        }
        return true;
    }
}

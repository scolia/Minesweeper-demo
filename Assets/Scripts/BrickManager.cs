using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour {

    public GameObject Brick;

    /// <summary>
    /// 生成砖块
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    public void CreateBrick(int width, int height)
    {
        Vector2 originPoint = transform.position;
        for (int y = 0; y < height; y++)
        {
            for(int x = 0; x < width; x++)
            {
                Instantiate(Brick, new Vector2(originPoint.x + x, originPoint.y + y), Quaternion.identity);      
            }
            
        }
    }
}

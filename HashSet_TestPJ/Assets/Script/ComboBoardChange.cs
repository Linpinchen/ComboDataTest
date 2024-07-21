using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;

public class ComboBoardChange : MonoBehaviour
{

    List<int>[] ServerBoard;
    HashSet<int>[] WinIndex;
    LinkedList<int>[] OriginData;
    List<int> IconChange;
    // Start is called before the first frame update
    void Start()
    {

        //===================================================================================================

        //模擬的資料內容


        OriginData = new LinkedList<int>[4];


        ServerBoard = new List<int>[]
        {
            new List<int> { 0, 1, 2, 3},
            new List<int> { 4,5 , 6, 7},
            new List<int> { 8, 9, 10, 11},
            new List<int> { 12, 13, 14, 15},
        };

        WinIndex = new HashSet<int>[]
        {
            new HashSet<int> { 0, 2,},
            new HashSet<int> { 0, },
            new HashSet<int> { 1, 2,},
            new HashSet<int> { 0, 1,3},

        };

        IconChange = new List<int> { 100, 200, 300, 400, 500, 600, 700, 800 };

        for (int i = 0; i < ServerBoard.Length; i++)
        {
            OriginData[i] = new LinkedList<int>();
            for (int j = 0; j < ServerBoard[i].Count; j++)
            {
                OriginData[i].AddFirst(ServerBoard[i][j]);
            }
        }


        //=====================================================================================================

        // 資料層 解析  << 矩形>>

        //要回傳的新盤面
        List<int>[] newBoard = new List<int>[ServerBoard.Length];

        int changeIndex = 0;

        for (int i = 0; i < ServerBoard.Length; i++)
        {
            List<int> NoWin = new List<int>();
            newBoard[i] = new List<int>();
            for (int j = 0; j < ServerBoard[i].Count; j++)
            {
                if (WinIndex[i].Contains(j))
                {
                    newBoard[i].Add(IconChange[changeIndex]);
                    changeIndex++;
                }
                else
                {
                    NoWin.Add(ServerBoard[i][j]);
                }
            }

            newBoard[i].AddRange(NoWin);

            string s = $" newBoard[{i}] : ";
            for (int ii = 0; ii < newBoard[i].Count; ii++)
            {
                s += $"{newBoard[i][ii]}, ";
            }

            // Debug.Log(s);
        }






        //==========================================================================

        // 資料層 解析  << 不規則 >> 假設 第二 跟 三個輪條最上方的資料都要一直是99 




        var ServerBoard2 = new List<int>[]
        {
            new List<int> { 0, 1, 2, 3},
            new List<int> { 90,5 , 6, 7},
            new List<int> { 90, 9, 10, 11},
            new List<int> { 12, 13, 14, 15},
        };


        var WinIndex2 = new HashSet<int>[ServerBoard2.Length];


        //做個隨機產 WinIndex
        for (int i = 0; i < WinIndex2.Length; i++)
        {
            WinIndex2[i] = new HashSet<int>();
            string WindexString = $"WinIndex2[{i}] :";
            int itemCount = i == 1 || i == 2 ? Random.Range(0, 3) : Random.Range(0, 4);
            for (int j = 0; j < itemCount; j++)
            {
                int indexCount = i == 1 || i == 2 ? Random.Range(1, 4) : Random.Range(0, 4);
                WinIndex2[i].Add(indexCount);
            }

            foreach (var value in WinIndex2[i])
            {
                WindexString += $"{value} , ";
            }

            Debug.Log(WindexString);
        }



        List<int>[] newBoard2 = new List<int>[ServerBoard2.Length];

        int changeIndex2 = 0;

        for (int i = 0; i < ServerBoard2.Length; i++)
        {
            List<int> NoWin = new List<int>();
            newBoard2[i] = new List<int>();

            for (int j = 0; j < ServerBoard2[i].Count; j++)
            {
                if ((i == 1 || i == 2) && j == 0)
                {
                    newBoard2[i].Add(ServerBoard2[i][j]);
                }
                else if (WinIndex2[i].Contains(j))
                {
                    newBoard2[i].Add(IconChange[changeIndex2]);
                    changeIndex2++;
                }
                else
                {
                    NoWin.Add(ServerBoard2[i][j]);
                }
            }

            newBoard2[i].AddRange(NoWin);

            string s = $" newBoard[{i}] : ";
            for (int ii = 0; ii < newBoard2[i].Count; ii++)
            {
                s += $"{newBoard2[i][ii]}, ";
            }

            Debug.Log(s);
        }












        /*
        
        須注意 LinkedList 的資料順序是否與 演藝物件順序依樣 (這裡故意與 ServerBoard 相反 來模擬)
        
        
        
        */

    }

    // Update is called once per frame
    void Update()
    {

    }
}

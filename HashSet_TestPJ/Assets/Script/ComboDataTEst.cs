using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ComboDataTEst : MonoBehaviour
{
    private List<int>[] OriginData;
    private HashSet<int>[] WinIndex;
    private List<int> supplementIconData;



    // Start is called before the first frame update
    void Start()
    {
        // OriginData = new List<int>[]
        // {
        //     new List<int>{0,1,2},
        //     new List<int>{3,4,5},
        //     new List<int>{6,7,8},
        //     new List<int>{9,10,11},
        // };

        // WinIndex = new HashSet<int>[]
        // {
        //     new HashSet<int>{0,1},
        //     new HashSet<int>{1},
        //     new HashSet<int>{2},
        //     new HashSet<int>{0},
        // };

        // supplementIconData = new List<int> { 20, 20, 20, 20, 20 };


        //將資料補到最後

        // 透過 List 刪資料往前補的特性來做 , !! 由於會往前補 所以要記錄 已刪除次數 , 將索引值的內容 - 已刪除次數
        // 才會取得正確的 索引值

        // 初始数据
        List<int>[] OriginData = {
            new List<int> { 0, 1, 2 },
            new List<int> { 3, 4, 5 }
        };

        HashSet<int>[] WinIndex = {
            new HashSet<int> { 1 },
            new HashSet<int> { 0, 2 }
        };

        List<int> supplementIconData = new List<int> { 100, 101, 102, 103, 104, 105 };
        int ChangeCount = 0;

        // 遍历 WinIndex
        for (int i = 0; i < WinIndex.Length; i++)
        {
            // var indices = WinIndex[i].OrderByDescending(x => x).ToList();
            List<int> changeData = new List<int>();
            var tamp = 0;
            foreach (int index in WinIndex[i])
            {

                int newValue = supplementIconData[ChangeCount];

                if (tamp != 0)
                {
                    // 将原值移到当前数组的尾部
                    OriginData[i].RemoveAt(Mathf.Abs(tamp - index));
                    changeData.Add(newValue);
                }
                else
                {
                    OriginData[i].RemoveAt(index);
                    changeData.Add(newValue);
                }

                tamp++;
                ChangeCount++;
            }

            OriginData[i].AddRange(changeData);
        }
        // 打印结果
        for (int i = 0; i < OriginData.Length; i++)
        {
            string text = $"OriginData[{i}] : ";
            foreach (var item in OriginData[i])
            {
                text += $"{item} ,";
            }
            Debug.Log(text);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}

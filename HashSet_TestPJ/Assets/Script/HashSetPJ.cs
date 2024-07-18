using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;
using UnityEngine;

public class HashSetPJ : MonoBehaviour
{

    private HashSet<int>[] TestDataA;
    private HashSet<int>[] TestDataB;

    // Start is called before the first frame update
    void Start()
    {
        //Data = new HashSet<int>[3];
        TestDataA = new HashSet<int>[]
        {
            new HashSet<int>{1,2,3},
            new HashSet<int>{4,5,6},
            new HashSet<int>{7,8,9}
        };
        TestDataB = new HashSet<int>[]
        {
            new HashSet<int>{1,2,3},
            new HashSet<int>{10,11,12},
            new HashSet<int>{13,14,15}
        };

        //==========================================================================================================

        //將兩個HashSet集合的內容 合併 , 重複的不會添加 只添加不重複的內容
        for (var item = 0; item < TestDataA.Length; item++)
        {
            // TestDataA.Union(TestDataB);
            TestDataA[item].UnionWith(TestDataB[item]);
        }

        //印值
        for (var item = 0; item < TestDataA.Length; item++)
        {
            string s = "";
            foreach (var index in TestDataA[item])
            {
                s += $"{index},";
            }

            Debug.Log(s);
        }

        //============================================================================================

        // 多個HashSet 資料合併 
        // !! 當作基底的資料 必須有內容

        HashSet<int>[] TestDataC = new HashSet<int>[]
               {
            new HashSet<int>{1,3},
            new HashSet<int>{4,6},
            new HashSet<int>{3}
               };
        HashSet<int>[] TestDataD = new HashSet<int>[]
        {
            new HashSet<int>{1,},
            new HashSet<int>{4,3},
            new HashSet<int>{1,2}
        };

        HashSet<int>[] TestDataE = new HashSet<int>[]
        {
            new HashSet<int>{0,4},
            new HashSet<int>{5,0},
            new HashSet<int>{1}
        };


        List<HashSet<int>[]> totalData = new List<HashSet<int>[]>();

        totalData.Add(TestDataC);
        totalData.Add(TestDataD);
        totalData.Add(TestDataE);

        //要回傳的 合併完成的資料
        // HashSet<int>[] resultData = new HashSet<int>[3];
        HashSet<int>[] resultData = new HashSet<int>[]
        {
            new HashSet<int>{0,},
            new HashSet<int>{1},
            new HashSet<int>{2}
        };

        for (int i = 0; i < totalData.Count; i++)
        {
            for (int j = 0; j < resultData.Length; j++)
            {
                resultData[j].UnionWith(totalData[i][j]);
            }
        }

        //印值測試
        for (var item = 0; item < resultData.Length; item++)
        {
            string s2 = "";
            foreach (var index in resultData[item])
            {
                s2 += $"{index},";
            }

            Debug.Log(s2);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

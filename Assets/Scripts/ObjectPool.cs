using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UIElements;


public class ObjectPool : MonoBehaviour
{
    // オブジェクトプール
    // 生成 -> 表示
    // 破壊 -> 非表示

    // そのために
    // あらかじめオジェクトを複数ためておく：pool
    // 使う時に表示
    // いらなくなったら非表示

    [SerializeField] GameObject prefabObj;
    List<GameObject> pool;

    public void CreatePool(int maxCount)
    {
        pool = new List<GameObject>();
        for (int i=0; i<maxCount; i++)
        {
            GameObject obj = Instantiate(prefabObj);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }
    public GameObject GetObj(Vector2 position)
    {
        for(int i=0; i<pool.Count; i++)
        {
            if (pool[i].activeSelf == false)
            {
                GameObject obj = pool[i];
                obj.transform.position = position;
                obj.SetActive(true);
                return obj;
            }
        }
        GameObject newObj = Instantiate(prefabObj, position, Quaternion.identity);
        newObj.SetActive(false);
        pool.Add(newObj);
        return newObj;
    }

}

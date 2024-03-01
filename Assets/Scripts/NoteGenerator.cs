using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteGenerator : MonoBehaviour
{

    // Noteを生成する
    [SerializeField] ObjectPool objectPool;
    private void Awake()
    {
        objectPool.CreatePool(10);
    }
    public void SpawnNote(Vector3 pos)
    {
        objectPool.GetObj(pos);
    }

}

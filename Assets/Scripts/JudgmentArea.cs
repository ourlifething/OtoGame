using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgmentArea : MonoBehaviour
{
    // ノーツが落ちてきた時に、キーボードを押したら判定したい
    // ・キー入力
    // ・近くにノーツがあるか
    // ・どれくらいの近さなのか＝＞評価
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("aを入力"); 
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgmentArea : MonoBehaviour
{
    // ノーツが落ちてきた時に、キーボードを押したら判定したい
    // ・キー入力
    // ・近くにノーツがあるか:Rayをとばして当たったら近い！

    // ・どれくらいの近さなのか＝＞評価

    [SerializeField] float radius;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("aを入力"); 
            RaycastHit2D hit2D =  Physics2D.CircleCast(transform.position, radius, Vector3.zero);
            if (hit2D)
            {
                Debug.Log("ノーツがぶつかった！");
                // ぶつかったものを破壊する
                Destroy(hit2D.collider.gameObject);
            }
        }
    }
    //可視化ツール
    void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, radius);
    }
}

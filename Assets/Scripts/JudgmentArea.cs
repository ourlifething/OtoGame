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

    // GameManagerのAddScoreを実行したい
    [SerializeField] Gamemanager gameManager = default;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("aを入力"); 
            RaycastHit2D hit2D =  Physics2D.CircleCast(transform.position, radius, Vector3.zero);
            if (hit2D)
            {
                Debug.Log("ノーツがぶつかった！");
                float distance = Mathf.Abs(hit2D.transform.position.y - transform.position.y);
                if (distance < 3)
                {
                    //Debug.Log("Good!");
                    gameManager.AddScore(100);
                }
                else if (distance <5)
                {
                    //Debug.Log("まあまあ");
                    gameManager.AddScore(10);
                }
                else
                {
                    Debug.Log("えーーー！");
                    gameManager.AddScore(0);
                }
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

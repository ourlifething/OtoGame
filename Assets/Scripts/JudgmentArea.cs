using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class JudgmentArea : MonoBehaviour
{

    [SerializeField] float radius;
    // GameManagerのAddScoreを実行
    [SerializeField] Gamemanager gameManager = default;
    [SerializeField] KeyCode keyCode;
    [SerializeField] GameObject textEffectPrefab;
    private void Update()
    {
        if (Input.GetKeyDown(keyCode))
        {
            RaycastHit2D[] hits2D =  Physics2D.CircleCastAll(transform.position, radius, Vector3.zero);
            // 並び替えて一番小さい数を消す
            if(hits2D.Length == 0)
            {
                return;
            }
            List<RaycastHit2D> reycastHit2Ds = hits2D.ToList();
            reycastHit2Ds.Sort((a,b) => (int)(a.transform.position.y - b.transform.position.y));
            RaycastHit2D hit2D = reycastHit2Ds[0];

            if (hit2D)
            {
                // Debug.Log("ノーツがぶつかった！");
                float distance = Mathf.Abs(hit2D.transform.position.y - transform.position.y);
                if (distance < 3)
                {
                    //Debug.Log("Good!");
                    gameManager.AddScore(100);
                    SpawnTextEffect("Excellent",hit2D.transform.position);
                }
                else if (distance <5)
                {
                    //Debug.Log("まあまあ");
                    gameManager.AddScore(10);
                    SpawnTextEffect("Good",hit2D.transform.position);
                }
                else
                {
                    //Debug.Log("えーーー！");
                    gameManager.AddScore(0);
                    SpawnTextEffect("Bad",hit2D.transform.position);
                }
                // ぶつかったものを破壊する
                //Destroy(hit2D.collider.gameObject);
                hit2D.collider.gameObject.SetActive(false);
            }
        }
    }
    void SpawnTextEffect(string message, Vector3 position)
    {
        GameObject effect = Instantiate(textEffectPrefab, position, quaternion.identity);
        JudgementEffect judgementEffect = effect.GetComponent<JudgementEffect>();
        judgementEffect.SetText(message);
        //Destroy(effect, 0.5f);
    }
    //可視化ツール
    void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, radius);
    }
}

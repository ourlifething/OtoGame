using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Gamemanager : MonoBehaviour
{
    // TODO : ゲーム開始の実装
    // コルーチンを使う：時間を制御したい 3.2.1のカウントダウン
    //タイムラインのplay on awakeを外してスクリプトでタイムライン再生したい
    // ゲームの実装：タイムラインの終了を検知する。
    // シグナル(signal)を使う
    [SerializeField] PlayableDirector playableDirector;
    void Start()
    {
        StartCoroutine(GameMain());
    }
    IEnumerator GameMain()
    {
        Debug.Log("3");
        yield return new WaitForSeconds(1);
        Debug.Log("2");
        yield return new WaitForSeconds(1);
        Debug.Log("1");
        yield return new WaitForSeconds(1);
        Debug.Log("Go");
        yield return new WaitForSeconds(0.3f);
        Debug.Log("ゲーム開始！");
        playableDirector.Play();
    }

    public void OnEndEvent()
    {
        Debug.Log("ゲーム終了");
    }

}

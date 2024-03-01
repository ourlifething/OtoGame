using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    [SerializeField] Text countDounText = default;
    // ゲーム終了時のリザルトパネルの表示
    [SerializeField] GameObject resultPanel = default;

    // スコア上昇：scoreの数値を大きくするuiにはんえいさせる
    [SerializeField] Text scoreText = default;
    [SerializeField] Text resultScoreText = default;
    [SerializeField] PlayableDirector playableDirector;

    

    // スコアの実装
    int score;

    void Start()
    {
        StartCoroutine(GameMain());
    }
    IEnumerator GameMain()
    {
        yield return new WaitForSeconds(1);
        countDounText.text = "3";
        //Debug.Log("3");
        yield return new WaitForSeconds(1);
        countDounText.text = "2";
        //Debug.Log("2");
        yield return new WaitForSeconds(1);
        countDounText.text = "1";
        //Debug.Log("1");
        yield return new WaitForSeconds(1);
        countDounText.text = "GO!";
        //Debug.Log("Go");
        yield return new WaitForSeconds(0.8f);
        countDounText.text = "";
        //Debug.Log("ゲーム開始！");
        playableDirector.Play();
    }
    public void AddScore(int point)
    {
        score += point;
        // テキストを表示させる
        scoreText.text = score.ToString();
        //Debug.Log(score);
    }
    public void OnEndEvent()
    {
        Debug.Log("ゲーム終了");
        // リザルトパネルの表示
        resultScoreText.text = score.ToString();
        resultPanel.SetActive(true);
    }

    // リトライボタン：シーンの再読み込み
    public void OnRetry()
    {
        SceneManager.LoadScene("Main");
    }

}

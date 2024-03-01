using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    // noteが下に落ちる仕様
    // TODO:落ちる速度を曲と判定場所との距離から設定する必要がある
    // 音を１小節遅らせて鳴らす -> ノーツは１小節分早く生成される
    // 判定場所にきた時に音が鳴れば良い -> 速度：判定場所までの距離/１小節の長さ（s）
    float speed;

    // １小節の長さBPM120（60秒に120回音が入る）1回あたり0.5秒
    // BPMからけいさんする（４＊６０ / BPM )
    // 1小節に：音が４回鳴る（４部音符）4＊0.5 = 2秒 -> 1小説の長さは2秒
    // 判定場所までの距離はいくらか:Unity側の問題
    // 70-(-50) = 120

    private void Start() {
        speed = 60; // 120 /2
    }
    void Update()
    {
        transform.Translate(0, -speed * Time.deltaTime, 0);
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class change : MonoBehaviour
{
    // Use this for initialization
    int count;//timerでclearの値を入れておくための変数

    void Start()
    {
        //timerでclearの値をここで使えるようにする
        count = timer.c();
    }

    void Update()
    {
        string nowscene = SceneManager.GetActiveScene().name;//プレイヤーがいるシーン名を取得する。ステージの判定などに使う
        //ポーズ画面（ステージクリア後に遷移する画面）での処理
        if (nowscene == "pose")
        {
            //ここでの処理はreturnキーに設定してます
            if (Input.GetKeyDown("return"))
            {
                //第一ステージをクリアしていた場合、returnを押したら第二ステージに進むようにする
                if (count == 1)
                {
                    SceneManager.LoadScene("Stage2");
                }
                //第二ステージをクリアしていた場合、returnを押したら第三ステージに進むようにする
                else if (count == 2)
                {
                    SceneManager.LoadScene("Stage3");
                }
            }
        }

        //スタート画面での処理
        else if (nowscene == "Start")
        {
            if (Input.GetKeyDown("return"))
            {
                //returnキーを押したらゲーム開始（第一ステージに進む）するようにする
                SceneManager.LoadScene("SampleScene");
            }
        }

        //ゲームを再スタート（タイトルに戻る）
        else if (nowscene == "gameover"||nowscene=="gameclear")
        {
            if (Input.GetKeyDown("return"))//returnキーで戻れるようにしていますが、他のキーに変更しても大丈夫です
            {
                //returnキーを押したらタイトルに戻るようにする
                SceneManager.LoadScene("start");
            }
        }
    }
}
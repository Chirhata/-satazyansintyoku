using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour
{
    public Text timerText;

    public float totalTime;//制限時間。UnityのGameObject (1)で長さは調整できる（望みの時間＋１ぐらいにするとちょうどいい）
    float seconds;//制限時間の値を格納しておく変数。
    public static int clear = 0;//ステージクリア回数。ステージをクリアすると１ずつ加算される。３になるとゲームクリア。
    static int load = 0;//最初にスタート画面から始めるようにするための変数。スタート画面に飛んだ後は使わない。


    // Use this for initialization
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        totalTime -= Time.deltaTime;//制限時間をここで減らす
        seconds = (int)totalTime;//残り時間をint型に変換する
        timerText.text = seconds.ToString();//残り時間を画面に表示する
        string nowscene = SceneManager.GetActiveScene().name;//プレイヤーがいるシーン名を取得する。ステージの判定などに使う
        //始まった瞬間強制的にスタート画面に飛ばし、変な場面から始まらないようにする
        if (load <= 500)
        {
            SceneManager.LoadScene("Start");
            load = 9999;
        }
        ///////第一ステージでの処理
        else if (nowscene == "SampleScene")
        {
            //制限時間が来たらゲームオーバー画面に遷移する
            if (totalTime <= 0.0140065)
            {
                totalTime = 0;
                clear = 0;
                SceneManager.LoadScene("gameover");
            }
            //泥棒を見つけたら（今は仮なのでreturnキーで代用）ポーズ画面に遷移する
            else{
                if (Input.GetKeyDown("return"))
                {
                    clear += 1;
                    {
                        SceneManager.LoadScene("pose");
                    }
                }
            }
        }
        ///////第二ステージでの処理
        else if (nowscene == "Stage2")
        {
            //制限時間が来たらゲームオーバー画面に遷移する
            if (totalTime <= 0.0140065)
            {
                totalTime = 0;
                clear = 0;
                SceneManager.LoadScene("gameover");
            }
            else
            {
                //泥棒を見つけたら（今は仮なのでreturnキーで代用）ポーズ画面に遷移する
                if (Input.GetKeyDown("return"))
                {
                    clear += 1;
                    {
                        SceneManager.LoadScene("pose");
                    }
                }
            }
        }
        ///////第三ステージでの処理
        else if (nowscene == "Stage3")
        {
            //制限時間が来たらゲームオーバー画面に遷移する
            if (totalTime <= 0.0140065)
            {
                totalTime = 0;
                clear = 0;
                SceneManager.LoadScene("gameover");
            }
            else
            {
                //泥棒を見つけたら（今は仮なのでreturnキーで代用）ゲームクリア画面に遷移する
                if (Input.GetKeyDown("return"))
                {
                    timerText.text = "0";
                    clear = 0;
                    SceneManager.LoadScene("gameclear");
                }
            }
        }
    }
    //ステージクリア時に加算される変数、clearの値を他のスクリプトで呼び出せるようにする
    public static int c()
    {
        return clear;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//ゲーム全体の仕組みにかかわる、汎用的な管理を行うスクリプト
public class GameManager : MonoBehaviour {
    public bool isGamePlaying = false;  //ゲームがスタートしているか
    PlayerManager playerManager;

    private Text countDownTimerTextSeconds;  //秒の部分用のテキスト
    private Text countDownTimerTextMiliSeconds;  //ミリ秒の部分用のテキスト

    private int seconds;  //秒の部分
    private int miliSeconds;  //ミリ秒の部分
    private float count = 10f;

    //タイムオーバーの爆発音用
    AudioSource audioSource;
    
    GameObject[] bombs;  //全爆弾を入れるためのリスト
    [SerializeField] Sprite explosionSprite;  //タイムオーバーしたときのSprite
    [SerializeField] Sprite bombSprite;  //爆弾の平常時のSprite

    void Start() {
        playerManager = GameObject.Find("Player").GetComponent<PlayerManager>();
        countDownTimerTextSeconds = GameObject.Find("TextCountDownTimerSeconds").GetComponent<Text>();
        countDownTimerTextMiliSeconds = GameObject.Find("TextCountDownTimerMiliSeconds").GetComponent<Text>();
        audioSource = GetComponent<AudioSource>();
        bombs = GameObject.FindGameObjectsWithTag("Bomb");
    }

    void Update() {
        //ゲームがプレイ中のみ時計が動く
        if (isGamePlaying) {
            count -= Time.deltaTime;  //毎フレームごとの時間を計算

            //秒の部分
            seconds = (int)(Math.Ceiling(count) - 1);
            //秒の表示
            countDownTimerTextSeconds.text = " " + seconds.ToString();

            //ミリ秒の部分
            miliSeconds = (int)((count - (float)seconds) * 100);
            //ミリ秒の表示
            countDownTimerTextMiliSeconds.text = miliSeconds.ToString() + "0";
        }

        //countの範囲の指定
        if (count < 0) {
            isGamePlaying = false;  //制限時間を過ぎるとプレイは終了
            count = 0;
            countDownTimerTextSeconds.text = " 0";
            countDownTimerTextMiliSeconds.text = "00";

            //タイムオーバーの爆発音を鳴らす
            audioSource.Play();

            //画面上にある爆弾のSpriteをすべて爆発画像に変える
            foreach(GameObject bom in bombs) {
                bom.GetComponent<SpriteRenderer>().sprite = explosionSprite;
            }
        }
    }
    
    //Startボタンを押した
    public void PressStartButton() {
        StartGame();
        ResetScene();
    }

    //Goalボタンを押した
    public void PressGoalButton() {
        StopGame();
    }

    //ゲームを開始
    void StartGame() {
        isGamePlaying = true;
        playerManager.explosion.enabled = false;
    }

    //ゲームをリセット
    void ResetScene() {
        bombs = GameObject.FindGameObjectsWithTag("Bomb");  //爆弾の配列を初期化
        count = 10;
        //画面上にある爆弾のSpriteをすべて平常時の爆弾画像に変える
        foreach (GameObject bom in bombs) {
            bom.GetComponent<SpriteRenderer>().sprite = bombSprite;
        }
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //ゲームを終了
    public void StopGame() {
        isGamePlaying = false;
    }
}
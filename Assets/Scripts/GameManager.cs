using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//ゲーム全体の仕組みにかかわる、汎用的な管理を行うスクリプト
public class GameManager : MonoBehaviour {
    public bool isGamePlaying = false;  //ゲームがスタートしているか
    PlayerManager playerManager;

    void Start () {
        playerManager = GameObject.Find("Player").GetComponent<PlayerManager>();
	}
    
    //Startボタンを押した
    public void PressStartButton() {
        StartGame();
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

    //ゲームを終了
    public void StopGame() {
        isGamePlaying = false;
    }
}
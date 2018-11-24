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
    
    public void PressStartButton() {
        isGamePlaying = true;
        playerManager.explosion.enabled = false;
    }

    public void PressGoalButton() {
        isGamePlaying = false;
    }
}
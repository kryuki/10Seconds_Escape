using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//カウントダウンタイマーの音を管理するスクリプト
public class CountDownTimerBGMManager : MonoBehaviour {
    GameManager gameManager;
    AudioSource audioSource;

    void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioSource = GetComponent<AudioSource>();
    }

	void Update () {
		//プレイ中のみタイマーの音を鳴らす
        if (gameManager.isGamePlaying) {
            audioSource.volume = 1f;
        //プレイ中でなければタイマーの音を止める
        } else {
            audioSource.volume = 0;
        }
	}
}
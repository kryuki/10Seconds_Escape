using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//心臓の鼓動のBGMの管理をするスクリプトです
public class BGMManager : MonoBehaviour {
    GameManager gameManager;
    PlayerController playerController;
    AudioSource audioSource;

    [SerializeField] float heartBeatStart = 50f;

    void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerController = GameObject.Find("SpeedCounter").GetComponent<PlayerController>();
        audioSource = GetComponent<AudioSource>();
    }

	void Update () {
        //プレイ中でかつ、Playerが比較的早く動いているとき、心臓の鼓動を止める
        if (gameManager.isGamePlaying && playerController.playerSpeed > heartBeatStart) {
            audioSource.volume = 0;
        //それ以外の時は心臓の鼓動を鳴らす
        } else {
            audioSource.volume = 1f;
        }
	}
}
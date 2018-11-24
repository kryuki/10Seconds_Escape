using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレイヤーがゴールに到着したことを判定するスクリプト
public class JudgeGoal : MonoBehaviour {
    GameManager gameManager;

	void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
    
    void OnTriggerEnter2D(Collider2D other) {
        //ゴールにPlayerが到達したら
        if (this.gameObject.name == "ButtonGoal" && other.gameObject.tag == "Player") {
            gameManager.StopGame();
        }
    }
}
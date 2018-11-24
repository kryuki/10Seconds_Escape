using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Playerの挙動に関するスクリプト
public class PlayerManager : MonoBehaviour {
    //位置座標
    private Vector3 position;
    //スクリーン座標をワールド座標に変換した位置座標
    private Vector3 screenToWorldPointPosition;

    //音声用
    private AudioSource audioSource;
    //爆発エフェクト用
    public SpriteRenderer explosion;

    GameManager gameManager;

	void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioSource = GetComponent<AudioSource>();  //AudioSourceを取得
	}

	void Update () {
        //SpriteRendererと、BoxCollider2Dは、ゲーム中でなければオフにする
        this.gameObject.GetComponent<SpriteRenderer>().enabled = gameManager.isGamePlaying;
        this.gameObject.GetComponent<BoxCollider2D>().enabled = gameManager.isGamePlaying;

        //ゲームがプレイ中の時だけ
        if (gameManager.isGamePlaying) {
            position = Input.mousePosition;  //マウスの位置座標を取得する
            //z軸補正
            position.z = 10.0f;
            //マウス位置座標をスクリーン座標からワールド座標に変換する
            screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(position);
            //ワールド座標に変換されたマウス座標を代入
            this.gameObject.transform.position = screenToWorldPointPosition;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        //爆弾もしくは壁に当たった
        if (other.gameObject.CompareTag("Bomb") || other.gameObject.CompareTag("Wall")) {
            gameManager.isGamePlaying = false;  //ゲームはプレイ中でない
            //爆発音を出す
            audioSource.Play();
            //爆発の画像を表示する
            explosion.enabled = true;
            explosion.transform.position = screenToWorldPointPosition;
        }
    }
}
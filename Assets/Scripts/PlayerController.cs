using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//プレイヤー（マウスカーソル）の挙動を管理するクラス
public class PlayerController : MonoBehaviour {
    //プレイヤーの位置
    float position_x;
    float position_y;

    //記録用
    float previous_pos_x;
    float previous_pos_y;

    //プレイヤーの速さ
    public float playerSpeed = 0;

    //オーディオ関係
    AudioSource audioSource;

    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    void Update () {
        //プレイヤーの位置を取得（マウスの位置）
        position_x = Input.mousePosition.x;
        position_y = Input.mousePosition.y;

        playerSpeed = GetSpeed();

        //BGMの再生速度を調整する（プレイ中のみ）
        audioSource.pitch = playerSpeed / 1000;
	}
    
    //プレイヤーの速度を取得
    float GetSpeed() {
        //X軸方向の速度(speed_x)を求める
        float current_pos_x = position_x;  //現在のXの値
        float deltaPos_x = current_pos_x - previous_pos_x;  //値の差を取る
        float speed_x = deltaPos_x / Time.deltaTime;  //フレーム時間で割る
        previous_pos_x = current_pos_x;  //値の更新

        //Y軸方向の速度(speed_y)を求める
        float current_pos_y = position_y;  //現在のXの値
        float deltaPos_y = current_pos_y - previous_pos_y;  //値の差を取る
        float speed_y = deltaPos_y / Time.deltaTime;  //フレーム時間で割る
        previous_pos_y = current_pos_y;  //値の更新

        //速度を求める
        return (float)Math.Sqrt(speed_x * speed_x + speed_y * speed_y);
    }
}
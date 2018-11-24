using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//アニメーションのスピードを調整するためのスクリプト
public class SetAnimaitonSpeed : MonoBehaviour {
    private Animator animator;
    public float speedValue = 1f;  //初期値は1
    private float minAnimationSpeedValue = 0.05f;  //アニメーションの再生スピードの最小値

    PlayerController playerController;

	void Start () {
        this.animator = this.gameObject.GetComponent<Animator>();
        this.animator.speed = this.speedValue;
        playerController = GameObject.Find("SpeedCounter").GetComponent<PlayerController>();
	}

	void Update () {
        speedValue = playerController.playerSpeed / 100;
        if (speedValue < 0.01f) speedValue = minAnimationSpeedValue;  //アニメーションの再生スピードの最小値
        this.animator.speed = this.speedValue;
	}
}
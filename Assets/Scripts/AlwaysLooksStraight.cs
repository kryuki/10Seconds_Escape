using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//常に画像が傾くことなく、まっすぐ向いているようにするためのスクリプト
public class AlwaysLooksStraight : MonoBehaviour {
	void Update () {
        this.gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
	}
}
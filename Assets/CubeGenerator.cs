using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour {
	//課題
	Animator animator;
	//キューブのPrefab
	public GameObject cubePrefab;

	//時間計測用の変数
	private float delta = 0;

	//キューブの生成間隔
	private float span = 1.0f;

	//キューブの生成位置：X座標
	private float genPosX = 12;

	//キューブの生成位置オフセット
	private float offsetY = 0.3f;

	//キューブの縦方向の間隔
	private float spaceY = 6.9f;

	//キューブの生成位置オフセット
	private float offsetX = 0.5f;
	//キューブの横方向の間隔
	private float spaceX = 0.4f;

	//キューブの生成個数の上限
	private int maxBlockNum = 4;
	 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.delta += Time.deltaTime;
		//GetComponent<AudioSource> ().volume = 0;
		//span秒以上の時間が経過したかを調べる
		if (this.delta > this.span) {
			this.delta = 0;
			//生成するキューブ数をランダムに決める
			int n = Random.Range (1, maxBlockNum+1);

			//指定した数だけキューブを生成する
			for (int i = 0; i < n; i++) {
				//キューブの生成
				GameObject go = Instantiate (cubePrefab) as GameObject;
				go.transform.position = new Vector2 (this.genPosX, this.offsetY + i * this.spaceY);
				//課題
				Vector2 goposi = go.transform.position;
				bool onGround = (goposi.x == this.genPosX) ? true : false;
				//this.animator.SetBool ("onGround", onGround);
				GetComponent<AudioSource> ().volume = (onGround) ? 1 : 0;
			}
			//次のキューブまでの生成時間を決める
			this.span = this.offsetX + this.spaceX * n;
		}

	}
		
}

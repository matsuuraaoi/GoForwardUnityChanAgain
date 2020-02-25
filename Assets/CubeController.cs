using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {

	//キューブの移動速度
	private float speed = -12;

	//消滅位置
	private float deadLine = -10;

	//課題
	//private GameObject unitychan;
	//private GameObject othercube;
	//private GameObject groundss;

	AudioSource audioData;
	// Use this for initialization
	void Start () {
		//this.unitychan = GameObject.Find ("UnityChan2D");
		//this.othercube = GameObject.Find ("CubePrefab");
		//this.groundss = GameObject.Find ("ground");

		audioData = GetComponent<AudioSource> ();

	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (this.speed * Time.deltaTime, 0, 0);
		
		//画面外に出たら破棄する
		if (transform.position.x < this.deadLine) {
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "CUBE" || other.gameObject.tag == "GROUND") {
			audioData.Play ();
		} else {
			audioData.Stop();
		}
	}
}

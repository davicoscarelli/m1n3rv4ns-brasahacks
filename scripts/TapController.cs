using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TapController : MonoBehaviour {

	public delegate void PlayerDelegate();
	public static event PlayerDelegate OnPlayerDied;
	public static event PlayerDelegate OnPlayerScored;

	public LifeSliderControl scriptLifeSlider;

	public float tapForce = 10;
	public float tiltSmooth = 5;
	public int life = 100;
	public Vector3 startPos;
	public AudioSource tapSound;
	public AudioSource scoreSound;
	public AudioSource dieSound;
	public GameObject mushroom;

	int damage = 25;
	int cure = 25;

	Rigidbody2D rigidBody;
	Quaternion downRotation;
	Quaternion forwardRotation;

	GameManager game;
	TrailRenderer trail;

	public void Start() {
		rigidBody = GetComponent<Rigidbody2D>();
		downRotation = Quaternion.Euler(0, 0 ,-100);
		forwardRotation = Quaternion.Euler(0, 0, 40);
		game = GameManager.Instance;
		rigidBody.simulated = false;
		//trail = GetComponent<TrailRenderer>();
		//trail.sortingOrder = 20; 
	}

	void OnEnable() {
		GameManager.OnGameStarted += OnGameStarted;
		GameManager.OnGameOverConfirmed += OnGameOverConfirmed;
		
	}

	void OnDisable() {
		GameManager.OnGameStarted -= OnGameStarted;
		GameManager.OnGameOverConfirmed -= OnGameOverConfirmed;
	}

	void OnGameStarted() {
		rigidBody.velocity = Vector3.zero;
		rigidBody.simulated = true;
	}

	void OnGameOverConfirmed() {
		transform.localPosition = startPos;
		transform.rotation = Quaternion.identity;
		life = 100;
		scriptLifeSlider.UpdateLifeSlider();

	}

	void Update() {
		if (game.GameOver) return;

		if (Input.GetMouseButtonDown(0)) {
			rigidBody.velocity = Vector2.zero;
			transform.rotation = forwardRotation;
			rigidBody.AddForce(Vector2.up * tapForce, ForceMode2D.Force);
			tapSound.Play();
		}

		transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, tiltSmooth * Time.deltaTime);
	}

	public void OnPlayerDamaged()
	{
		life -= damage;
		dieSound.Play();
		scriptLifeSlider.UpdateLifeSlider();
	}

	public void CureLife()
	{
		life += cure;
		if (life > 100)
		{
			life = 100;
		}
		scriptLifeSlider.UpdateLifeSlider();
		scoreSound.Play();
	}

	void OnTriggerEnter2D(Collider2D col) {
		Debug.Log("OnTriggerEnter2D" + col.gameObject.tag);
		if (col.gameObject.tag == "ScoreZone") {
			OnPlayerScored();
			scoreSound.Play();
		}
		if (col.gameObject.tag == "DeadZone") {
			OnPlayerDamaged();

			if (life <= 0)
            {
				rigidBody.simulated = false;
				OnPlayerDied();
				dieSound.Play();
			}
		}
		if(col.gameObject.tag == "CureZone")
        {
			CureLife();
			scoreSound.Play();
			col.gameObject.transform.position = Vector3.one * 1000;
			PlayerPrefs.SetInt("ola", 1);
		}

		if (col.gameObject.tag == "HellZone") {
			life = 0;
			scriptLifeSlider.UpdateLifeSlider();

			rigidBody.simulated = false;
			OnPlayerDied();
			dieSound.Play();
			
		}
		//if(col.)
		//fazer sknis
		//criar uma tag dif p cada item
		//no menu fazer o getint
	}

}

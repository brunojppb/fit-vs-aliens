﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	[Header("Player Attributes")]
	public float moveSpeed = 5.0f;
	public float health = 100.0f;
	public float healthHit = 5.0f;

	[Header("Spaceship Components")]
	public Cannon[] cannons;
	public GameObject explosion;

	private float move;
	private float minimumX, maximumX, minimumY, maximumY;


	
	void Start () {
		CalculateDistances ();
	}

	void Update () {
		Shoot ();
	}

	//Physics control
	void FixedUpdate(){
		PlayerMovement ();
	}

	void OnTriggerEnter2D(Collider2D other){

		string layerName = LayerMask.LayerToName (other.gameObject.layer);

		if (layerName == "Bullet (Enemy)") {
			Destroy(other.gameObject);
			health -= healthHit;
		}

		if (health <= 0) {
			Explode();
			Destroy(gameObject);
		}

	}

	//Calculate screen width and height to manipulate the player inside the screen
	void CalculateDistances(){
		float distanceZ = this.transform.position.z - Camera.main.transform.position.z;
		minimumX = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, distanceZ)).x + (GetComponent<Renderer>().bounds.size.x/2);
		maximumX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, distanceZ)).x - (GetComponent<Renderer>().bounds.size.x/2);
		minimumY = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, distanceZ)).y + (GetComponent<Renderer>().bounds.size.y/2);
		maximumY = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, distanceZ)).y - (GetComponent<Renderer>().bounds.size.y/2);
	}

	//Move the player around (inside the limits)
	void PlayerMovement(){
		
		if (Input.GetAxis ("Vertical") != 0) {
			move = Input.GetAxis ("Vertical");
			transform.Translate(Vector3.up * Mathf.Clamp(move, -1, 1) * moveSpeed * Time.deltaTime);
		}
		if (Input.GetAxis ("Horizontal") != 0) {
			move = Input.GetAxis ("Horizontal");
			transform.Translate(Vector3.right * Mathf.Clamp(move, -1, 1) * moveSpeed * Time.deltaTime);
		}

		float actualXPosition = transform.position.x;
		float actualYPosition = transform.position.y;
		//Testa se a posicao Atual está entre o X maximo e X minimo
		actualXPosition = Mathf.Clamp(actualXPosition, minimumX, maximumX);
		actualYPosition = Mathf.Clamp(actualYPosition, minimumY, maximumY);
		//se a posicao atual for diferente a posicao modificada pela funcao acima
		if(actualXPosition != transform.position.x){
			//atribui a nova posicao do player entre os limites estabelecidos
			transform.position = new Vector3(actualXPosition, transform.position.y, transform.position.z);
		}
		if (actualYPosition != transform.position.y) {
			transform.position = new Vector3(transform.position.x, actualYPosition, transform.position.z);
		}
	}

	void Shoot(){
		if (Input.GetMouseButton(0)) {
			foreach(Cannon can in cannons){
				can.Shoot();
			}
		}
	}

	void Explode(){
		Instantiate (explosion, transform.position, transform.rotation);
	}
}

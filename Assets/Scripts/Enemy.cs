using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	private Spaceship spaceship;
	public GameObject explostion;

	// Use this for initialization
	void Start () {
		spaceship = GetComponent<Spaceship> () as Spaceship;
		spaceship.Move (transform.up * -1);
	}

	void OnTriggerEnter2D(Collider2D other){
		string layerName = LayerMask.LayerToName (other.gameObject.layer);

		if (layerName != "Bullet (Player)")
			return;

		Destroy (other.gameObject);
		Explode ();

		Destroy (gameObject);

	}

	void Explode(){
		Instantiate (explostion, transform.position, transform.rotation);
	}
	
}

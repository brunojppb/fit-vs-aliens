using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	private Spaceship spaceship;
	public GameObject explosion;
	public float health = 10;

	// Use this for initialization
	void Start () {
		spaceship = GetComponent<Spaceship> () as Spaceship;
		spaceship.Move (transform.up * -1);
	}

	void OnTriggerEnter2D(Collider2D other){
		string layerName = LayerMask.LayerToName (other.gameObject.layer);

		if (layerName != "Bullet (Player)")
			return;


		health--;
		Destroy (other.gameObject);
		GamePlayUI.addPoints ();
		if (health <= 0) {
			Explode ();
			Destroy (gameObject);
		}

	}

	void Explode(){
		Instantiate (explosion, transform.position, transform.rotation);
		AudioSource audio = GetComponent<AudioSource> () as AudioSource;
		audio.Play ();
	}

}

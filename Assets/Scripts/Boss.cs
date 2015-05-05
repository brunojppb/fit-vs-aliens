using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

	public int health = 10;
	public Cannon[] cannions;
	public GameObject[] effects;
	public GameObject explosion;
	private bool moveDirection = true;
	private int totalHealth;

	// Use this for initialization
	void Start () {
//		StartCoroutine("MoveAround");
		StartCoroutine("ShowUp");
		StartCoroutine("Shoot");

		totalHealth = health;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		string layerName = LayerMask.LayerToName (other.gameObject.layer);
		if (layerName != "Bullet (Player)")
			return;

		if (health <= (totalHealth / 2.0)) {
			effects[0].SetActive(true);
		}

		if (health <= totalHealth / 3.0) {
			effects[1].SetActive(true);
		}

		Destroy (other.gameObject);
		GamePlayUI.addPoints ();
		if (health > 0) {
			health--;
		} else {
			Explode();
			Destroy(this.gameObject);
		}
	}

	IEnumerator Shoot(){
		while (true) {
			foreach(Cannon can in cannions) {
				can.Shoot();
			}
			yield return new WaitForSeconds(0.5f);
		}
	}

	IEnumerator ShowUp(){
		while (true) {
			transform.position = new Vector3(transform.position.x, transform.position.y - 0.03f, transform.position.z);
			yield return new WaitForSeconds(0.001f);
			if(transform.position.y < 4.0f)
				break;
		}
		StartCoroutine("MoveAround");

	}

	void Explode(){
		GamePlayUI UImanager = GameObject.FindGameObjectWithTag("UIManager").transform.GetComponent<GamePlayUI>() as GamePlayUI;
		UImanager.ShowGameOverPanel ();
		UImanager.ShowWinnerMessage ();
		Instantiate (explosion, transform.position, transform.rotation);
	}

	IEnumerator MoveAround(){
		int counter = 0;
		while (true) {
			if (moveDirection) {
				transform.position = new Vector3(transform.position.x + 0.02f, transform.position.y, transform.position.z);
				counter++;
				yield return new WaitForSeconds(0.01f);
				if(counter >= 300)
					moveDirection = false;
			}
			else {
				transform.position = new Vector3(transform.position.x - 0.02f, transform.position.y, transform.position.z);
				counter--;
				yield return new WaitForSeconds(0.01f);
				if(counter <= -300)
					moveDirection = true;
			}
		}
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GamePlayUI : MonoBehaviour {

	public Slider healthBar;
	public Player player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (player != null) {
			healthBar.value = player.health;
		}
	}
}

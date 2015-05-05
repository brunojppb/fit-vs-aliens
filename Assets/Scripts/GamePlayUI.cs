using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GamePlayUI : MonoBehaviour {

	[Header("UI Components")]
	public Slider healthBar;
	public static Text playerScore;
	public GameObject gameOverPanel;
	public GameObject userPanel;
	public Text GameOverScore;
	public Text gameOverText;
	public Text explanationText;

	[Header("Player Object")]
	public Player player;

	// Use this for initialization
	void Start () {
		GameObject score = GameObject.FindGameObjectWithTag ("PlayerScore");
		GamePlayUI.playerScore = score.GetComponent<Text>();
		Debug.Log ("Text: " + score.GetComponent<Text>());
		GamePlayUI.playerScore.text = "0";	
	}
	
	// Update is called once per frame
	void Update () {
		if (player != null) {
			healthBar.value = player.health;
		}
		else {
			ShowGameOverPanel();
		}
	}

	public void ShowGameOverPanel(){
		gameOverPanel.SetActive (true);
		GameOverScore.text = playerScore.text;
		if (GamePlayUI.playerScore.text == "0")
			this.explanationText.text = "";
		userPanel.SetActive (false);
	}

	public void LoadMainMenu(){
		Application.LoadLevel ("MainMenu");
	}

	public void ReloadLevel(){
		Application.LoadLevel ("GamePlay");
	}

	public void ShowWinnerMessage(){
		this.gameOverText.text = "You saved the President";
	}

	public static void addPoints(){
		int score = int.Parse (GamePlayUI.playerScore.text);
		score += 10;
		playerScore.text = "" + score;
	}
}

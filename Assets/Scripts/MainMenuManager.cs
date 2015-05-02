using UnityEngine;
using System.Collections;

public class MainMenuManager : MonoBehaviour {

	public Animator MainScreen;
	public Animator CreditsScreen;

	public void LoadGameplay(){
		Application.LoadLevel("Story");
	}

	public void ToggleCreditsScreen(){
		MainScreen.SetTrigger("toggle");
		CreditsScreen.SetTrigger("toggle");
	}
}

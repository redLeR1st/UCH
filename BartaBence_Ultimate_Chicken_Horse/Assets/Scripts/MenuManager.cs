using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

	AudioManager audioManager;

	// Use this for initialization
	void Start()
	{
		audioManager = AudioManager.instance;
		if (audioManager == null)
		{
			Debug.LogError("No audiomanager found in Scene.");
		}
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void startGame()
	{
		audioManager.PlaySoundOfButtonClick();

		DogScore.dogScore = 0;
		CatScore.catScore = 0;
		SceneManager.LoadScene(0);
	}

	public void stopGame()
	{
		audioManager.PlaySoundOfButtonClick();
		Application.Quit();
	}

	public void achiMenu()
	{
		audioManager.PlaySoundOfButtonClick();
		SceneManager.LoadScene(2);
	}

	public void backToMain()
	{
		audioManager.PlaySoundOfButtonClick();
		SceneManager.LoadScene(1);
	}
}

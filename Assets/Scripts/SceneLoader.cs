using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	public static SceneLoader instance;

	private void Awake()
	{
		if (instance) Destroy(instance.gameObject);
		instance = this;
	}

	public void LoadNextScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void LoadMainMenu()
	{
		SceneManager.LoadScene((int)SceneIndex.MainMenu);
	}

	public void LoadLeaderboard()
	{
		SceneManager.LoadScene((int)SceneIndex.Leaderboard);
	}
}

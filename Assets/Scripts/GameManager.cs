using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
	[SerializeField] SpriteRenderer[] tiles;
	[SerializeField] SpriteRenderer[] beatFlash;
	[SerializeField] GameObject errorFlash;

	[SerializeField] GameObject winPanel;
	[SerializeField] GameObject losePanel;

	[SerializeField] TextMeshProUGUI playerHP;
	[SerializeField] TextMeshProUGUI enemyHP;

	[SerializeField] Color basicTileColor;
	[SerializeField] Color targetTileColor;
	[SerializeField] Color evenBeatColor;
	[SerializeField] Color oddBeatColor;

	List<SpriteRenderer> targetedTiles;
	Player player;
	Enemy enemy;

	bool oddbeat;

	public static GameManager instance;
	public static int playerHealth = 0;

	private void Awake()
	{
		instance = this;

		player = FindObjectOfType<Player>();
		enemy = FindObjectOfType<Enemy>();

		if (playerHealth == 0) playerHealth = 15;
		targetedTiles = new List<SpriteRenderer>();

		Conductor.instance.OnBeatChanged += Conductor_OnBeatChanged;
		player.OnPlayerDeath += Player_OnPlayerDeath;
		enemy.OnEnemyDeath += Enemy_OnEnemyDeath;
		Conductor_OnBeatChanged();
	}

	private void Enemy_OnEnemyDeath()
	{
		winPanel.SetActive(true);
	}

	private void Player_OnPlayerDeath()
	{
		losePanel.SetActive(true);
	}

	private void Conductor_OnBeatChanged()
	{
		oddbeat = !oddbeat;
		for (int i = 0; i < beatFlash.Length; i++)
		{
			if (i % 2 == 0)
			{
				beatFlash[i].color = oddbeat ? oddBeatColor : evenBeatColor;
			}
			else
			{
				beatFlash[i].color = !oddbeat ? oddBeatColor : evenBeatColor;
			}
		}
	}

	public void SetTargetTile(int index)
	{
		tiles[index].color = targetTileColor;
		targetedTiles.Add(tiles[index]);
	}

	public void ApplyDamageOnTiles()
	{
		enemy?.ApplyAttack();
		if (targetedTiles.Contains(tiles[player.GetTilePosition()]))
		{
			player.Damage();
		}
		ResetTiles();
	}

	public void UpdatePlayerHP()
	{
		playerHP.text = $"HP : {player.GetHealth()}";
	}

	public void UpdateEnemyHP()
	{
		enemyHP.text = $"HP : {enemy.GetHealth()}";
	}

	void ResetTiles()
	{
		foreach (var tile in tiles)
		{
			tile.color = basicTileColor;
		}
		targetedTiles.Clear();
	}

	#region VISUALS
	public void FlashScreen()
	{
		StartCoroutine(FlashScreenCoroutine());
	}

	public void FlashError()
	{
		StartCoroutine(FlashErrorCoroutine());
	}

	IEnumerator FlashScreenCoroutine()
	{
		//Debug.Log("Beat");
		//beatFlash.color = Color.blue;
		yield return new WaitForSeconds(.1f);
		//beatFlash.color = Color.white;
	}

	IEnumerator FlashErrorCoroutine()
	{
		Debug.Log("ErrorBeat");
		errorFlash.SetActive(true);
		yield return new WaitForSeconds(.1f);
		errorFlash.SetActive(false);
	} 
	#endregion

	#region ACCESSORS
	public Player GetPlayer() => player;
	public Enemy GetEnnemy() => enemy;
	public Vector3 GetUpTilePosition() => tiles[0].transform.position;
	public Vector3 GetCenterTilePosition() => tiles[1].transform.position;
	public Vector3 GetDownTilePosition() => tiles[2].transform.position;
	public Vector3 GetRightTilePosition() => tiles[3].transform.position;
	public Vector3 GetEnemyTilePosition() => tiles[4].transform.position;
	#endregion
}

public enum TilePosition
{
	Up=0,
	Center=1,
	Down=2,
	Right=3
}
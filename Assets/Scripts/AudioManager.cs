using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	[SerializeField] AudioClip[] enemyHits;
	[SerializeField] AudioClip[] enemyAttacks;
	[SerializeField] AudioClip[] playerHits;
	[SerializeField] AudioClip[] playerAttacks;

	[SerializeField] AudioClip enemyDeath;
	[SerializeField] AudioClip playerDeath;
	[SerializeField] AudioClip uiMove;
	[SerializeField] AudioClip uiSelect;

	AudioSource audioSource;

	public static AudioManager instance;

	private void Awake()
	{
		if (instance) Destroy(instance.gameObject);
		instance = this;

		DontDestroyOnLoad(this);
		audioSource = GetComponent<AudioSource>();
	}


	public void PlayEnemyAttack()
	{
		AudioClip clip = enemyAttacks[Random.Range(0, enemyAttacks.Length)];
		PlaySound(clip);
	}

	public void PlayEnemyHit()
	{
		AudioClip clip = enemyHits[Random.Range(0, enemyHits.Length)];
		PlaySound(clip);
	}

	public void PlayEnemyDeath()
	{
		AudioClip clip = enemyDeath;
		PlaySound(clip);
	}

	public void PlayPlayerAttack()
	{
		AudioClip clip = playerAttacks[Random.Range(0, playerAttacks.Length)];
		PlaySound(clip);
	}

	public void PlayPlayerHit()
	{
		AudioClip clip = playerHits[Random.Range(0, playerHits.Length)];
		PlaySound(clip);
	}

	public void PlayPlayerDeath()
	{
		AudioClip clip = playerDeath;
		PlaySound(clip);
	}

	public void PlayUIMove()
	{
		AudioClip clip = uiMove;
		PlaySound(clip);
	}

	public void PlayUISelect()
	{
		AudioClip clip = uiSelect;
		PlaySound(clip);
	}

	public void PlaySound(AudioClip clip)
	{
		audioSource.PlayOneShot(clip);
	}
}

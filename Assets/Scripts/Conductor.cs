using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Conductor : MonoBehaviour
{
	[SerializeField] float firstBeatOffsetBeatRatio;
	[SerializeField] float songBpm;
	[SerializeField] float timingToleranceBeatRatio;

	AudioSource musicSource;

	float secPerBeat;
	float timingToleranceSeconds;
	float songPosition;
	float songPositionInBeats;
	float timeSinceLastBeat;
	float timeToNextBeat;
	float dspSongTime;

	int lastPlayerActionBeat = -1;
	bool enemyActionSelected;
	bool isAnyDead;

	public static Conductor instance;

	public event Action OnBeatChanged;

	public event Action OnEnemySelectActionTiming;
	public event Action OnPlayerMissedInput;

	private void Awake()
	{
		if (instance) Destroy(instance.gameObject);
		instance = this;
	}

	void Start()
	{
		Player.OnPlayerActionDone += Player_OnPlayerActionDone;
		GameManager.instance.GetPlayer().OnPlayerDeath += OnAnyDeath;
		GameManager.instance.GetEnnemy().OnEnemyDeath += OnAnyDeath;

		musicSource = GetComponent<AudioSource>();
		secPerBeat = 60f / songBpm;
		timingToleranceSeconds = timingToleranceBeatRatio * secPerBeat;

		dspSongTime = (float)AudioSettings.dspTime;

		musicSource.Play();
		isAnyDead = false;
	}

	private void Player_OnPlayerActionDone()
	{
		TriggerEnemyAction();
	}

	void OnAnyDeath()
	{
		isAnyDead = true;
	}

	private void TriggerEnemyAction()
	{
		GameManager.instance.ApplyDamageOnTiles();
		enemyActionSelected = false;
	}

	void Update()
	{
		float oldBeat = songPositionInBeats;
		bool toleranceAlreadyPassed = !IsInToleranceWindow();
		bool isAlreadyPastHalfBeat = songPositionInBeats - (int)songPositionInBeats >= .5f;

		UpdateTimings();

		bool beatPassedThisFrame = (int)oldBeat < (int)songPositionInBeats;
		bool halfBeatPassedThisFrame = !isAlreadyPastHalfBeat && !enemyActionSelected && songPositionInBeats - (int)songPositionInBeats > .5f;
		bool tolerancePassedThisFrame = !toleranceAlreadyPassed && !IsInToleranceWindow();

		if (beatPassedThisFrame)
		{
			Debug.Log($"BEAT CHANGE Song position in beats : {songPositionInBeats}");
			OnBeatChanged?.Invoke();
			return;
		}

		if (isAnyDead) return;
		if (songPositionInBeats < 1 + timingToleranceBeatRatio) return;

		if (tolerancePassedThisFrame)
		{
			Debug.Log($"TOLERANCE Song position in beats : {songPositionInBeats}");
			if (lastPlayerActionBeat < (int)songPositionInBeats)
			{
				OnPlayerMissedInput?.Invoke();
				TriggerEnemyAction();
			}
			return;
		}

		if (halfBeatPassedThisFrame)
		{
			Debug.Log($"HALF BEAT Song position in beats : {songPositionInBeats}");
			OnEnemySelectActionTiming?.Invoke();
			enemyActionSelected = true;
			return;
		}
	}

	bool IsInToleranceWindow()
	{
		return songPositionInBeats % 1 <= timingToleranceBeatRatio || 1 - (songPositionInBeats % 1) <= timingToleranceBeatRatio;
	}

	private void UpdateTimings()
	{
		songPosition = (float)(AudioSettings.dspTime - dspSongTime - firstBeatOffsetBeatRatio * secPerBeat);
		songPositionInBeats = songPosition / secPerBeat;

		timeSinceLastBeat = (songPositionInBeats - (int)songPositionInBeats) * secPerBeat;
		timeToNextBeat = secPerBeat - timeSinceLastBeat;
	}

	public bool CheckTiming()
	{
		Debug.Log($"Input timing : {timeToNextBeat}, {timeSinceLastBeat}");
		if (songPositionInBeats < 1 + timingToleranceBeatRatio) return false;

		int currentInputBeat = CheckCurrentInputBeat();

		if (lastPlayerActionBeat == currentInputBeat)
		{
			GameManager.instance.FlashError();
			return false;
		}

		if (IsInToleranceWindow())
		{
			lastPlayerActionBeat = currentInputBeat;
			return true;
		}
	
		GameManager.instance.FlashError();
		return false;
	}

	private int CheckCurrentInputBeat()
	{
		int currentInputBeat;
		bool early = timeToNextBeat < timeSinceLastBeat;
		currentInputBeat = (int)songPositionInBeats;
		if (early || !IsInToleranceWindow())
			currentInputBeat = (int)songPositionInBeats + 1;
		return currentInputBeat;
	}

	#region ACCESSORS
	float GetTimeSinceLastBeat() => timeSinceLastBeat;
	float GetTimeToNextBeat() => timeToNextBeat;
	#endregion
}

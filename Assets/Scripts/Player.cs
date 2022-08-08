using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterAnimator))]
public class Player : MonoBehaviour
{
	public static event Action OnPlayerActionDone;
	public event Action OnPlayerDeath;

	CharacterAnimator animator;
	PlayerInputs inputs;
	new Transform transform;

	int health = 10;
	int maxHealth = 3;
	TilePosition tilePosition;

	private void Awake()
	{
		transform = GetComponent<Transform>();
		animator = GetComponent<CharacterAnimator>();

		inputs = new PlayerInputs();
		inputs.Player.Enable();

		SetupEvents();
		GameManager.instance.UpdatePlayerHP();
	}

	private void OnDestroy()
	{
		RemoveEvents();
	}

	#region EVENTS
	private void SetupEvents()
	{
		inputs.Player.UP.performed += UP_performed;
		inputs.Player.DOWN.performed += DOWN_performed;
		inputs.Player.RIGHT.performed += RIGHT_performed;

		animator.OnAnimationEnd += Animator_OnAnimationEnd;
		OnPlayerDeath += Player_OnPlayerDeath;
	}

	private void RemoveEvents()
	{
		inputs.Player.UP.performed -= UP_performed;
		inputs.Player.DOWN.performed -= DOWN_performed;
		inputs.Player.RIGHT.performed -= RIGHT_performed;

		animator.OnAnimationEnd -= Animator_OnAnimationEnd;
		OnPlayerDeath -= Player_OnPlayerDeath;
	}

	private void Player_OnPlayerDeath()
	{
		inputs.Player.Disable();
	}

	private void Animator_OnAnimationEnd()
	{
		transform.position = GameManager.instance.GetCenterTilePosition();
		tilePosition = TilePosition.Center;
	}

	private void Conductor_OnEnemyAction()
	{
		transform.position = GameManager.instance.GetCenterTilePosition();
		tilePosition = TilePosition.Center;
	}

	private void UP_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
	{
		if (!Conductor.instance.CheckTiming()) return;

		transform.position = GameManager.instance.GetUpTilePosition();
		tilePosition = TilePosition.Up;
		animator.SetIsMoving(true);
		OnPlayerActionDone?.Invoke();
	}

	private void DOWN_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
	{
		if (!Conductor.instance.CheckTiming()) return;

		transform.position = GameManager.instance.GetDownTilePosition();
		tilePosition = TilePosition.Down;
		animator.SetIsMoving(true);
		OnPlayerActionDone?.Invoke();
	}

	private void RIGHT_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
	{
		if (!Conductor.instance.CheckTiming()) return;

		transform.position = GameManager.instance.GetRightTilePosition();
		tilePosition = TilePosition.Right;
		animator.SetIsAttacking(true);
		OnPlayerActionDone?.Invoke();
		AudioManager.instance.PlayPlayerAttack();
		GameManager.instance.GetEnnemy().Damage();
	}
	#endregion

	public void Damage()
	{
		health--;
		GameManager.instance.UpdatePlayerHP();
		if (health <= 0)
		{
			Die();
		}
		else
		{
			animator.SetIsHurt(true);
			AudioManager.instance.PlayPlayerHit();
		}
	}

	private void Die()
	{
		OnPlayerDeath?.Invoke();
		animator.SetIsDead(true);
		AudioManager.instance.PlayPlayerDeath();
	}

	#region ACCESSORS
	public int GetTilePosition() => (int)tilePosition; 
	public int GetHealth() => health;
	#endregion
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
	Animator animator;

	int currentState;
	bool isMoving, isAttacking, isInAttackAnticipation, isHurt, isDead;

	readonly int Idle = Animator.StringToHash("Idle");
	readonly int Move = Animator.StringToHash("Move");
	readonly int Attack = Animator.StringToHash("Attack");
	readonly int AttackAnticipation = Animator.StringToHash("AttackAnticipation");
	readonly int Hurt = Animator.StringToHash("Hurt");
	readonly int Dead = Animator.StringToHash("Dead");

	public event Action OnAnimationEnd;
	public event Action OnDeath;

	private void Awake()
	{
		animator = GetComponent<Animator>();
		currentState = Idle;
	}

	private void Update()
	{
		int newState = GetState();
		if (newState == currentState) return;

		currentState = newState;
		animator.Play(currentState, 0, 0);
	}

	private int GetState()
	{
		if (isDead) return Dead;
		if (isHurt) return Hurt;
		if (isAttacking) return Attack;
		if (isInAttackAnticipation) return AttackAnticipation;
		if (isMoving) return Move;
		return Idle;
	}

	public void AnimationEndTrigger(AnimationName animation)
	{
		Debug.Log(animation.ToString());

		switch (animation)
		{
			case AnimationName.Idle:
				break;
			case AnimationName.Attack:
				isAttacking = false;
				OnAnimationEnd?.Invoke();
				break;
			case AnimationName.Move:
				isMoving = false;
				OnAnimationEnd?.Invoke();
				break;
			case AnimationName.Hurt:
				isHurt = false;
				OnAnimationEnd?.Invoke();
				break;
			case AnimationName.Dead:
				OnDeath?.Invoke();
				break;
			default:
				break;
		}
	}

	#region ACCESSORS
	public void SetIsMoving(bool value) => isMoving = value;
	public void SetIsAttacking(bool value)  {isAttacking = value; isInAttackAnticipation = false; }
	public void SetIsInAttackAnticipation(bool value) => isInAttackAnticipation = value;
	public void SetIsHurt(bool value) => isHurt = value;
	public void SetIsDead(bool value) => isDead = value;
	#endregion
}

public enum AnimationName
{
	Idle,
	Attack,
	AttackAnticipation,
	Move,
	Hurt,
	Dead
}

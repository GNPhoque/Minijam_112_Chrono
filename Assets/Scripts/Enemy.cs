using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterAnimator))]
public abstract class Enemy : MonoBehaviour
{
	public event Action OnEnemyDeath;

	protected CharacterAnimator animator;

	[SerializeField] int health;

	private void Awake()
	{
		animator = GetComponent<CharacterAnimator>();

		Conductor.instance.OnEnemySelectActionTiming += PrepareAttack;
		GameManager.instance.UpdateEnemyHP();
	}

	public abstract void PrepareAttack();

	public virtual void ApplyAttack()
	{
		animator.SetIsAttacking(true);
		AudioManager.instance.PlayEnemyAttack();
	}

	protected virtual void AttackTile(int index)
	{
		GameManager.instance.SetTargetTile(index);
	}

	protected virtual void AttackUp()
	{
		GameManager.instance.SetTargetTile(0);
	}

	protected virtual void AttackCenter()
	{
		GameManager.instance.SetTargetTile(1);
	}
	protected virtual void AttackDown()
	{
		GameManager.instance.SetTargetTile(2);
	}

	protected virtual void Counter()
	{
		GameManager.instance.SetTargetTile(3);
	}

	public void Damage()
	{
		health--;
		GameManager.instance.UpdateEnemyHP();
		if (health <= 0)
		{
			Die();
		}
		else
		{
			animator.SetIsHurt(true);
			AudioManager.instance.PlayEnemyHit();
		}
	}

	private void Die()
	{
		OnEnemyDeath?.Invoke();
		animator.SetIsDead(true);
		AudioManager.instance.PlayEnemyDeath();
	}

	public int GetHealth() => health;
}

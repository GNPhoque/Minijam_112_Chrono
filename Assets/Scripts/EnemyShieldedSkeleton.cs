using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShieldedSkeleton : Enemy
{
	public override void PrepareAttack()
	{
		int target = Random.Range(0, 4);
		AttackTile(target);
		int newTarget = target;
		while (newTarget == target)
		{
			newTarget = Random.Range(0, 4);
			AttackTile(newTarget); 
		}
		animator.SetIsInAttackAnticipation(true);
	}
}

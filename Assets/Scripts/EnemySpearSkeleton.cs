using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpearSkeleton : Enemy
{
	public override void PrepareAttack()
	{
		int target = Random.Range(0, 3);
		AttackTile(target);
		if(target==1)
			AttackTile(3);
		animator.SetIsInAttackAnticipation(true);
	}
}

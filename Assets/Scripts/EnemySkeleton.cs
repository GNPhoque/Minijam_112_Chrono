using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkeleton : Enemy
{
	public override void PrepareAttack()
	{
		int target = Random.Range(0, 4);
		AttackTile(target);
		animator.SetIsInAttackAnticipation(true);
	}
}

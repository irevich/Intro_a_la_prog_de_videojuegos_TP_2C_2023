using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingEnemy : Enemy
{
   protected override void MoveTowardsPlayer()
   {
      Vector3 lookPos = _target.position;
      lookPos.y = transform.position.y;
      transform.position = Vector3.MoveTowards(transform.position, 
                _target.position, _speed * Time.deltaTime);
      transform.LookAt(lookPos);
   }
}

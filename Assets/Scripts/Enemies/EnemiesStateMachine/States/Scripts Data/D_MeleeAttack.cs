using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newMeleeAttackStateData", menuName = "Data/State Data/Melee Attack State")]
public class D_MeleeAttack : ScriptableObject
{
    //Stats
    public float attackRadius = 0.5f;
    public float attackDamage = 10.0f;

    //Layers
    public LayerMask whatIsPlayer;
}

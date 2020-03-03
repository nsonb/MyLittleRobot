using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackStat")]
public class AttackStat : ScriptableObject {
    public float range;
    public float time;
    public float enemyJumpForce;
    public float step;
}

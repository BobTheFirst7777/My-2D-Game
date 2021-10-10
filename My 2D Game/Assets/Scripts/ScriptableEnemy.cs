using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ScriptableEnemy : ScriptableObject
{
    public string enemyName;

    public string movementType;  //Suicide, Coward, Hunt, Standard

    public scriptableWeapon gun;

    public float health;
    public float armour;
    public float speed;
    

}

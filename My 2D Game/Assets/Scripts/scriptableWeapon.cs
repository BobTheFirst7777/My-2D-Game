using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class scriptableWeapon : ScriptableObject
{
    public string weaponName;

    public GameObject bulletPrefab;

    public float range;
    public float damage;
    public float speed;

}

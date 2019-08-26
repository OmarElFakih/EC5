using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Soul Data")]
public class SoulData : ScriptableObject
{
    //Attributes
    public float health;
    public float speed;
    public float damage;
    public int points;
    public float stopRadius = 2f;
    public float destroyDelay;
    public float effectVolume;
    public AudioClip deathScreamClip;
    public AudioClip hurtClip;

}

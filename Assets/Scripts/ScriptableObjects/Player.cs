using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Player/New Player")]
public class Player : ScriptableObject
{
    public new string name;
    public string description;
    public Sprite artwork;
    public float maxHealth;
    public float curHealth;
    public float speed;
    public Skill[] skills;
}
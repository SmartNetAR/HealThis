using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy/New Enemy")]
public class Enemy : ScriptableObject
{
    public new string name;
    public string description;
    public Sprite artwork;
    public float maxHealth;
    public float curHealth;
    public float speed;
    public int points;
    public float alertRange;
    public List<Skill> skills;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skill", menuName = "Skill/New Skill")]
public class Skill : ScriptableObject
{
    public new string name;
    public string description;
    public Sprite artwork;
    public int damage;
    public float cooldown;
}

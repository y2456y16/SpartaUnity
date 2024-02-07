using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "New Character")]
public class CharacterStat:ScriptableObject
{
    [Header("Info")]
    public string characterName;
    public string description;
    public int level;
    public int fullexp;
    public int atk;
    public int def;
    public int hp;
    public int critical;

}

using System.Collections;
using System.Collections.Generic;
using UnityEditor.iOS;
using UnityEngine;

public class EquipTool : Equip
{
    public float attackRate;
    private bool attacking;
    public float attackDistance;

    [Header("Resource Gathering")]
    public bool doesGatherResources;

    [Header("Combat")]
    public bool doesDealDamage;
    public int damage;

    private GameObject PlayerMove;

    private void Start()
    {
        //PlayerMove = GameObject.Find("Armature");
    }

    private void FixedUpdate()
    {
        //transform.localEulerAngles = PlayerMove.transform.localEulerAngles;
    }

}
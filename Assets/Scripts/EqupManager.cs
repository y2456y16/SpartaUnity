using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;



public class EquipManager : MonoBehaviour
{
    public Equip curEquip;
    public Transform equipParent;

    private PlayerController controller;
    private PlayerInfo playerInfo;

    // singleton
    public static EquipManager instance;

    private void Awake()
    {
        instance = this;
        controller = GetComponent<PlayerController>();
        playerInfo = GetComponent<PlayerInfo>();
    }

    /*
    public void OnAttackInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed && curEquip != null && controller.canLook)
        {
            curEquip.OnAttackInput(playerInfo);
        }
    }
    */

    public void EquipNew(ItemData item)
    {
        UnEquip();
        curEquip = Instantiate(item.equipPrefab, equipParent).GetComponent<Equip>();
    }

    public void UnEquip()
    {
        if (curEquip != null)
        {
            Destroy(curEquip.gameObject);
            curEquip = null;
        }
    }
}
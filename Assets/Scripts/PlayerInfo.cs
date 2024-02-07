using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo:MonoBehaviour
{
    public CharacterStat _characterStat;

    public Text playerName;
    public GameObject playerInfo;
    public GameObject playerLevel;
    public GameObject playerExp;
    //public GameObject playerHp;
    //public GameObject playerAtk;
    //public GameObject playerDef;
    //public GameObject playerCritical;
    public Text playerMoney;


    public float money;

    // Start is called before the first frame update
    void Start()
    {
        money = 1000;
        playerName.text = _characterStat.name;
        playerInfo.GetComponent<Text>().text = _characterStat.description;
        playerLevel.GetComponent<Text>().text = _characterStat.level.ToString();
        playerExp.GetComponent<Text>().text = "0 / " + _characterStat.fullexp.ToString();
        playerMoney.text = string.Format("{0:#,###0}", money);
    }

    // Update is called once per frame
    void Update()
    {
        if(money >= 100000000000)
        {
            playerMoney.text = "X00000000000";
        }
        else
        {
            playerMoney.text = string.Format("{0:#,###0}", money);
        }
    }

    public void Heal(int healAmount)
    {
        _characterStat.hp += healAmount;
    }

    public void ItemAttackStat(int attackAmount)
    {
        _characterStat.atk += attackAmount;
    }

    public void ItemDefenseStat(int defenseAmount)
    {
        _characterStat.def += defenseAmount;
    }

    public void ItemCriticalStat(int criticalAmount)
    {
        _characterStat.critical += criticalAmount;
    }


}

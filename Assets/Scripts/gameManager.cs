using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public static gameManager instance;

    [SerializeField] private GameObject statBtn;
    [SerializeField] private GameObject CharacterStat;
    [SerializeField] private GameObject Inventory;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnStatus()
    {
        statBtn.SetActive(false);
        CharacterStat.SetActive(true);
    }

    public void OnBacktoMain()
    {
        CharacterStat.SetActive(false);
        Inventory.SetActive(false);
        statBtn.SetActive(true);      
    }

    public void OnInventory()
    {
        statBtn.SetActive(false);
        Inventory.SetActive(true);
    }
}

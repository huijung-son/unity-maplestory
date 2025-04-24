using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSlime_MP : MonsterP_MP
{
    public MonsterData monData;
    bool monMove = false;
    private GameObject monPrefab = null;
    private GameObject[] monItemsPrefab = null;

    private void OnEnable()
    {
        CallbackMonDropItem += MonDropItem;
    }

    private void Awake()
    {
        monPrefab = Resources.Load<GameObject>("Scene3\\Prefabs\\Monster\\monSlime\\Slime");
        monItemsPrefab = Resources.LoadAll<GameObject>("Scene3\\Prefabs\\Monster\\monSlime\\SlimeItem");
        int rnadItem= Random.Range(0, monItemsPrefab.Length);
       // GameObject monDropItem
            
    }

    public override void MonInitSetting()
    {
        monData.monster = monPrefab;
        monData.name = "GreenSlime";
        monData.level = 7;
        monData.hp = 80;
        monData.mp = 10;
        monData.atkPhysical = 25f;
        monData.defPhysical = 10f;
        monData.atkMagical = 19f;
        monData.defMagical = 10f;
        monData.speed = -20f;
        monData.dropItem = monItemsPrefab;
    }

    //public override void MonMoving()
    //{
       

    //}

    public override void MonTargetFllowMoveing()
    {

    }

    public override void MonDead()
    {
        CallbackMonDropItem?.Invoke();
    }

    //public override void MonSpawn()
    //{
        
    //}

    public override void MonAtk()
    {
        
    }

    public override void MonDropItem()
    {

    }



}

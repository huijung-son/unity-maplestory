using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S3MonsterSlime : S3MonsterP
{
    public MonsterData monData;
    bool monMove = false;
    private GameObject monPrefab = null;
    private GameObject[] monItemsPrefab = null;
    private Animator ani = null;
    private Material aniMaterial = null;
    private Transform tr = null;

    private void OnEnable()
    {
       // CallbackMonDropItem += MonDropItem;
    }

    private void Awake()
    {
        monPrefab = Resources.Load<GameObject>("Scene3\\Prefabs\\Monster\\monSlime\\Slime");
        monItemsPrefab = Resources.LoadAll<GameObject>("Scene3\\Prefabs\\Monster\\monSlime\\SlimeItem");
        int rnadItem= Random.Range(0, monItemsPrefab.Length);
        // GameObject monDropItem
        ani = gameObject.GetComponent<Animator>();
        tr = gameObject.GetComponent<Transform>();
    }
    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        ani.SetBool("ismove", h != 0f);
        Vector3 moveVelocity = Vector3.zero;
        if (h != 0f)
        {
            if(h < 0f)
            {
                moveVelocity = Vector3.left;
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, 0);
            }
            else
            {
                moveVelocity = Vector3.right;
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, 0);  
            }
            transform.position += moveVelocity *  Time.deltaTime * 2f;
        }

        
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

    public override void MonAtk()
    {
        
    }

    public override void MonDropItem()
    {

    }


}

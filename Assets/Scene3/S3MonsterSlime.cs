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
    private float monDis = 3f;
    private Rigidbody2D rb = null;
    private WaitForSeconds wait6Sec = new WaitForSeconds(6);

   
    private void Awake()
    {
        monPrefab = Resources.Load<GameObject>("Scene3\\Prefabs\\Monster\\monSlime\\Slime");
        monItemsPrefab = Resources.LoadAll<GameObject>("Scene3\\Prefabs\\Monster\\monSlime\\SlimeItem");
        int rnadItem= Random.Range(0, monItemsPrefab.Length);
        // GameObject monDropItem
        ani = gameObject.GetComponent<Animator>();
        tr = gameObject.GetComponent<Transform>();
        rb = gameObject.GetComponent<Rigidbody2D>();
  
    }
    private void Update()
    {


    }

    private void OnCollisionEnter2D(Collision2D _collision)
    {
        //if (rb != null)
        Debug.Log(_collision);
        if (_collision.gameObject.CompareTag("Land"))
            {
                Debug.Log(_collision);
                StartCoroutine("MonMovingCrt");
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
        monData.speed = 0.1f;
        monData.dropItem = monItemsPrefab;
    }

    public override IEnumerator MonMovingCrt()
    {
        float h = Input.GetAxis("Horizontal");
       // ani.SetBool("ismove", h != 0f);
        Vector3 moveVelocity = Vector3.zero;
       
        {
            //yield return null;
          
            
                while (true)
                {
                    ani.SetBool("ismove", true);
                    moveVelocity = Vector2.left;
                    rb.AddForce(moveVelocity *1f, ForceMode2D.Impulse);
                    //  GetComponent<Animator>().SetBool("OnAir", !island);
                    yield return wait6Sec;
                }
                        
            
            //{ }
            //    transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, 0);
            //    moveVelocity = Vector3.right;
            //    transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, 0);
           
            //  transform.position += moveVelocity * Time.deltaTime * 2f;
        }

    }

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

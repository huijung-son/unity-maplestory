using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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
    private Rigidbody2D rbLand = null;
    private BoxCollider2D cbLand = null;
    private GameObject land = null;
    float currentPosition;
    float direction = 0.2f;



    private void Awake()
    {
        monPrefab = Resources.Load<GameObject>("Scene3\\Prefabs\\Monster\\monSlime\\Slime");
        monItemsPrefab = Resources.LoadAll<GameObject>("Scene3\\Prefabs\\Monster\\monSlime\\SlimeItem");
        int rnadItem= Random.Range(0, monItemsPrefab.Length);
        // GameObject monDropItem
        ani = gameObject.GetComponent<Animator>();
        tr = gameObject.GetComponent<Transform>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        land = GameObject.FindWithTag("Land");
        //currentPosition = transform.position.x;
    }

    private void Start()
    {
        //rbLand = land.GetComponent<Rigidbody2D>();
        cbLand = land.GetComponent<BoxCollider2D>();
       StartCoroutine("MonMovingCrt");
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("monster"), LayerMask.NameToLayer("monster"), true);


    }
    private void Update()
    {
        //슬람임 랜드조건,,
     

    }



    private void OnCollisionStay2D(Collision2D _collision)
    {
        //if (rb != null)

        //if (_collision.gameObject.CompareTag("Land"))
        //{
        //    StartCoroutine("MonMovingCrt");// StartCoroutine 매니저가 하면 좋음
        //}

    }

    //private void OnCollisionEnter2D(Collision2D _collision)
    //{
    //    //if (rb != null)

    //    if (_collision.gameObject.CompareTag("Land"))
    //    {
    //        StartCoroutine("MonMovingCrt");// StartCoroutine 매니저가 하면 좋음
    //    }
    //}

    public static void IgnoreCollision (Collider2D _colider1_2D, Collider2D _colider2_2D)
    {

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

    //public override IEnumerator MonMovingCrt()
    //{
    //    float h = Input.GetAxis("Horizontal");
    //   // ani.SetBool("ismove", h != 0f);
    //    Vector3 moveVelocity = Vector3.zero;
    //    yield return null;
    //    {
    //        while (true)
    //        {
    //            float rbaX = rb.transform.position.x;
    //            // float rblandX = rbLand.transform.position.x;
    //            float cbLandXHalf = cbLand.size.x * 0.5f;
    //            float landCenter = land.transform.position.x;
    //            float landRightEnd = landCenter + cbLandXHalf - 1f;
    //            float LandLeftEnd = landCenter + (-cbLandXHalf) + 1f;
    //            Debug.Log("슬라임rb 위치" + rbaX);
    //            Debug.Log("랜드 왼 끝" + LandLeftEnd);
    //            Debug.Log("랜드 오 끝" + landRightEnd);
    //            Debug.Log("랜드 반" + cbLandXHalf);
    //            ani.SetBool("ismove", true);
    //            moveVelocity.x +=  Time.time * direction;
    //            float y = transform.position.y;
    //            Debug.Log("떨어진 y값" + y);

    //            if ((int)rbaX == LandLeftEnd)
    //            {
    //               direction = -1;
    //            }

    //            else if ((int)rbaX == landRightEnd)
    //            {
    //                direction *= -1;
    //            }

    //            transform.Translate(moveVelocity *0.5f);
    //            yield return wait6Sec;
    //        }  
    //    }

    //}

    public override IEnumerator MonMovingCrt()
    {
        float h = Input.GetAxis("Horizontal");
        Vector3 moveVelocity = Vector3.zero;
        yield return null;
        
           float rbaX = rb.transform.position.x;
            float cbLandXHalf = cbLand.size.x * 0.5f;
            float landCenter = land.transform.position.x;
            float landRightEnd = landCenter + cbLandXHalf - 1f;
            float landLeftEnd = landCenter + (-cbLandXHalf) + 1f;
            float t = 0f;
            
            while (true)
            {
                // float rblandX = rbLand.transform.position.x;
         
               Debug.Log("슬라임rb 위치" + rbaX);
                Debug.Log("랜드 왼 끝" + landLeftEnd);
                Debug.Log("랜드 오 끝" + landRightEnd);
                Debug.Log("랜드 반" + cbLandXHalf);
                ani.SetBool("ismove", true);
                float y = transform.position.y;
            moveVelocity.x = landLeftEnd;
            rb.transform.position = Vector2.Lerp(rb.transform.position, moveVelocity, t);
                t += Time.deltaTime * 0.002f;

                Debug.Log("떨어진 y값" + y);

                if ((int)rbaX <= landLeftEnd )
                {
                //moveVelocity *= -1;
                yield return moveVelocity.x = landRightEnd;
                }

                if ((int)rbaX == landRightEnd)
                {
                // moveVelocity *= -1;
                yield return  moveVelocity.x = landLeftEnd;
                }

                if (t >= 1f) t = 0f;

                yield return null;
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

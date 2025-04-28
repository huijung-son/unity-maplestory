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
        currentPosition = transform.position.x;
    }

    private void Start()
    {
        //rbLand = land.GetComponent<Rigidbody2D>();
        cbLand = land.GetComponent<BoxCollider2D>();
        //StartCoroutine("MonMovingCrt");

    }
    private void Update()
    {
        //슬람임 랜드조건,,
     

    }
    //private void OnCollisionStay(Collision collision)
    //{
        

    private void OnCollisionEnter2D(Collision2D _collision)
    {
        //if (rb != null)

        if (_collision.gameObject.CompareTag("Land"))
        {
            StartCoroutine("MonMovingCrt");// StartCoroutine 매니저가 하면 좋음
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
        yield return null;
        {
            //yield return null;
            //while (true)
            //{

            //    ani.SetBool("ismove", true);

            //    moveVelocity = Vector2.left;
            //    transform.Translate(moveVelocity *0.1f);
            //    //  GetComponent<Animator>().SetBool("OnAir", !island);
            //    yield return wait6Sec;
            //}
            while (true)
            {
                float rbaX = rb.transform.position.x;
                // float rblandX = rbLand.transform.position.x;
                float cbLandXHalf = cbLand.size.x * 0.5f;
                float landCenter = land.transform.position.x;
                float landRightEnd = landCenter + cbLandXHalf - 0.1f;
                float LandLeftEnd = landCenter + (-cbLandXHalf) + 0.1f;
                Debug.Log("슬라임rb 위치" + rbaX);
                Debug.Log("랜드 왼 끝" + LandLeftEnd);
                Debug.Log("랜드 반" + cbLandXHalf);
                ani.SetBool("ismove", true);
                //moveVelocity = Vector2.Left;
                //if (!(rbaX < cbLandXHalf + landCenter || rbaX < (-cbLandXHalf) + landCenter))
                //    yield return null ;//만약 슬라임의 위치가 랜드 중심점에서 랜드반만큼의 크기가 작다면

                //transform.Translate(new Vector2(1, 0) * 0.06f);
                //currentPosition += Time.deltaTime * direction;
                moveVelocity.x +=  Time.time * direction;
                float y = transform.position.y;
                Debug.Log("떨어진 y값" + y);
                //transform.Translate(new Vector3(currentPosition, 0, 0));
                if ((int)rbaX >= LandLeftEnd)
                {
                    //
                    // float rbAbsX = rbaX < 0 ? -1 : 1;
                    //moveVelocity.x = landRightEnd;
                    // moveVelocity = Vector2.left;
                    // transform.Translate(moveVelocity * 0.1f);
                    // transform.Translate(moveVelocity * 0.06f);

                    direction *= -1;
                    //currentPosition = LandLeftEnd;
                }

                else if ((int)rbaX >= landRightEnd)
                {
                    //moveVelocity.x = LandLeftEnd;
                    //moveVelocity = Vector2.right;
                    //transform.Translate(moveVelocity * 0.1f);
                    //transform.Translate(moveVelocity * 0.06f);
                    direction *= -1;
                   // currentPosition = landRightEnd;
                }
                //transform.position = new Vector3(currentPosition, y, 0);


                //else if ((rbaX < cbLandXHalf + landCenter || rbaX < (-cbLandXHalf) + landCenter))
                //{
                //    // moveVelocity = Vector2.left;
                //    float rbAbsX = rbaX < landCenter ? -1 : 1;
                //   yield return moveVelocity.x = rbAbsX;
                //    //transform.Translate(moveVelocity * 0.06f);
                //}

                //moveVelocity.x = moveVelocity.x * -1;
                //else if (rbaX < ((-cbLandXHalf) + landCenter))
                //{
                //    moveVelocity = new Vector2(1, 0);
                //}
                transform.Translate(moveVelocity *2);
                //transform.position = transform.position + ((new Vector3(currentPosition, y, 0) - transform.position).normalized * Time.deltaTime * direction);
                //transform.position = new Vector3(currentPosition, 0, 0);
                // transform.position = transform.position + ((new Vector3(currentPosition, y, 0) - transform.position).normalized * Time.deltaTime * 2f);
                yield return wait6Sec;
            }

            //{ }
            //    transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, 0);
            //    moveVelocity = Vector3.right;
            //    transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, 0);

          
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

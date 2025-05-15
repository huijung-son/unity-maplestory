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

    // ---
    private Vector3 moveVelocity = Vector3.left;
    float cbLandXHalf = 0f;
    float landCenter = 0f;
    float landRightEnd = 0f;
    float landLeftEnd = 0f;


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
       //StartCoroutine("MonMovingCrt");
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("monster"), LayerMask.NameToLayer("monster"), true);

        cbLandXHalf = cbLand.size.x * 0.5f;
        landCenter = land.transform.position.x;
        landRightEnd = landCenter + cbLandXHalf - 0.5f;
        landLeftEnd = landCenter + (-cbLandXHalf) + 0.5f;
        StartCoroutine("MonMovingCrt");
    }

    private void Update()
    {
        
    }

    //private void Update()
    //{
    //    if (transform.position.x <= landLeftEnd)
    //    {
    //        moveVelocity = Vector3.right;
    //    }
    //    if (transform.position.x >= landRightEnd)
    //    {
    //        moveVelocity = Vector3.left;
    //    }
    //    transform.position += Time.deltaTime * 1f * moveVelocity;
    //}



    private void OnCollisionStay2D(Collision2D _collision)
    {
        //if (rb != null)

        //if (_collision.gameObject.CompareTag("Land"))
        //{
        //    StartCoroutine("MonMovingCrt");// StartCoroutine �Ŵ����� �ϸ� ����
        //}

    }

    //private void OnCollisionEnter2D(Collision2D _collision)
    //{
    //    //if (rb != null)

    //    if (_collision.gameObject.CompareTag("Land"))
    //    {
    //        StartCoroutine("MonMovingCrt");// StartCoroutine �Ŵ����� �ϸ� ����
    //    }
    //}


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
    //            Debug.Log("������rb ��ġ" + rbaX);
    //            Debug.Log("���� �� ��" + LandLeftEnd);
    //            Debug.Log("���� �� ��" + landRightEnd);
    //            Debug.Log("���� ��" + cbLandXHalf);
    //            ani.SetBool("ismove", true);
    //            moveVelocity.x +=  Time.time * direction;
    //            float y = transform.position.y;
    //            Debug.Log("������ y��" + y);

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
        {
            while (true)
            {
                float rbaX = transform.position.x; //������ ��
                float cbLandXHalf = cbLand.size.x * 0.5f; //�����ݶ��̴� �ڽ��� ���� : 4
                float landCenter = land.transform.position.x; // ���忡�� ������ �߽� x�� ex2
                float landRightEnd = landCenter + cbLandXHalf - 1f; //2 + 4 - 1 = 3f ���Ͱ� �� �� �ִ� �ִ� �������� ��
                float LandLeftEnd = landCenter + (-cbLandXHalf) + 1f;// 2 + (-4) + 1 = -3f ���Ͱ� �� �� �ִ� �ִ� ����
                
                ani.SetBool("ismove", true); //�������̽�Ƽ ���� Ʈ����ϱ�
                moveVelocity.x = Time.deltaTime * direction * 5f; // move Vellocity.x ���� �ð��� �������� ����
                float y = transform.position.y; // �����Ϸ�� ������ ���̰����� ����
                Debug.Log("������ y��" + y); // 
                if (rbaX <= LandLeftEnd) // ���� ������ ������ٵ��� ����ص�� �������� ���
                {
                    direction = 0.2f; // ������ �ٲ��
                }
                else if (rbaX >= landRightEnd) // ���� ������ ������ٵ��� ����ص�� �������� ���
                {
                    direction = -0.2f; // ������ �ٲ��
                }
                transform.Translate(moveVelocity); //���� ������ ����� ���� �����̱�
                yield return null;
            }
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

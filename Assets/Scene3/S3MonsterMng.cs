using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class S3MonsterMng : MonoBehaviour
{
    private static S3MonsterMng instance = null;
    private GameObject monPrefab = null;
    private GameObject[] monItemsPrefab = null;
    public List<GameObject> MonList = new List<GameObject>();
    //public static S3MonsterMng Instance
    //{
    //    get
    //    {
    //        if(null == instance)
    //        {
    //            return null;
    //        }
    //        return instance;
    //    }
    //}

    private void Awake()
    {
      monPrefab = Resources.Load<GameObject>("Scene3\\Prefabs\\Monster\\monSlime");
    //if(instance ==null)
    //{
    //    //씬전환되어도 유지되도록
    //    DontDestroyOnLoad(this.gameObject);
    //}else
    //{
    //    Destroy(this.gameObject);
    //}
    
    }
    private void Start()
    {
        MonSpawn(6);
    }

    public void Save()
    {
        //저장 기능!
        print("저장완료!");
        // 유저가 다른곳을 갔다와도 여기에 일정시간 아이템이 남아있어야함..
    }

    private void MonSpawn(int spawnCnt)
    {
        //몬스터 스폰타임, 몬스터 생성 위치, 현재 몬스터 수 //
        for (int i = 0; i < spawnCnt; ++i)
        {
            int rndInx = Random.Range(0, 6);
            GameObject monGo =
                Instantiate(monPrefab);
            monGo.transform.SetParent(transform);
            monGo.transform.localPosition = new Vector3(rndInx, transform.localPosition.y, transform.localPosition.x);
            MonList.Add(monGo);
        }
    }
    //private void 
}

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
    //    //����ȯ�Ǿ �����ǵ���
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
        //���� ���!
        print("����Ϸ�!");
        // ������ �ٸ����� ���ٿ͵� ���⿡ �����ð� �������� �����־����..
    }

    private void MonSpawn(int spawnCnt)
    {
        //���� ����Ÿ��, ���� ���� ��ġ, ���� ���� �� //
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

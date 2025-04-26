using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum DropItem { GameObject, dropItem ,name, cnt};//??


public struct MonsterData
{
    public GameObject monster;
    public string name;
    public int level;
    public int hp;
    public int mp;
    public int exp;
    public float atkPhysical;
    public float defPhysical;
    public float atkMagical;
    public float defMagical;
    public float delayTime;
    public float speed;
    public GameObject[] dropItem;//게임오브젝트를 해야하나? enum
    public Vector3 moveDistance;
    public int cntObj;
}


public abstract class S3MonsterP : MonoBehaviour
{
    public List<MonsterData> MonList = new List<MonsterData>();
    public MonsterData monData;

    bool ismonMove = false;
    public delegate void MonDropItemDelegate();
    public MonDropItemDelegate CallbackMonDropItem;

    public abstract void MonInitSetting();
    public virtual IEnumerator MonMoving(Transform _mon)
    {
        //if(player =null)return;
        var mon = Instantiate(monData.monster);
        Vector3 mondis = monData.moveDistance;
        float monSpeed = monData.speed;
        while(true)
        {
            ismonMove = true;
            mon.transform.position = _mon.position;
            Vector3 monMove = mon.transform.position + (mondis * monSpeed * Time.deltaTime);
            yield return null;
        }
    }      
    public abstract void MonTargetFllowMoveing();
    public abstract IEnumerator MonMovingCrt();
    public abstract void MonDead();
    public abstract void MonAtk();
    public abstract void MonDropItem();

}

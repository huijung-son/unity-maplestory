using UnityEngine;

public class Stage1Scrolling : MonoBehaviour
{
    [SerializeField] private float speed = 1f;  
    [SerializeField] private GameObject wall = null;
    [SerializeField] private GameObject jelly = null;
    
    private GameObject[] gos = null;
    private SpriteRenderer spr;
    
    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        gos = new GameObject[3];
        for (int i = 0; i < gos.Length; ++i)
        {
            gos[i] = new GameObject();
            Vector3 pos = new Vector3(transform.position.x + (i * spr.sprite.bounds.size.x), 0f, 0f);
            gos[i].transform.position = pos;
            gos[i].transform.SetParent(transform);
            SpriteRenderer sr = gos[i].AddComponent<SpriteRenderer>();
            sr.sprite = spr.sprite;
            if (jelly != null)
            {
                BoxCollider2D boxCol = gos[i].GetComponent<BoxCollider2D>();
                if (boxCol != null)
                {
                    GameObject j = Instantiate(jelly);
                    j.transform.position = new Vector3(
                        gos[i].transform.position.x,
                        gos[i].transform.position.y - boxCol.offset.y,
                        0f);
                    j.transform.SetParent(gos[i].transform);
                }
            }
        }
    }

    private void Update()
    {
        foreach (GameObject go in gos)
        {
            if (go.transform.position.x <= -spr.sprite.bounds.size.x)
            {
                int index = GetFarIndex();
                Vector3 newPos = go.transform.position;
                newPos.x = gos[index].transform.position.x + spr.sprite.bounds.size.x;
                go.transform.position = newPos;
            }
            go.transform.Translate(Time.deltaTime * speed * Vector3.left);
        }
    }

    private int GetFarIndex()
    {
        int index = 0;
        for (int i = 0; i < gos.Length; ++i)
        {
            if (gos[index].transform.position.x < gos[i].transform.position.x)
            {
                index = i;
            }
        }
        return index;
    }
    
}

using UnityEngine;

public class BGScroll : MonoBehaviour
{
    [SerializeField] private Sprite image = null;
    [SerializeField] private int imageCnt = 1;
    [SerializeField] private int orderInLayer = 0;
    [SerializeField] private float speed = 1f;

    private GameObject[] bgGoList = null;


    private void Start()
    {
        BuildBackground();
    }

    private void Update()
    {
        Scrolling();
    }

    private void BuildBackground()
    {
        bgGoList = new GameObject[imageCnt];
        for (int i = 0; i < imageCnt; ++i)
        {
            bgGoList[i] = SpawnBackgroundImage(i);
            Vector3 newPos = bgGoList[i].transform.position;
            // image width / image.pixelsPerUnit
            newPos.x = i * image.bounds.size.x;
            bgGoList[i].transform.position = newPos;
        }
    }
    
    private GameObject SpawnBackgroundImage(int _idx = 0)
    {
        GameObject bgGo = new GameObject(name + _idx);
        bgGo.transform.SetParent(transform);
        SpriteRenderer sr = bgGo.AddComponent<SpriteRenderer>();
        sr.sprite = image;
        sr.sortingOrder = orderInLayer;

        return bgGo;
    }

    private void Scrolling()
    {
        foreach (GameObject bgGo in bgGoList)
        {
            if (bgGo.transform.position.x <= -image.bounds.size.x)
            {
                int farIdx = GetFarIndex();

                Vector3 newPos = bgGo.transform.position;
                newPos.x =
                    bgGoList[farIdx].transform.position.x +
                    image.bounds.size.x;
                bgGo.transform.position = newPos;
            }

            bgGo.transform.Translate(
                Vector3.left * speed * Time.deltaTime);
        }
    }

    private int GetFarIndex()
    {
        int farIdx = 0;
        for (int i = 1; i < bgGoList.Length; ++i)
        {
            if (bgGoList[farIdx].transform.position.x
                < bgGoList[i].transform.position.x)
            {
                farIdx = i;
            }
        }

        return farIdx;
    }
}

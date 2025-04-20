using System.Collections;
using UnityEngine;

public class Clock : MonoBehaviour
{
    private GameObject hBlock;
    private GameObject mBlock;
    private GameObject sBlock;

    private void Awake()
    {
        float angleOffset = (2f * Mathf.PI) / 12;
        float angle;
        for (int i = 0; i < 12; ++i)
        {
            angle = angleOffset * i;
            Vector3 _dir = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0f);
            GameObject block = InitBlock(Color.white);
            block.transform.position = _dir * 5f;
            if (i % 3 != 0)
            {
                block.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            }
            block.transform.SetParent(transform);
        }
        GameObject center = InitBlock(Color.white);
        
        hBlock = InitBlock(Color.red);
        hBlock.transform.position = Vector3.zero;
        hBlock.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        
        mBlock = InitBlock(Color.blue);
        mBlock.transform.position = Vector3.zero;
        mBlock.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        
        sBlock = InitBlock(Color.green);
        sBlock.transform.position = Vector3.zero;
        sBlock.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
    }

    private void Start()
    {
        StartCoroutine(ClockCoroutine());
    }

    private IEnumerator ClockCoroutine()
    {
        while (true)
        {
            double totalSeconds = System.DateTime.Now.TimeOfDay.TotalSeconds;
            int m = (int)(totalSeconds / 60) % 60;
            int s = (int)totalSeconds % 60;
            int h = (int)(totalSeconds / 3600);
            
            float angleOffsetS = (2f * Mathf.PI) / 60f;
            float angleS = (Mathf.PI / 2f) - (angleOffsetS * s);
            Vector3 posS = new Vector3(Mathf.Cos(angleS), Mathf.Sin(angleS), 0f);
            sBlock.transform.position = posS * 3f;
            
            float angleOffsetM = (2f * Mathf.PI) / 60f;
            float angleM = (Mathf.PI / 2f) - (angleOffsetM * m);
            Vector3 posM = new Vector3(Mathf.Cos(angleM), Mathf.Sin(angleM), 0f);
            mBlock.transform.position = posM * 2f;
            
            float angleOffsetH = (2f * Mathf.PI) / 60f;
            float angleH = (Mathf.PI / 2f) - (angleOffsetH * ((h - 12) * 5));
            Vector3 posH = new Vector3(Mathf.Cos(angleH), Mathf.Sin(angleH), 0f);
            hBlock.transform.position = posH * 2f;
            
            yield return new WaitForSeconds(1f);
        }
    }

    private GameObject InitBlock(Color _color)
    {
        GameObject block = new GameObject();
        MeshFilter mf = block.AddComponent<MeshFilter>();
        MeshRenderer mr = block.AddComponent<MeshRenderer>();
        Material mat = new Material(Shader.Find("Universal Render Pipeline/Lit"));
        mr.material = mat;
        mr.material.color = _color;
        Mesh mesh = new Mesh();
        mesh.vertices = new Vector3[]
        {
            new Vector3(0.5f, 0.5f, 0.5f),
            new Vector3(-0.5f, 0.5f, 0.5f),

            new Vector3(-0.5f, -0.5f, 0.5f),
            new Vector3(0.5f, -0.5f, 0.5f),

            new Vector3(-0.5f, 0.5f, -0.5f),
            new Vector3(0.5f, 0.5f, -0.5f),

            new Vector3(0.5f, -0.5f, -0.5f),
            new Vector3(-0.5f, -0.5f, -0.5f),
        };
        mesh.triangles = new int[]
        {
            1, 3, 0,    1, 2, 3,
            1, 4, 2,    4, 7, 2,
            4, 5, 7,    5, 6, 7,
            5, 0, 6,    0, 3, 6,
            5, 4, 0,    1, 0, 4,
            3, 2, 6,    6, 2, 7

        };
        mesh.normals = new Vector3[]
        {
            new Vector3(0f, 0f, -1f),
            new Vector3(0f, 0f, -1f),
            new Vector3(0f, 0f, -1f),
            new Vector3(0f, 0f, -1f),
            new Vector3(0f, 0f, -1f),
            new Vector3(0f, 0f, -1f),
            new Vector3(0f, 0f, -1f),
            new Vector3(0f, 0f, -1f),
        };
        mf.mesh = mesh;
        return block;
    }
}

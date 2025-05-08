using UnityEngine;

public class BGTileMap : MonoBehaviour
{
    [SerializeField] private GameObject tilePrefab = null;
    [SerializeField] private Sprite[] tileSet = null;

    private readonly int[] tileMap =
    {
        1, 1, 1, 1, 1, 1,
        1, 4, 0, 0, 0, 1,
        1, 0, 2, 2, 0, 2,
        2, 0, 2, 3, 0, 1,
        1, 0, 0, 0, 0, 1,
        1, 1, 1, 1, 1, 1
    };
    private const int rowCnt = 6;
    private const int colCnt = 6;
    private Vector2 tileSize = new Vector2(0.32f, 0.32f);


    private void Start()
    {
        float tileWidth = 32f;
        float tileHeight = 32f;
        tileSize.x = tileWidth / tileSet[0].pixelsPerUnit;
        tileSize.y = tileHeight / tileSet[0].pixelsPerUnit;

        BuildTileMap();
    }


    private void BuildTileMap()
    {
        float totalCol = colCnt * tileSize.x;
        float totalRow = rowCnt * tileSize.y;
        Vector2 tileSizeHalf = tileSize * 0.5f;
        float startPosX = -(totalCol * 0.5f) + tileSizeHalf.x;
        float startPosY = (totalRow * 0.5f) - tileSizeHalf.y;

        for (int row = 0; row < rowCnt; ++row)
        {
            for (int col = 0; col < colCnt; ++col)
            {
                Vector3 pos = new Vector3(
                    startPosX + (col * tileSize.x),
                    startPosY - (row * tileSize.y),
                    0f);
                GameObject tileGo =
                    Instantiate(
                        tilePrefab,
                        pos,
                        Quaternion.identity,
                        transform);
                SpriteRenderer sr =
                    tileGo.GetComponent<SpriteRenderer>();
                int tileIdx = tileMap[(row * colCnt) + col];
                sr.sprite = tileSet[tileIdx];
            }
        }
    }
}

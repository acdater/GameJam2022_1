using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesSpawner : MonoBehaviour
{
    [SerializeField] private GameObject m_TilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnTiles(Vector2 _boardSize)
    {
        Vector3 _startPoint = Vector3.up;
        _startPoint.y = 0.001f;

        for(int i=0; i<_boardSize.y; i++)
        {
            for(int j=0; j<_boardSize.x; j++)
            {
                Vector3 _pos = _startPoint + Vector3.right * j + Vector3.forward * i;
                var _tile = Instantiate(m_TilePrefab, _pos, m_TilePrefab.transform.rotation);
            }
        }
    }
}

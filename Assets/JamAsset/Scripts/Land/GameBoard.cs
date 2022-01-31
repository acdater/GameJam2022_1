using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    [SerializeField] private Vector2 m_Size = new Vector2(5, 5);
    [SerializeField] private TilesSpawner m_TileSpawner;
    [SerializeField] private VictimSpawner m_VictimSpawner;
    [SerializeField] private int m_NumberOfVictims = 2;
    [SerializeField] private GameLevel m_GameLevel;

    void Start()
    {
        SetSize();
        SetPosition();
        SpawnTiles();

        SpawnVictims();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetSize()
    {
        transform.localScale = new Vector3(m_Size.x, transform.localScale.y, m_Size.y);
    }

    private void SetPosition()
    {
        int x_offset = (int)m_Size.x / 2;
        int z_offset = (int)m_Size.y / 2;

        transform.position += new Vector3(x_offset, 0, z_offset);
    }

    private void SpawnTiles()
    {
        m_TileSpawner.SpawnTiles(m_Size);
    }

    private void SpawnVictims()
    {
        m_NumberOfVictims = 2 + m_GameLevel.level;
        m_VictimSpawner.SpawnVictims(m_Size, m_NumberOfVictims);
    }
}

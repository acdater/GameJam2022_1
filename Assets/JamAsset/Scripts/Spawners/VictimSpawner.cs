using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictimSpawner : MonoBehaviour
{
    [SerializeField] private GameObject m_VictimPrefab;

    HashSet<Vector3> _positions = new HashSet<Vector3>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnVictims(Vector2 _boardSize, int num)
    {
        while(_positions.Count < num)
        {
            Vector3 _pos = new Vector3((int)Random.Range(0, _boardSize.x), 0.001f, (int)Random.Range(0, _boardSize.y));
            _positions.Add(_pos);
        }

        foreach(var _point in _positions)
        {
            Instantiate(m_VictimPrefab, _point, m_VictimPrefab.transform.rotation);

        }
    }

    public HashSet<Vector3> GetVictimsPositions()
    {
        return _positions;
    }

}

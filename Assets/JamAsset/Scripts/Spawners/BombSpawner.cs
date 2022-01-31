using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    public GameObject m_BombPrefab;

    [SerializeField] private VictimSpawner m_VictimSpawner;

    [SerializeField] private Vector3[] m_SpawnFlatPositions;
    [SerializeField] private int m_VictimsCount = 0;

    [SerializeField] private float m_SpawnDelta = 3.0f;

    private Coroutine m_BombCoroutine;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (m_BombCoroutine == null && m_VictimsCount > 0)
        {
            m_BombCoroutine = StartCoroutine(nameof(SpawnBomb));
        }

        if (m_VictimsCount == 0)
        {
            SetFlatPositions();
        }
    }

    private void SetFlatPositions()
    {
        m_VictimsCount = m_VictimSpawner.GetVictimsPositions().Count;

        m_SpawnFlatPositions = new Vector3[m_VictimsCount];

        int _idx = 0;
        foreach (var _pos in m_VictimSpawner.GetVictimsPositions())
        {
            m_SpawnFlatPositions[_idx] = _pos;
            _idx++;
        }
    }

    private IEnumerator SpawnBomb()
    {
        yield return new WaitForSeconds(m_SpawnDelta);

        int _randIdx = Random.Range(0, m_VictimsCount);

        Vector3 _bombPos = m_SpawnFlatPositions[_randIdx];
        _bombPos.y = transform.position.y;

        var _bomb = Instantiate(m_BombPrefab, _bombPos, m_BombPrefab.transform.rotation);

        _bomb.GetComponent<BombController>().m_TargetPos = m_SpawnFlatPositions[_randIdx];


        m_BombCoroutine = null;
    }


}

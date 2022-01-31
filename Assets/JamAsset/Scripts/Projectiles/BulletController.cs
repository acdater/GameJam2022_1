using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float m_Speed = 5.0f;
    [SerializeField] private Vector3 m_TargetPos;
    [SerializeField] private float m_MinimalDistanceToTarget = 0.5f;
    [SerializeField] private float m_OverlapRadius = 0.5f;
    [SerializeField] private GameObject m_ShieldPrefab;

    public LayerMask victimLayer;

    private Vector3 m_Direction;

    void Start()
    {
        Destroy(this.gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_TargetPos != null)
        {
            MoveToTarget();
        }
    }

    private void MoveToTarget()
    {

        transform.Translate(m_Direction * m_Speed * Time.deltaTime);

        bool _isNearTarget = IsNearTarget();

        if (_isNearTarget == true)
        {
            SaveVictim();
        }
    }

    public void SetTarget(Vector3 _target)
    {
        m_TargetPos = _target;

        m_Direction = m_TargetPos - transform.position;
    }

    private void SaveVictim()
    {
        Collider[] hitColliders = Physics.OverlapSphere(m_TargetPos, 0.5f);
        foreach (var hitCollider in hitColliders)
        {
            var _victim = hitCollider.GetComponent<VictimController>();
            if (_victim != null)
            {
                _victim.IsSaved = true;


                if (m_ShieldPrefab != null)
                {
                    var _shield = Instantiate(m_ShieldPrefab, m_TargetPos, m_ShieldPrefab.transform.rotation);
                    Destroy(_shield, 2.0f);
                }
            }
        }

        Destroy(this.gameObject);

    }

    private void OnDrawGizmos()
    {
        if (m_TargetPos != null)
        {
            Gizmos.DrawSphere(m_TargetPos, 0.5f);
        }
    }

    private bool IsNearTarget()
    {
        if (m_TargetPos != null)
        {
            float _d = Vector3.Distance(transform.position, m_TargetPos);
            if (_d < m_MinimalDistanceToTarget)
            {
                return true;
            }
        }

        return false;
    }

}

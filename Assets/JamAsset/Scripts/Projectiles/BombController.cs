using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    public Vector3 m_TargetPos;
    public GameObject m_OnTargetMark;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(nameof(InstantiateMarkPrefab));
        Destroy(this.gameObject, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision != null)
        {
            VictimController _victim = collision.gameObject.GetComponent<VictimController>();

            if (_victim != null)
            {
                _victim.ProccesDamage();
                Destroy(this.gameObject);
            }

        }
    }

    private IEnumerator InstantiateMarkPrefab()
    {
        yield return new WaitForSeconds(0.1f);

        var _mark = Instantiate(m_OnTargetMark, m_TargetPos, m_OnTargetMark.transform.rotation);
        Destroy(_mark.gameObject, 1.5f);
    }
}

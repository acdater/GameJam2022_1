using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private Transform m_FirePoint;
    [SerializeField] private GameObject m_BulletPrefab;
    [SerializeField] private AudioSource m_AudioSource;

    private Coroutine m_FireCoroutine;

    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        ControlFire();
    }

    private void ControlFire()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // Save the info
        RaycastHit hit;
        // You successfully hit
        if (Physics.Raycast(ray, out hit))
        {
            GameObject _tile = hit.collider.gameObject.CompareTag("Tile") ? hit.collider.gameObject : null;

            if (_tile != null)
            {
                // Find the direction to fire
                Vector3 dir = hit.point - _tile.transform.position;

                Debug.DrawLine(transform.position, hit.point, Color.blue);

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    if (m_FireCoroutine == null)
                    {
                        Vector3 _targetPos = _tile.transform.position;
                        m_FireCoroutine = StartCoroutine(nameof(FireBullet), _targetPos);
                    }
                }


            }

            

        }
    }

    private IEnumerator FireBullet(Vector3 _target)
    {
        var _bullet = Instantiate(m_BulletPrefab, m_FirePoint.position, m_BulletPrefab.transform.rotation);

        PlayShotSound();


        _bullet.GetComponent<BulletController>().SetTarget(_target);

        yield return new WaitForSeconds(1.5f);

        m_FireCoroutine = null;
    }

    private void PlayShotSound()
    {
        m_AudioSource.Play();
    }
}

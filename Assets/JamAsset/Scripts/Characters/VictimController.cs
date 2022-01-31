using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictimController : MonoBehaviour
{
    [SerializeField]
    private LevelManager m_levelManager;
    [SerializeField]
    private bool m_IsSaved = false;
    [SerializeField]
    private bool m_IsDamaged = false;

    private Coroutine m_SavedCoroutine;

    public bool IsSaved
    {
        get
        {
            return m_IsSaved;
        }

        set
        {
            m_IsSaved = value;

            if (m_IsSaved == true)
            {
                if (m_SavedCoroutine == null)
                {
                    StartCoroutine(nameof(ResetSavingBool));
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        m_levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ProccesDamage()
    {
        if (m_IsSaved == true)
        {
            m_levelManager.AddSaving(1);
            Debug.Log("Victim is Saved!");
            return;
        }

        m_IsDamaged = true;

        DeathManager.Instance.Defeat();

        Destroy(this.gameObject);
    }

    private IEnumerator ResetSavingBool()
    {
        yield return new WaitForSeconds(2.0f);
        m_IsSaved = false;
        m_SavedCoroutine = null;
    }


}

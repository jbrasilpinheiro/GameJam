using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private float m_playerHealth;
    [SerializeField]
    private SpriteRenderer m_spriteRenderer;

    public float PlayerHealth => m_playerHealth;
    public void TakeDamage(float damage)
    {
        m_playerHealth -= damage;
        StartCoroutine(FlashRoutine());
    }

    public IEnumerator FlashRoutine()
    {
        m_spriteRenderer.material.color = Color.red;
        yield return new WaitForSeconds(.2f);
        m_spriteRenderer.material.color = Color.white;
    }

}

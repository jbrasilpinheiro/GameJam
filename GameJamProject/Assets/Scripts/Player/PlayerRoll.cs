using UnityEngine;
using System.Collections;

public class PlayerRoll : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D m_rigidbody;
    [SerializeField]
    private Animator m_animator;
    private bool m_rolling;
    private float m_rollDuration;
    private float m_rollStartTime;
    private float m_rollPower;
    private Vector2 m_rollDirection;
    private float m_cooldown;

    public bool Rolling => m_rolling;

    private void Start()
    {
        m_cooldown= 0f;
        m_rollDuration = .5f;
        m_rollPower = 10;
        m_rolling = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !m_rolling && m_cooldown <= .1f)
        {
            m_animator.SetBool("IsRolling", true);
            m_cooldown = .5f;
            StartCoroutine(Cooldown());
            m_rolling = true;
            m_rollStartTime = Time.time;
            m_rollDirection = m_rigidbody.velocity.normalized;
            if (m_rollDirection.sqrMagnitude < 0.1f)
            {
                m_rollDirection = Vector2.right;
            }
            m_rigidbody.velocity = Vector2.zero;
            m_rigidbody.AddForce(m_rollDirection * m_rollPower , ForceMode2D.Impulse);
        }

        if (m_rolling && Time.time - m_rollStartTime > m_rollDuration)
        {
            m_rolling = false;
        }
    }

    private IEnumerator Cooldown()
    {
        while(m_cooldown>= 0)
        {
            m_cooldown-=Time.deltaTime;
            yield return null;
        }
        m_animator.SetBool("IsRolling", false);
    }
}


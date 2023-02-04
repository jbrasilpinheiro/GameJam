using UnityEngine;
using System;


public class MovePlayer : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D m_rigidbody;

    [SerializeField]
    private float m_speed;

    [SerializeField]
    private Animator m_animator;

    [SerializeField]
    private PlayerRoll m_playerRoll;

    private Vector2 m_localScale;

    private float m_speedX, m_speedY;
    private bool isIdle;

    private void Start()
    {
        m_localScale = transform.localScale;
    }

    public void Update()
    {
        m_speedX = Input.GetAxis("Horizontal");
        m_speedY = Input.GetAxis("Vertical");

        isIdle = m_speedX == 0 && m_speedY == 0;

        if (m_speedX != 0 || m_speedY != 0)
        {
            m_animator.SetBool("IsMoving", true);
            if (m_speedX < 0)
            {
                transform.localScale = new Vector2(-m_localScale.x, m_localScale.y);
            }
            else
            {
                transform.localScale = m_localScale;
            }
        }
        else 
        {
            m_animator.SetBool("IsMoving", false);
            m_speedX = 0;
            m_speedY = 0;
        }

        m_animator.SetFloat("HorizontalMove", m_speedX);
        m_animator.SetFloat("VerticalMove", m_speedY);
    }

    public void FixedUpdate()
    {
        if (!m_playerRoll.Rolling)
        {
            m_rigidbody.velocity = new Vector2(m_speedX * Time.deltaTime * m_speed, m_speedY * Time.deltaTime * m_speed);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Projectile : MonoBehaviour
{
    [Inject]
    private PlayerManager m_player;
    [SerializeField]
    private Rigidbody2D m_rigidbody;

    public void SetTargetAndForce(Vector2 dir, float force)
    {
        m_rigidbody.velocity = dir * force;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            m_player.TakeDamage(1);
            Destroy(gameObject);
        }
    }

}

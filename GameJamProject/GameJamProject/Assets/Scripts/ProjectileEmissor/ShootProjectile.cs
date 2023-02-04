using System.Collections;
using UnityEngine;
using Zenject;

public class ShootProjectile : MonoBehaviour
{
    [Inject]
    private IInstantiator m_instantiator;
    [SerializeField]
    private GameObject m_projectilePrefab;
    private Vector2 m_direction;
    private float m_shootForce;
    private Projectile m_projectile;

    private void Start()
    {
        StartCoroutine(ShootRandomDirection());
        m_shootForce = 10;
    }

    private IEnumerator ShootRandomDirection()
    {
        while (true)
        {
            if(Random.Range(0,2) == 0)
            {
                m_direction = new Vector2(Random.Range(3, -10), Random.Range(3, -10));
            }
            else
            {
                m_direction = new Vector2(Random.Range(3, 10), Random.Range(3, -10));
            }
            m_projectile = m_instantiator.InstantiatePrefabForComponent<Projectile>(m_projectilePrefab, transform);
            m_projectile.SetTargetAndForce(m_direction.normalized, m_shootForce);
            yield return new WaitForSeconds(1f);
        }

    }
}


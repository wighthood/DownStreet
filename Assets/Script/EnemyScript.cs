using UnityEditor;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject m_player;
    [SerializeField] private Rigidbody2D m_enemy;
    [SerializeField] private float m_speed;
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, m_player.transform.position, m_speed * Time.deltaTime);
    }
}

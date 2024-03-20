using TreeEditor;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject m_player;
    [SerializeField] private Rigidbody2D m_enemy;
    [SerializeField] private float m_speed;
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, m_player.transform.position, m_speed * Time.deltaTime);
        if(!m_player.GetComponent<PlayerControl>().isgrounded)
        {
            transform.position += (Vector3.up * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            m_player.GetComponent<PlayerControl>().life -= 1;
            Destroy(gameObject);
        }
    }
}

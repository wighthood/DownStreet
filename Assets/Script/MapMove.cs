using UnityEngine;

public class MapMove : MonoBehaviour
{
    public GameObject Player;
    public GameObject Parent;
    [SerializeField] private Rigidbody2D m_rigidBody;
    [SerializeField] private float m_speed;
    [SerializeField] private GameObject m_wall;

    void Update()
    {
        if (!Player.GetComponent<PlayerControl>().isgrounded)
        {
            m_rigidBody.velocity = Vector2.up * m_speed;
        }
        else
        {
            m_rigidBody.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Destroy"))
        {
            Destroy(gameObject);
        }
    }
}

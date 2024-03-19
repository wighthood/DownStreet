using System.Collections;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] Rigidbody2D Rb;
    private float speed = 4;

    private void Start()
    {
        Rb.velocity = Vector2.down*speed;
        StartCoroutine(SelfDestruct());
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("trigger"))
        {
            if (other.CompareTag("Enemy"))
            {
                Destroy(other.gameObject);
            }
            Destroy(gameObject);
        }
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}

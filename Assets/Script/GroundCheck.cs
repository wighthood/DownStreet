using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("trigger") || !other.CompareTag("Enemy"))
        {
            Player.GetComponent<PlayerControl>().isgrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Player.GetComponent<PlayerControl>().isgrounded = false;
    }
}

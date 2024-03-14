using UnityEngine;

public class GenerationTrigger : MonoBehaviour
{

    [SerializeField] private GameObject m_roadSection;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("trigger"))
        {
            Vector3 newpos = new Vector3(transform.position.x, transform.position.y -7, transform.position.z);
            Instantiate(m_roadSection, newpos,Quaternion.identity) ;
        }
    }
}

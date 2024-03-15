using UnityEngine;

public class GenerationTrigger : MonoBehaviour
{

    [SerializeField] private GameObject m_roadSection;
    [SerializeField] private GameObject m_obstacle;
    private bool spawned = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("trigger") && !spawned)
        {
            spawned = true;
            Vector3 newpos = new Vector3(other.transform.position.x, other.transform.position.y -7,0);
            GameObject wall = Instantiate(m_roadSection, newpos, Quaternion.identity);
            wall.GetComponent<MapMove>().Player = gameObject;
            for (int i = 0; i < Random.Range(1,5); i++)
            {
                Vector3 obstaclePos = new Vector3(wall.transform.position.x+ Random.Range(-7,7), wall.transform.position.y + Random.Range(0,-5), 0);
                Instantiate(m_obstacle, obstaclePos, Quaternion.identity, wall.transform);
            }
        }        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("trigger"))
        {
            spawned = false;
        }
    }
}

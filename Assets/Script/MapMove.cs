using UnityEngine;

public class MapMove : MonoBehaviour
{
    void Update()
    {
        transform.position += new Vector3(0, 3,0)*Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Destroy"))
        {
            Destroy(gameObject);
        }
    }
}

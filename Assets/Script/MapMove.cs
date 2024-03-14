using UnityEngine;

public class MapMove : MonoBehaviour
{
    void Update()
    {
        transform.position += new Vector3(0, 3,0)*Time.deltaTime;
    }
}

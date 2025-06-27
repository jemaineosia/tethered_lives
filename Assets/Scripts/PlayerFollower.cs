using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    public Transform target;     // assign the blue player
    public float speed = 2f;

    void Update()
    {
        Vector3 dir = (target.position - transform.position).normalized;
        transform.position += dir * speed * Time.deltaTime;
    }
}


using UnityEngine;

public class EnnemieIA : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int waypointIndex = 0;

    void Start()
    {
        target = Waypoints.points[0];
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.3)
        {
            GetNextWayPoint();
        }
    }

    private void GetNextWayPoint()
    {
        if (waypointIndex >= Waypoints.points.Length - 1)
        {
            waypointIndex = 0;
        }

        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }
   
    

}

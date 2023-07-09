using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    public Transform[] wayPoints;
    private void OnDrawGizmos()
    {
        if(wayPoints!=null && wayPoints.Length > 1)
        {
            Gizmos.color = Color.red;
            for(int i = 0; i < wayPoints.Length - 1; i++)
            {
                Transform s = wayPoints[i];
                Transform g = wayPoints[i + 1];
                Gizmos.DrawLine(s.position, g.position);
            }
            //Gizmos.DrawLine(wayPoints[0].position, wayPoints[wayPoints.Length - 1].position);
        }
    }
}

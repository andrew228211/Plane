
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed;
    //public Transform[] wayPoints;
    private bool active;
    public Transform attackPoint;
    public float attackCoolDown;
    private float timeCoolDown;
    public Bullet attack;
    private void Start()
    {
    }
    private void Update()
    {
        if (timeCoolDown <= 0)
        {
            Attack();
            timeCoolDown = Random.Range(4, 16);
        }
        timeCoolDown -= Time.deltaTime;
    }
    void Attack()
    {
        Bullet enemyAttack= Instantiate(attack, attackPoint.position, Quaternion.identity);
        enemyAttack.DestroyBullet();

    }
    private IEnumerator MoveToWaypoints(Transform[] waypoints, int numWaypoints)
    {
        if (numWaypoints == 0)
        {
            int nextPoint = 0;
            while (transform.position != waypoints[nextPoint].position)
            {
                transform.position = Vector3.MoveTowards(transform.position, waypoints[nextPoint].position, moveSpeed * Time.deltaTime);
                yield return null;
            }
        }
        for (int i = 0; i < numWaypoints; i++)
        {          
            active = true;
            int nextPoint = i + 1;
            if (numWaypoints == 1)
            {
                nextPoint = 0;
            }
            if (nextPoint >= numWaypoints)
            {
                active = false;
                yield break;
            }
            
            while (transform.position != waypoints[nextPoint].position)
            {
                transform.position = Vector3.MoveTowards(transform.position, waypoints[nextPoint].position, moveSpeed * Time.deltaTime);
                yield return null;
            }
        }
    }
    public void Init(Transform[] points,int p)
    {
        timeCoolDown = Random.Range(attackCoolDown, 25);
        StartCoroutine(MoveToWaypoints(points, p));
    }
    public void TakeDamge()
    {
        GameManger.instance.player.ChangeScore();
        gameObject.SetActive(false);
    }
}

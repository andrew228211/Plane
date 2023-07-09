
using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{   
    public Bullet playerAttack;
    public Transform attackPoint;   
    private float timeCoolDown;
    public int hp = 3;
    public int score = 0;
    //public float moveSpeed;
    public float attackCoolDown;
    public UnityEvent ScoreEvent { get; private set; } = new UnityEvent();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 directionInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        //transform.Translate(directionInput * Time.deltaTime*moveSpeed);
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
          
            if (touch.phase == TouchPhase.Ended)
            {              
                Vector3 touchPosition = touch.position;
              
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(touchPosition);
                worldPosition.z = 0f; 

                // Di chuy?n player t?i v? trí ch?m
                transform.position = worldPosition;
            }
        }
        if (timeCoolDown <= 0)
            {
                Attack();
                timeCoolDown = attackCoolDown;
            }
        timeCoolDown -= Time.deltaTime;
    }
    void Attack()
    {
        Bullet bullet=Instantiate(playerAttack, attackPoint.position, Quaternion.identity);
        bullet.DestroyBullet();
    }
    public void TakeDamge()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
            GameManger.instance.gameOver.SetActive(true);
        }
        else
        {
            hp -= 1;
        }
    }
    public void ChangeScore()
    {
        score += 1;
        ScoreEvent?.Invoke();
    }
}

using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public bool active;
    public int totalEnemy;
    public float enemyInterval = 5;
    public EnemyPath[] enemyPaths;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < enemyPaths.Length; i++)
        {
            EnemyPath enemyPath = enemyPaths[i];
            SpawnPosEnemy(enemyPath);         
            yield return new WaitForSeconds(9);
            GameManger.instance.player.playerAttack.collider2D.enabled = true;
            yield return new WaitForSeconds(5);
            if (i == enemyPaths.Length - 1)
            {
                i = -1;
            }
            GameManger.instance.player.playerAttack.collider2D.enabled = false;
            yield return new WaitForSeconds(1);
        }
    }

    private void SpawnPosEnemy(EnemyPath enemyPath)
    {
        for(int i = 0; i < totalEnemy; i++)
        {
            Enemy enemy = ObjectPool.instance.SpawnFromPool("Enemy", transform.position, Quaternion.identity);
            enemy.gameObject.SetActive(true);
            enemy.Init(enemyPath.wayPoints, i+1);
        }
    }
}

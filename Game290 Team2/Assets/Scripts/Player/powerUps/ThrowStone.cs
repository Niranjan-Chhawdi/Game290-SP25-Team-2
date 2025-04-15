using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowStone : MonoBehaviour
{
    public GameObject stonePrefab;
    public float force = 8f;
    public float stunTime = 2f;
    public bool doThrow = false;

    private bool stoneOnTheWay = false;
    private GameObject currentStone;
    private float timer = 0f;

    void Update()
    {
        if (doThrow && stonePrefab != null)
        {
            if (!stoneOnTheWay)
            {
                ThrowStoneNow();
            }
            else if (stoneOnTheWay && currentStone != null)
            {
                List<GameObject> hitEnemies = StunHitEnemies(currentStone.transform.position);
                if (hitEnemies.Count > 0)
                {
                    Destroy(currentStone);
                    stoneOnTheWay = false;
                    doThrow = false;
                }
            }

            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                doThrow = false;
                stoneOnTheWay = false;
                if (currentStone != null) Destroy(currentStone);
            }
        }
    }

    void ThrowStoneNow()
    {
        currentStone = Instantiate(stonePrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = currentStone.GetComponent<Rigidbody2D>();
        Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mouseWorldPos - (Vector2)transform.position).normalized;
        rb.AddForce(direction * force, ForceMode2D.Impulse);

        stoneOnTheWay = true;
        timer = 3f; // Set the timer for how long the stone will be active
    }

    List<GameObject> StunHitEnemies(Vector2 pos)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        List<GameObject> hitList = new List<GameObject>();

        foreach (GameObject enemy in enemies)
        {
            float dist = Vector2.Distance(pos, enemy.transform.position);
            if (dist < 1.5f)
            {
                EnemyBehavior eb = enemy.GetComponent<EnemyBehavior>();
                if (eb != null)
                {
                    eb.PauseEnemy(stunTime);
                }
                else
                {
                    Debug.Log("EnemyBehavior component not found on " + enemy.name);
                }
                hitList.Add(enemy);
            }
        }

        return hitList;
    }
}

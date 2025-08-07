using System.Runtime.CompilerServices;
using UnityEngine;

public class attack : MonoBehaviour
{
    public Rigidbody2D rg;
    public GameObject attackPoint;
    public float radius;
    public LayerMask enemies;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void hit()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(attackPoint.transform.position, radius, enemies);

        foreach (Collider2D enemyGameobject in enemy)
        {
            Debug.Log("hit enemy");
        }
    }
    private void OnDrawGizmosSelected()
    {
    Gizmos.DrawWireSphere(attackPoint.transform.position, radius);
    }
    public void endAttack()
    {
        
    }
}

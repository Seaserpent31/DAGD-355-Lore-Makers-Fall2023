using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectroEffect_Lauren : MonoBehaviour
{
    public LayerMask enemyLayer;
    
    public void ElectroEffect()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 7f, enemyLayer);

        // For each enemy detected, deal damage.
        foreach (Collider2D collider in colliders)
        {
            // Check if the detected object has an enemy script/component.
            EnemyMovement_Lauren enemy = collider.GetComponent<EnemyMovement_Lauren>();

            if (enemy != null)
            {
                Debug.Log("Electro.");

            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectiles : MonoBehaviour
{
    [Range(0, 10)]
    public int DamageValue;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) { collision.gameObject.GetComponent<HealthManager>().CurrentHealth -= DamageValue; gameObject.SetActive(false); }
    }
}
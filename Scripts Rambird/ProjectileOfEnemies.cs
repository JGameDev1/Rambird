using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileOfEnemies : MonoBehaviour
{
    [Range(0, 10)]
    public int DamageValue;
    private void OnTriggerEnter2D(Collider2D Collision)
{if(Collision.gameObject.CompareTag("Player")){Collision.gameObject.GetComponent<HealthManager>().CurrentHealth-=DamageValue;gameObject.SetActive(false);}
if(Collision.gameObject.CompareTag("Player")&&Collision.gameObject.GetComponent<HealthManager>().CurrentArmor>0){Collision.gameObject.GetComponent<HealthManager>().CurrentArmor-=DamageValue;gameObject.SetActive(false);}
}
}

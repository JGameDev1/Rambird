using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstaKill : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D Other)
    {if(Other.gameObject.tag=="Player")Other.gameObject.GetComponent<HealthManager>().CurrentHealth = 0;}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathlyTriggerZones : MonoBehaviour
{private float DeathCronometre;
public float OnDeathCronometre;
    private void Start()
    {DeathCronometre=OnDeathCronometre;}
    
    private void OnTriggerStay2D(Collider2D Other)
    {DeathCronometre-=Time.deltaTime;if(DeathCronometre<0){Other.gameObject.GetComponent<HealthManager>().CurrentHealth=0;}}
    private void OnTriggerExit2D(Collider2D collision)
    {DeathCronometre = OnDeathCronometre; }
}

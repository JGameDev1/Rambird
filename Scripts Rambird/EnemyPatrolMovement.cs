using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class EnemyPatrolMovement : MonoBehaviour
{   [Range(0, 100)]
    public int DamageValue; public int TopH, ButtomH, LeftMove, RightMove;
    public Rigidbody2D EnemyRb;
    public Vector2 LastPositionRegistred;
    public float EnemySpeed, OnMoveCronometre, ReinitializeCronometreIn, ZoneForce;
    private float MoveCronometre;
    public bool IsLookingAtTheRight, IsLookingAtTheLeft, IsMoving;
    public Animator _Animator;
    public HealthManager _HealthManager;
    public float LimitsOfMovementX, NegLimitsOfMovementX,LimitsOfMovementY,NegLimitsOfMovementY;

    void MovementConf()
    { MoveCronometre -= Time.fixedDeltaTime;
        if (MoveCronometre > 0) {EnemyRb.velocity=LastPositionRegistred*EnemySpeed;IsMoving=true;}
        else {EnemyRb.velocity = Vector2.zero * EnemySpeed; IsMoving = false;
        LastPositionRegistred = new Vector2(Random.Range(LeftMove, RightMove), Random.Range(ButtomH, TopH)); }
        if (MoveCronometre <= ReinitializeCronometreIn) {MoveCronometre = OnMoveCronometre;}}

    void DontCrossTheLimits() 
    {if(transform.position.x>= LimitsOfMovementX){transform.position=new Vector3(LimitsOfMovementX, transform.position.y,transform.position.z);}
    if (transform.position.x<= NegLimitsOfMovementX){transform.position = new Vector3(NegLimitsOfMovementX, transform.position.y, transform.position.z);}
    if (transform.position.y>= LimitsOfMovementY){transform.position = new Vector3(transform.position.x, LimitsOfMovementY, transform.position.z); }
    if (transform.position.y<= NegLimitsOfMovementY){transform.position = new Vector3(transform.position.x, NegLimitsOfMovementY, transform.position.z);}
}
    
    void UpdateViewOfEnemy()
    {if (LastPositionRegistred.x <= -1) {IsLookingAtTheLeft=true;}else{IsLookingAtTheLeft=false;}
     if (LastPositionRegistred.x >= 1) {IsLookingAtTheRight=true;}else{IsLookingAtTheRight=false;}
     if (LastPositionRegistred.x == 0) {IsLookingAtTheRight=false;IsLookingAtTheLeft=false;}}

    private void OnTriggerEnter2D(Collider2D collision)
    {if (collision.gameObject.name == "Rambird") { this.enabled = false;}}

    private void OnCollisionEnter2D(Collision2D collision)
{if(collision.gameObject.CompareTag("Player")){collision.gameObject.GetComponent<HealthManager>().CurrentHealth-=DamageValue;}
if(collision.gameObject.CompareTag("Player")&&collision.gameObject.GetComponent<HealthManager>().CurrentArmor>0){collision.gameObject.GetComponent<HealthManager>().CurrentArmor-=DamageValue;}
}

    private void Start()
    {EnemyRb=GetComponent<Rigidbody2D>();}

    private void FixedUpdate()
    {MovementConf();}

    private void Update()
    {UpdateViewOfEnemy();DontCrossTheLimits();}

    private void LateUpdate()
    {}
}
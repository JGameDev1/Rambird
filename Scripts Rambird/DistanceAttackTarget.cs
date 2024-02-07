
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(ObjectPoolConf))]

public class DistanceAttackTarget : MonoBehaviour
{   private ObjectPoolConf _ObjectPoolConf;
    public string TagToAttack;
    [Range(0, 100)]
    public float RepulsionForce,MyProjectileSpeed,OnShotCounter,ReinitializeCronometreIn;private float ShotCounter, LimitsOfMovementX, NegLimitsOfMovementX, LimitsOfMovementY, NegLimitsOfMovementY;
    public Vector3 BulletOrigin,LastPositionRegistred;
    public bool Reload,IsLookingAtTheLeft,IsLookingAtTheRight,GoodShooter;
    public EnemyPatrolMovement _EnemyPatrolMovement;
    public RambirdController _RambirdController;
    public Rigidbody2D _Rigidbody;
    private BoxCollider2D AreaOfView;

    private void OnTriggerEnter2D(Collider2D Other)
{if(Other.gameObject.CompareTag(TagToAttack)){_EnemyPatrolMovement.enabled=false;}}

    private void OnTriggerStay2D(Collider2D Other)
{if(Other.gameObject.CompareTag(TagToAttack)&&LastPositionRegistred.x>0&&Reload==false&&_RambirdController.LastMovement.x<=0&&!GoodShooter)
            {_Rigidbody.velocity = Vector2.zero;
            GameObject Bullet=_ObjectPoolConf.RequestProjectile();
            Bullet.transform.position=transform.position+BulletOrigin;
            Rigidbody2D RightProjectileRB=Bullet.GetComponent<Rigidbody2D>();
            RightProjectileRB.velocity=Vector2.right*MyProjectileSpeed;Reload=true;_EnemyPatrolMovement.enabled = false;}
    if(Other.gameObject.CompareTag(TagToAttack) &&LastPositionRegistred.x<0&&Reload==false&&_RambirdController.LastMovement.x>=0&&!GoodShooter)
        {   _Rigidbody.velocity=Vector2.zero;
            GameObject Bullet=_ObjectPoolConf.RequestProjectile();
            Bullet.transform.position=transform.position-BulletOrigin;
            Rigidbody2D LefttProjectileRB=Bullet.GetComponent<Rigidbody2D>();
            LefttProjectileRB.velocity=Vector2.left*MyProjectileSpeed;Reload=true; _EnemyPatrolMovement.enabled = false;}
    if (Other.gameObject.CompareTag(TagToAttack) && LastPositionRegistred.x>=0&&Reload==false&&_RambirdController.LastMovement.x<=0&&GoodShooter)
        {
            _Rigidbody.velocity = Vector2.zero;
            GameObject HunterBullet=_ObjectPoolConf.RequestProjectile();
            HunterBullet.transform.position=(transform.position+(Other.transform.position-transform.position).normalized);
            Rigidbody2D HunterBulletRb=HunterBullet.GetComponent<Rigidbody2D>();
            HunterBulletRb.velocity=(Other.transform.position-transform.position).normalized*MyProjectileSpeed;Reload=true;_EnemyPatrolMovement.enabled=false;}
    if (Other.gameObject.CompareTag(TagToAttack) &&LastPositionRegistred.x<=0&&Reload==false&&_RambirdController.LastMovement.x>=0&&GoodShooter)
        {
            _Rigidbody.velocity = Vector2.zero;
            GameObject HunterBullet=_ObjectPoolConf.RequestProjectile();
            HunterBullet.transform.position= (transform.position + (Other.transform.position - transform.position).normalized);
            Rigidbody2D HunterBulletRb=HunterBullet.GetComponent<Rigidbody2D>();
            HunterBulletRb.velocity=(Other.transform.position-transform.position).normalized*MyProjectileSpeed;Reload=true;_EnemyPatrolMovement.enabled=false;}
    }

    void DontCrossTheLimits()
    {
        if (transform.position.x >= LimitsOfMovementX) { transform.position = new Vector3(LimitsOfMovementX, transform.position.y, transform.position.z); }
        if (transform.position.x <= NegLimitsOfMovementX) { transform.position = new Vector3(NegLimitsOfMovementX, transform.position.y, transform.position.z); }
        if (transform.position.y >= LimitsOfMovementY) { transform.position = new Vector3(transform.position.x, LimitsOfMovementY, transform.position.z); }
        if (transform.position.y <= NegLimitsOfMovementY) { transform.position = new Vector3(transform.position.x, NegLimitsOfMovementY, transform.position.z); }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {_EnemyPatrolMovement.enabled=true;Reload=false;ShotCounter=OnShotCounter;}

    void UpdateViewOfTheEnemy()
    {   LastPositionRegistred =_EnemyPatrolMovement.LastPositionRegistred;
        if (LastPositionRegistred.x<0){IsLookingAtTheLeft=true;}else{IsLookingAtTheLeft=false;}
        if (LastPositionRegistred.x>0){IsLookingAtTheRight=true;}else{IsLookingAtTheRight=false;}
        if (LastPositionRegistred.x==0){IsLookingAtTheRight=false;IsLookingAtTheLeft=false;}}
    private void Start()
    {_EnemyPatrolMovement=GetComponent<EnemyPatrolMovement>();
     _ObjectPoolConf=GetComponent<ObjectPoolConf>();
     _Rigidbody = GetComponent<Rigidbody2D>();
    _RambirdController = FindObjectOfType<RambirdController>();
     ShotCounter=OnShotCounter;
     AreaOfView = GetComponent<BoxCollider2D>(); AreaOfView.isTrigger=true;}
    private void Update()
{
        LimitsOfMovementX = _EnemyPatrolMovement.LimitsOfMovementX;
        NegLimitsOfMovementX = _EnemyPatrolMovement.NegLimitsOfMovementX;
        LimitsOfMovementY = _EnemyPatrolMovement.LimitsOfMovementY;
        NegLimitsOfMovementY = _EnemyPatrolMovement.NegLimitsOfMovementY;
        UpdateViewOfTheEnemy();if(Reload==true){ShotCounter-=Time.deltaTime;
if(ShotCounter<ReinitializeCronometreIn){Reload=false;ShotCounter=OnShotCounter;}}}}
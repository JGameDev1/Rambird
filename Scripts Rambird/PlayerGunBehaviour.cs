using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectPoolConf))]
public class PlayerGunBehaviour : MonoBehaviour
{   public GameObject Player;
    public ObjectPoolConf _ObjectPoolConf;
    public RambirdController _RambirdController;
    public float RepulsionForce,MyProjectileSpeed,OnShotCounter,ShotCounter;
    public Vector3 BulletOrigin;
    public bool Reload;

    private void ProjectileInstantiation()
    {if(Input.GetAxisRaw("Fire1")>0.3&&_RambirdController.RightWeapon.activeSelf)
    {GameObject GattlingBullet =_ObjectPoolConf.RequestProjectile();
    Vector3 RotationToRight = new Vector3(0,0,0);
    GattlingBullet.transform.position=transform.position+BulletOrigin;
    Rigidbody2D RightProjectileRB=GattlingBullet.GetComponent<Rigidbody2D>();
    RightProjectileRB.velocity = Vector2.right*MyProjectileSpeed;Reload=true;}
    if(Input.GetAxisRaw("Fire1")>0.3&&_RambirdController.LeftWeapon.activeSelf)
    {GameObject GattlingBullet=_ObjectPoolConf.RequestProjectile();
    Vector3 RotationToLeft=new Vector3(0,180,0);
    GattlingBullet.transform.position=transform.position-BulletOrigin; GattlingBullet.transform.Rotate(RotationToLeft);
    Rigidbody2D LefttProjectileRB = GattlingBullet.GetComponent<Rigidbody2D>();
    LefttProjectileRB.velocity=Vector2.left*MyProjectileSpeed;Reload=true;}}

    private void Start()
    {ShotCounter=OnShotCounter;}

    private void Update()
    {if(Reload==false){ProjectileInstantiation();}
    else if(Reload==true){ShotCounter-=Time.deltaTime;
    if(ShotCounter<0){Reload=false;ShotCounter=OnShotCounter;}}}
}

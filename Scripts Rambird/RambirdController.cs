using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(HealthManager))]
[RequireComponent(typeof(Animator))]
public class RambirdController : MonoBehaviour
{   private Rigidbody2D PlayerBody;
    [Range(0,1000)]
    public float MovementSpeed,JumpForce,JumpFromGround;
    private Animator _Animator;
    public LayerMask Ground;
    public Vector3 LastMovement;
    public GameObject RightWeapon,LeftWeapon;
    public PlayerUI _PlayerUI;
    public HealthManager _HealthManager;
    public bool NewSceneTravel; private bool Quieto, Corre, ShootToLeft, ShootToRight,PunchToLeft,PunchToRight;

    void RambirdMovement()
{float HorizontalInput = Input.GetAxisRaw("Horizontal") * Time.fixedDeltaTime * MovementSpeed;
if(Input.GetAxisRaw("Horizontal")>0){LastMovement=new Vector3(1,LastMovement.y,LastMovement.z);}else if(Input.GetAxisRaw("Horizontal")<0){LastMovement=new Vector3(-1,LastMovement.y,LastMovement.z);}
PlayerBody.velocity=new Vector2(PlayerBody.velocity.x+HorizontalInput,PlayerBody.velocity.y);Jump();}

void Jump()
{float VerticalInput=Input.GetAxisRaw("Jump")*Time.fixedDeltaTime*JumpForce;if (Input.GetAxisRaw("Jump")>=0.2){LastMovement=new Vector3(LastMovement.x,1,LastMovement.z);}
if (Physics2D.Raycast(transform.position,Vector2.down,JumpFromGround,Ground.value))
{PlayerBody.AddForce(Vector2.up*VerticalInput,ForceMode2D.Impulse);}}

    public void WeaponActivation()
{if(LastMovement.x>0f&&Input.GetAxisRaw("Fire1")>0.3){ShootToRight=true;}else{ShootToRight=false;}
if(LastMovement.x<0f&&Input.GetAxisRaw("Fire1")>0.3){ShootToLeft=true;}else{ShootToLeft=false;}
if(LastMovement.x>0f&&Input.GetAxisRaw("Fire2")>0.3){PunchToRight=true;}else{PunchToRight=false;}
if(LastMovement.x<0f&&Input.GetAxisRaw("Fire2")>0.3){PunchToLeft=true;}else{PunchToLeft=false;}
    }
    
    void Awake()
{ PlayerBody = GetComponent<Rigidbody2D>();}

    private void OnTriggerEnter2D(Collider2D Other)
    {if (Other.gameObject.CompareTag("CollectableItem")&&Other.gameObject.name == "UnPunto") { _PlayerUI.NºItemsCollected+=1;Other.gameObject.SetActive(false);}
     if (Other.gameObject.CompareTag("CollectableItem")&&Other.gameObject.name == "CincoPuntos") { _PlayerUI.NºItemsCollected+= 5;Other.gameObject.SetActive(false);}
     if (Other.gameObject.CompareTag("CollectableItem")&&Other.gameObject.name == "DiezPuntos") { _PlayerUI.NºItemsCollected+=10;Other.gameObject.SetActive(false);}
     if (Other.gameObject.CompareTag("PowerUp") && Other.gameObject.name == "Pluma Roja") { _PlayerUI.NºItemsCollected += 1;Other.gameObject.SetActive(false);_PlayerUI.Pulgon.enabled=true;}
     if (Other.gameObject.CompareTag("PowerUp") && Other.gameObject.name == "Pluma Gris") { _PlayerUI.NºItemsCollected += 1;_HealthManager.CurrentArmor=_HealthManager.Armor;Other.gameObject.SetActive(false);}
     if (Other.gameObject.CompareTag("PowerUp") && Other.gameObject.name == "Pluma Azul") { _PlayerUI.NºItemsCollected += 1;Other.gameObject.SetActive(false);_PlayerUI.Smash.enabled=true;}
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {LastMovement=new Vector3(LastMovement.x,0,LastMovement.z);}

    private void Start()
    {_HealthManager=GetComponent<HealthManager>();
     _Animator= GetComponent<Animator>();
    }

    private void Update()
    {if (Input.GetAxisRaw("Horizontal")==0&& Input.GetAxisRaw("Jump") == 0){ Quieto = true; }else { Quieto = false; }
    WeaponActivation();if(NewSceneTravel){ transform.position = Vector3.zero;}
    IddleAnimations();RunAnimation();UseWeapon();JumpAnimation();UseCrossbow();
   }

    void FixedUpdate()
    {RambirdMovement();}

    void IddleAnimations() {_Animator.SetBool("Iddle",Quieto);_Animator.SetFloat("LastHorizontal",LastMovement.x);}
    void RunAnimation() {_Animator.SetFloat("HorizontalInputValue",Input.GetAxisRaw("Horizontal"));}
    void JumpAnimation() { _Animator.SetFloat("LastVertical",LastMovement.y);}
    void UseWeapon(){_Animator.SetBool("ShootToRight",ShootToRight);_Animator.SetBool("ShootToLeft",ShootToLeft);_Animator.SetBool("PunchToRight",PunchToRight);_Animator.SetBool("PunchToLeft",PunchToLeft);}

    void UseCrossbow() {_Animator.SetBool("ShootToRight",ShootToRight);_Animator.SetBool("ShootToLeft",ShootToLeft);}
}

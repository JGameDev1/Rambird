using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class ProjectileBombBehaviour : MonoBehaviour
{   private Rigidbody2D PhysicalProjectile;
    [Range(0, 10)]
    public int ProjectileSpeed,RepulsionForce;
    private GameObject Player;

    private void OnCollisionEnter2D(Collision2D collision)
    {if (collision.gameObject.tag == "Enemy")
    {collision.rigidbody.AddForce(new Vector2(Player.transform.position.x-collision.transform.position.x,0)*RepulsionForce);}gameObject.SetActive(false);}

    private void OnEnable()
    {Player = GameObject.Find("Rambird");
    PhysicalProjectile = GetComponent<Rigidbody2D>();
    float HorizontalInput = Input.GetAxisRaw("Horizontal"),VerticalInput=Input.GetAxisRaw("Vertical");
    Vector2 LastMovement = new Vector2(HorizontalInput, 0);
    PhysicalProjectile.velocity = LastMovement*ProjectileSpeed;}}
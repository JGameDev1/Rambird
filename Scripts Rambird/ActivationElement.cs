using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationElement : MonoBehaviour
{ public GameObject GameElement;
 public CapsuleCollider2D ElevatorCollider;

    private void OnTriggerEnter2D(Collider2D collision)
    {if (collision.gameObject.CompareTag("Player")) {GameElement.SetActive(true);ElevatorCollider.enabled = true; }}
}

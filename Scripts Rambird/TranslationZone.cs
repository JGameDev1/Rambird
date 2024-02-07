using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
public class TranslationZone : MonoBehaviour
{   public bool ToLeft, ToRight, ToUp, ToDown;
    public float TranslationForce;
    private CapsuleCollider2D TranslationArea;
    RambirdController _RambirdController;
    public GameObject BareerOfZone;
    private void Start()
    {TranslationArea=GetComponent<CapsuleCollider2D>();TranslationArea.isTrigger = true;}


    private void OnTriggerStay2D(Collider2D Other)
    {if (Other.gameObject.tag == "Player")
        {
            BareerOfZone.SetActive(false);
            if (ToLeft) { Other.transform.Translate(Vector2.left * TranslationForce * Time.deltaTime); }
            if (ToRight) { Other.transform.Translate(Vector2.right * TranslationForce * Time.deltaTime); }
            if (ToUp) { Other.transform.Translate(Vector2.up * TranslationForce * Time.deltaTime); }
            if (ToDown) { Other.transform.Translate(Vector2.down * TranslationForce * Time.deltaTime); }
        }
    }

private void OnTriggerExit2D(Collider2D collision)
    {if (collision.gameObject.CompareTag("Player")) {TranslationArea.enabled = false;BareerOfZone.SetActive(true);}
    }
}

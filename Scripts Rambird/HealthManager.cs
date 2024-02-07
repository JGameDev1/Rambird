using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
[RequireComponent(typeof(SpriteRenderer))]
public class HealthManager : MonoBehaviour
{   [Range(0, 100)]
    public int HealthValue,CurrentHealth,CurrentArmor,Armor,LowHealthItemValue,MediumHealthItemValue,TotalHealthItemValue;
    public bool Player,Enemy,Boss,Invulnerability;
    private SpriteRenderer _SpriteRenderer;
    public PlayerUI _PlayerUI;
    [Range(0, 100)] 
    public float OnPowerDeathCounter;private float DeathCounter;


    private void Start()
    {   CurrentHealth = HealthValue;
        _SpriteRenderer = GetComponent<SpriteRenderer>();
        _PlayerUI = FindObjectOfType<PlayerUI>();
        MediumHealthItemValue = HealthValue/2;
        LowHealthItemValue = 1;
        CurrentArmor = 0;}

    private void OnTriggerEnter2D(Collider2D Other)
{if(Other.gameObject.name=="Pildora"&&Player||Other.gameObject.name== "Pildora" && Boss){CurrentHealth+=LowHealthItemValue;}
if(Other.gameObject.name=="Frasco"&&Player||Other.gameObject.name== "Frasco" && Boss){CurrentHealth+=MediumHealthItemValue;}
if(Other.gameObject.name=="Botiquin"&&Player||Other.gameObject.name== "Botiquin" && Boss){CurrentHealth+=TotalHealthItemValue;}
if(Other.gameObject.name=="Pluma Dorada"&&Player||Other.gameObject.name=="Pluma Dorada"&&Boss){Invulnerability=true;}
if(Other.gameObject.name=="Pluma Gris"&&Player&& CurrentHealth == HealthValue){CurrentArmor=Armor;}}

private void Update()
{TotalHealthItemValue = HealthValue - CurrentHealth;
if (CurrentHealth>HealthValue){CurrentHealth=HealthValue;}
if (CurrentHealth <= 0 && Player) {_SpriteRenderer.enabled=false;GameManager._SharedInstanceGameManager.GameOver();}
if (CurrentArmor > 0 && Player) {CurrentHealth=HealthValue;}
if (CurrentArmor <= 0 && Player) {CurrentArmor=0;}
if (CurrentHealth <= 0 && Enemy) {gameObject.SetActive(false);}
if(_PlayerUI.NºItemsCollected>=100){CurrentHealth++;}}
}

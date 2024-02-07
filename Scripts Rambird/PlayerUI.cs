using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{ public TextMeshProUGUI NumberOfItems, Cronometre; public int NºItemsCollected;
    [Range(0, 100)]
    public int IndexOfLife, IndexOfArmor;
    [Range(0, 100)]
    public float OnCronometre;
    public List<GameObject> HealthRepresentation; public List<GameObject> ArmorRepresentations;
    public Image ItemColectedRepresentation,Watch,Pulgon,Smash;
    public HealthManager _PlayerHealthManager;
    public GameObject HealthOwner;

    private void Start()
    { Watch.enabled = false; Cronometre.enabled = false;Pulgon.enabled = false;Smash.enabled = false;
        NºItemsCollected = 0; OnCronometre = 30;
        _PlayerHealthManager = HealthOwner.GetComponent<HealthManager>();
        IndexOfLife = _PlayerHealthManager.HealthValue;
        IndexOfArmor = _PlayerHealthManager.Armor;
        InitialLife();InitialArmor();
    }

void InitialLife(){for(int i=0;i<HealthRepresentation.Count;i++){HealthRepresentation[i].GetComponent<Image>().color=new Color(1,1,1,1);}}
void InitialArmor() { for (int i = 0; i < ArmorRepresentations.Count; i++) { ArmorRepresentations[i].GetComponent<Image>().color = new Color(1, 1, 1, 0); } }

    void LifeVisualization()
    {   if (_PlayerHealthManager.CurrentHealth < IndexOfLife)
        {IndexOfLife = _PlayerHealthManager.CurrentHealth;
         foreach (var Corazones in HealthRepresentation) { HealthRepresentation[IndexOfLife].GetComponent<Image>().color = new Color(1, 1, 1, 0);}
        }
        if (_PlayerHealthManager.CurrentHealth > IndexOfLife)
        {IndexOfLife = _PlayerHealthManager.CurrentHealth;
        for (int i = 0; i < HealthRepresentation.Count; i++) {HealthRepresentation[i].GetComponent<Image>().color = new Color(1, 1, 1, 1);}
        }
    }
 

void ArmorVisualization()
    {   if (_PlayerHealthManager.CurrentArmor < IndexOfArmor)
        {IndexOfArmor = _PlayerHealthManager.CurrentArmor;
        foreach (var Protecciones in ArmorRepresentations){ArmorRepresentations[IndexOfArmor].GetComponent<Image>().color=new Color(1,1,1,0);}}
        if(_PlayerHealthManager.CurrentArmor > IndexOfArmor)
        {IndexOfArmor=_PlayerHealthManager.CurrentArmor;
        for (int i = 0; i<ArmorRepresentations.Count; i++) {ArmorRepresentations[i].GetComponent<Image>().color=new Color(1,1,1,1);}
        }
    }

    void ScoreItems() {NumberOfItems.text=NºItemsCollected.ToString();}

    private void Update()
    {
     ScoreItems();
     Cronometre.text=OnCronometre.ToString();
    LifeVisualization();ArmorVisualization();
    }
}

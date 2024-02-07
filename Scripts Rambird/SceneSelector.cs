using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelector : MonoBehaviour
{
    public string SceneName;
    private GameObject Rambird;

    private void OnTriggerStay2D(Collider2D character)
    {
        if (character.tag == "Player" && Input.GetAxisRaw("Submit") > 0.1)
        {
            SceneManager.LoadScene(SceneName); Rambird.GetComponent<RambirdController>().NewSceneTravel = true; Rambird.GetComponent<RambirdController>().gameObject.transform.position = Vector3.zero;
            GameManager._SharedInstanceGameManager.FinishTheLevel();
        }
        else { Rambird.GetComponent<RambirdController>().NewSceneTravel = false; GameManager._SharedInstanceGameManager.RunTheGame();}
    }
    private void Start()
    {Rambird = GameObject.Find("Rambird"); }
}
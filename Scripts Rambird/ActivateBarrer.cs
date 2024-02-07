using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateBarrer : MonoBehaviour
{
    public GameObject PhysicalBareer;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")){ PhysicalBareer.SetActive(true); }
    }
}

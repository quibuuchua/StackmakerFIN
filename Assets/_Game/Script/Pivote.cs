using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pivote : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject brick;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            {
            other.GetComponent<Player>().AddBrick();
            
          brick.SetActive(false);

        }
    }
}

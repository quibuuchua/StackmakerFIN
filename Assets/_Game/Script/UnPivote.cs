using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnPivote : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject brickReset;

    private void Start()
    {
        OnInit();
    }
    public void OnInit()
    {
        brickReset.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Player>().DelBrick();
           brickReset.SetActive(true);
        }
    }
}

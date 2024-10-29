using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AddBrick : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject brick;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")){
            other.GetComponent<Player>().AddBrick();
            Destroy(brick);
        }
    }
}

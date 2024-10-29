using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // //Start is called before the first frame update
    //[SerializeField] GameObject camera;
    // [SerializeField]public Vector3 offset;
    // Player player;
    // [SerializeField] float speedCam = 2f;
    // private Vector3 start;
    // void Start()
    // {
    //     start = camera.transform.localPosition;
    //     if (player == null)
    //     {
    //         player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    //     }

    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     transform.position = Vector3.Lerp(transform.position, player.transform.position, speedCam * Time.deltaTime);
    //     camera.transform.localPosition = start - camera.transform.forward * player.brickLeft * 0.3f;
    // }
    public Transform target;
    public Vector3 offset;
   public Player player;
    public float speed = 10;
    void Start()
    {
        target = FindObjectOfType<Player>().transform;
    }

    // update is called once per frame
    void FixedUpdate()
    {
        //offset.y = 20f;
        //Debug.Log(player.);
        transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.fixedDeltaTime * speed);
    }
}

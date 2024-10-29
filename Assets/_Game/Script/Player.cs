using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

using UnityEngine;

public class Player : MonoBehaviour
{
    //moving
    private Vector2 beginPoint;
    private Vector2 endPoint;

    [SerializeField] Rigidbody rb;
    private string currentAnim;
    [SerializeField] Animator anim;

    // flag check 
    private bool isStop;
    private bool isMoving;
    private bool isControl;
    //[SerializeField] private ControlPlayer controlPlayer;
    //Physic transfrom
    [SerializeField] Transform physicTrans;
    
    //Target
    private Vector3 targetPos;
    //ray cast hit
   
    //layer wall
    [SerializeField] LayerMask wallLayer;
    //Front check
    [SerializeField] private Transform frontHit;
    [SerializeField] private float speed;
    private RaycastHit hitWall;
    //Collection brick
    [SerializeField] List<GameObject> brickCollections;
    //brick count 
    private int brickNumber;
    public int brickLeft =>brickCollections.Count;
    //brick add prefabs
    [SerializeField] GameObject brickAdd;
    //brick height
    private float brickHeight;
    private float brickAddHeight=0.4f;
    public enum Direct
    {
        None = 0,
        Left = 1,
        Right = 2,
        Forward = 3,
        Back = 4,
    }
    Direct playerDirection;
    

    private void Start()
    {
        OnInit();
    }
    public void OnInit()

    {
        isControl = false;
        playerDirection = Direct.None;
        brickHeight = -0.4f;
        Invoke(nameof(Waiting), 0.5f);
        brickNumber = 0;


    }
    // Update is called once per frame
    void Update()
    {
        //if (isStop)
        //{
        //    return;
        //}
        //Debug.Log(playerDirection.ToString());
        physicTrans.forward = Vector3.forward;
        if(GameManager.Instance.isState(GameState.PlayingMode))
    SetDirection(ref playerDirection);
        //if (WallCheck())
           // Debug.Log("rtaycaste");
        Move();
        //if(brickLeft==0 )
        //{
        //   GameManager.Instance.ChangeState(GameState.Lose);
        //    UiManager.Instance.LoseOpen();
        //}

    }
    //Add brick 
    public void AddBrick()
    {
        // anim.SetFloat("renwu", 0);
        ChangeAnim("addbrick");
        brickNumber++;
        GameObject tempoBrick = Instantiate(brickAdd,transform);
        tempoBrick.transform.localPosition = new Vector3(0, brickHeight, 0);
        brickCollections.Add(tempoBrick);
       brickHeight += brickAddHeight;
        physicTrans.localPosition=new Vector3(0,brickHeight, 0);

    }
    //Del brick
    public void DelBrick()
    {
        if(brickNumber>0)
        {
            Destroy(brickCollections[brickCollections.Count-1]);
            brickCollections.Remove(brickCollections[brickCollections.Count - 1]);

        }
        brickHeight-=brickAddHeight;
        physicTrans.localPosition=new Vector3(0,brickHeight,0);
    }
    //toi uu viec xoa va them gach, set pos cho player 
    //ray cast 
    private bool WallCheck()
    {
       Debug.DrawLine(frontHit.position, frontHit.position + Vector3.down * 1.1f, Color.red);
     Physics.Raycast(frontHit.position,Vector3.down,out hitWall,20f,wallLayer);
        
        return hitWall.collider!=null;  
    }
    //moving
    private void Move()
    {
        if( WallCheck())
        {
            //Debug.Log("raycast");
            targetPos = new Vector3(hitWall.collider.transform.position.x, transform.position.y, hitWall.collider.transform.position.z);
            if(playerDirection!=Direct.None)
            {
                isMoving = true;
            }
        }
        else
        {
            if(Vector3.Distance(transform.position,targetPos)<0.01f)
            {
                isMoving = false;
            }
        }
        if(!isMoving)
        {
            switch(playerDirection)
            {
                case Direct.Forward:
                    transform.forward = Vector3.forward;
                    break;
                case Direct.Back:
                    transform.forward = -Vector3.forward;
                    break;
                case Direct.Right:
                    transform.forward = Vector3.right; 
                    break;
                    case Direct.Left:
                    transform.forward=-Vector3.right; 
                    break;
                case Direct.None:
                    break;

            }
        }
        else
        {
            playerDirection=Direct.None;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * speed);
        }
    }
    public void WinAndClear()
    {
        ChangeAnim("win");
        isStop = true;
        for(int i = brickCollections.Count - 1;i>= 0; i--) {
            Destroy(brickCollections[i]);
            brickCollections.Remove(brickCollections[i]);
        }
        physicTrans.localPosition = new Vector3(0, 0.2f, 0);
    }
   public void Waiting()
    {
        isStop=false;
        isMoving=false;
    }
    //changeAnim
    protected void ChangeAnim(string animName)
    {
        if (currentAnim != animName)
        {
            anim.ResetTrigger(animName);
            currentAnim = animName;
            anim.SetTrigger(currentAnim);

        }
    }

    //find mouse direction
    public void SetDirection( ref Direct dir)
    {
        if (Input.GetMouseButtonDown(0) && !isControl)
        {
            //Debug.Log("down");
            isControl=true;
            beginPoint = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0) && isControl)
        {
            isControl = false;
            endPoint = Input.mousePosition;
            Vector2 tmpVector = endPoint - beginPoint;
            float xVec = Mathf.Abs(tmpVector.x);
            float yVec = Mathf.Abs(tmpVector.y);
            if (xVec > yVec)
            {
                if (tmpVector.x > 0)
                {
                    dir = Direct.Right;
                    Debug.Log("right");
                }

                else
                {
                    dir = Direct.Left;
                    Debug.Log("left");
                }
            }


            else
            {
                if (tmpVector.y > 0)
                {
                    dir = Direct.Forward;
                }
                else
                {
                    dir = Direct.Back;
                }
            }
        }
    }
}

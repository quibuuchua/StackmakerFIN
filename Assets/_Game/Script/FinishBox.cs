using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishBox : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject chestOpen;
    [SerializeField] GameObject chestClose;
    [SerializeField] GameObject playerBrick;
    [SerializeField] ParticleSystem ps1;
    [SerializeField] ParticleSystem ps2;
    void Start()
    {
        OnInit();
      //Instantiate(winFX);
    }


    private void OnInit()
    {
        chestOpen.SetActive(false);
        playerBrick.SetActive(true);
//vfx.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            chestOpen.SetActive(true);
            chestClose.SetActive(false);
           playerBrick.SetActive(false);   
            other.GetComponent<Player>().WinAndClear();
            ps1.Play();
            ps2.Play();
            //UiManager.Instance.VictoryOpen();
            //GameManager.Instance.ChangeState(GameState.Victory);
            LevelManager.Instance.OnWin();
            //ParticleSystem.PlaybackState playbackState
        }
    }
    // Update is called once per frame

}


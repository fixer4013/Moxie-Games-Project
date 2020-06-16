using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStates : MonoBehaviour
{
    public static int state = 0;

    public GameObject enemy;
    public GameObject doorKnocking;

    //Part 1
    public DoorMechanics DoorA;
    public DoorMechanics DoorB;
    public AudioSource DoorAAudioTrigger;
    public Camera CamDoorA;
    public Light LightEventA;
    public Animator EventADoorAnimator;

    //Part 2
    public DoorMechanics DoorG;
    public DoorMechanics DoorE;
    public AudioSource audioDoorSlam;
    public ParticleSystem doorSlamParticle;
    public Animator DoorSlamAnimator;
    public AudioSource DoorCKnockingGuide;
    public AudioSource DoorCAudioWhenDoorOpens;

    //Part 3
    public DoorMechanics DoorD;
    public DoorMechanics DoorF;
    public AudioSource DoorLockingSound;
    public Flickering HallwaLight1;
    public Flickering HallwaLight2;
    public AudioSource EnemyFiddlingSound;

    //Part4
    public AudioSource doorKnockingFetRoom;
    public AudioSource doorFTrigger;
    public Animator EndOfDemo;

    void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            GameState1();
        }

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(state);
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            switch (state)
            {
                case 0:
                    if (DoorAAudioTrigger.isPlaying)
                    {
                        state += 1; //becomes 1
                        Invoke("GameState1_1", 1);
                    }
                    break;
                case 1:
                    if (CamDoorA.isActiveAndEnabled)
                    {
                        state += 1; //becomes 2
                        StartCoroutine(GameState1_2());
                    }
                    break;
                case 2:
                    if (LightEventA.enabled == true)
                    {
                        enemy.transform.GetChild(0).GetChild(0).GetComponent<SkinnedMeshRenderer>().material.color = new Color(0.3f, 0.3f, 0.3f, 1);
                        enemy.transform.GetChild(0).GetChild(1).GetComponent<SkinnedMeshRenderer>().material.color = new Color(0.3f, 0.3f, 0.3f, 1);
                        enemy.transform.GetChild(0).GetChild(2).GetComponent<SkinnedMeshRenderer>().material.color = new Color(0.3f, 0.3f, 0.3f, 1);
                    }
                    else
                    {
                        enemy.transform.GetChild(0).GetChild(0).GetComponent<SkinnedMeshRenderer>().material.color = Color.black;
                        enemy.transform.GetChild(0).GetChild(1).GetComponent<SkinnedMeshRenderer>().material.color = Color.black;
                        enemy.transform.GetChild(0).GetChild(2).GetComponent<SkinnedMeshRenderer>().material.color = Color.black;
                    }
                    break;
                case 3:
                    state += 1; // becomes 4
                    GameState2();
                    break;
                case 5:
                    if (DoorCAudioWhenDoorOpens.isPlaying)
                    {
                        DoorCKnockingGuide.gameObject.SetActive(false);
                        state += 1; //becomes 6
                    }
                    break;
                case 9:
                    if (doorFTrigger.isPlaying)
                    {
                        EndOfDemo.Play("EndOfDemo");
                        state += 1; //becomes 10
                    }
                    break;
                default:
                    break;
            }
        }

    }

    void GameState1()
    {
        DoorA.locked = true;
        DoorB.locked = true;
    }

    void GameState1_1()
    {
        DoorA.peekable = true;
    }

    IEnumerator GameState1_2()
    {
        LightEventA.intensity = 3;
        LightEventA.enabled = false;
        enemy.GetComponent<Animator>().Play("EnemyEvent1");
        yield return new WaitForSeconds(9);
        EventADoorAnimator.Play("OpenDoor");
        LightEventA.enabled = true;
        yield return new WaitForSeconds(0.1f);
        LightEventA.enabled = false;
        yield return new WaitForSeconds(3.9f);
        EventADoorAnimator.Play("CloseDoor");
        yield return new WaitForSeconds(4);
        enemy.transform.GetChild(0).GetChild(0).GetComponent<SkinnedMeshRenderer>().material.color = Color.white;
        enemy.transform.GetChild(0).GetChild(1).GetComponent<SkinnedMeshRenderer>().material.color = Color.white;
        enemy.transform.GetChild(0).GetChild(2).GetComponent<SkinnedMeshRenderer>().material.color = Color.white;
        enemy.SetActive(false);
        DoorB.locked = false;
        LightEventA.intensity = 5;
        LightEventA.GetComponent<Flickering>().enabled = false;
        LightEventA.enabled = true;
        doorKnocking.transform.position = DoorB.transform.position;
        doorKnocking.GetComponent<AudioSource>().Play();

        state += 1; //becomes 3
    }

    void GameState2()
    {
        DoorG.locked = true;
        DoorE.locked = true;
        DoorSlamAnimator.Play("EventDoorSlam");
        DoorSlamAnimator.speed = 0;
    }
    
    public IEnumerator GameState2_1() //4
    {
        DoorSlamAnimator.speed = 1;
        audioDoorSlam.Play();
        doorSlamParticle.Play();
        state += 1; //becomes 5
        yield return 0;
    }

    public void GameState2_2() //5
    {
        DoorCKnockingGuide.Play();
        DoorCKnockingGuide.GetComponent<BoxCollider>().enabled = false;
        state += 1; //becomes 6
    }

    public void GameState3() //6
    {
        StartCoroutine(GameState3_1());
    }

    public IEnumerator GameState3_1() //6
    {
        DoorD.locked = true;
        DoorE.locked = true;
        DoorF.locked = true;
        StartCoroutine(DoorD.DoorCloseAnimation());
        yield return new WaitForSeconds(0.7f);
        DoorLockingSound.gameObject.transform.position = DoorF.gameObject.transform.position;
        DoorLockingSound.Play();
        yield return new WaitForSeconds(0.7f);
        DoorLockingSound.gameObject.transform.position = DoorE.gameObject.transform.position;
        DoorLockingSound.Play();
        yield return new WaitForSeconds(0.7f);
        DoorLockingSound.gameObject.transform.position = DoorD.gameObject.transform.position;
        DoorLockingSound.Play();

        DoorE.peekable = true;
        yield return new WaitForSeconds(2);
        EnemyFiddlingSound.Play();
        enemy.SetActive(true);
        enemy.GetComponent<Animator>().Play("EnemyEvent2");
        HallwaLight1.enabled = true;
        HallwaLight2.enabled = true;

        yield return new WaitForSeconds(8);
        DoorD.locked = false;
        DoorF.locked = false;
        HallwaLight1.enabled = false;
        HallwaLight2.enabled = false;
        HallwaLight1.GetComponent<Light>().enabled = true;
        HallwaLight2.GetComponent<Light>().enabled = true;
        doorKnocking.transform.position = DoorF.transform.position;
        doorKnocking.GetComponent<AudioSource>().Play();
        state += 1; //becomes 7
    }

    public void GameState4() //7
    {
        doorKnockingFetRoom.GetComponent<AudioSource>().Play();
        DoorF.locked = true;
        state += 1; //becomes 8
    }
}

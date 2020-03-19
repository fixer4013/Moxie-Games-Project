using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NewDoorMechanics : MonoBehaviour
{

    public GameObject player;
    public NavMeshAgent enemy;

    //DOOR OPENING AND CLOSING MECHANICS
    public Animator anim;
    public float closingDistance;
    public bool doorAnimating;
    public bool open;

    //DOOR OPENING MECHANICS ENEMY
    public bool enemyIsNear;

    //KNOCKING MECHANICS
    public AudioSource knockingAudio;

    //PEEKING AND LISTENING MECHANICS
    public DoorSide side1;
    public DoorSide side2;

    public Camera cam;

    public bool listening;
    public bool peeking;
    public float timer;
    public bool isInteracting;

    Vector3 playerPosition;
    Quaternion playerRotation;
    Quaternion cameraRotation;

    Vector3 playerInteractionPosition;
    Quaternion playerInteractionRotationListening;
    Quaternion playerInteractionRotationPeeking;
    Quaternion camInteractionRotation;

    float playerPositionSpeed;
    float playerRotationSpeedListening;
    float playerRotationSpeedPeeking;
    float camRotationSpeed;


    private void Update()
    {

        //DOOR OPENING AND CLOSING MECHANICS
        if (open && !side1.isPlayerNear && !side2.isPlayerNear && !enemyIsNear)
        {
            StartCoroutine(DoorCloseAnimation());
        }

        if (!open && !doorAnimating && enemyIsNear)
        {
            StartCoroutine(DoorOpenAnimation(0.33f, true));
        }
        enemyIsNear = false;

        //PEEKING MECHANICS
        if (peeking)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(StopPeeking());
            }
        }

        //LISTENING MECHANICS
        if (listening)
        {
            if (Input.GetMouseButtonDown(1))
            {
                StartCoroutine(StopListening());
            }
        }
    }



    //DOOR OPENING AND CLOSING MECHANICS
    public IEnumerator DoorOpenAnimation(float animSpeed, bool isEnemy)
    {
        anim.Play("DoorOpenNew1");
        var currentAnimSpeed = anim.speed;
        anim.speed = animSpeed;
        doorAnimating = true;
        if (isEnemy)
        {
            enemy.speed = 0;
        }

        yield return new WaitForSeconds(2f / animSpeed);
        open = true;
        doorAnimating = false;
        anim.speed = currentAnimSpeed;
        if (isEnemy)
        {
            enemy.speed = 3.5f;
        }
    }

    //DOOR OPENING AND CLOSING MECHANICS
    IEnumerator DoorCloseAnimation()
    {
        anim.Play("DoorCloseNew1");
        doorAnimating = true;
        open = false;
        yield return new WaitForSeconds(2f);
        doorAnimating = false;
    }  
    
    //KNOCKING MECHANICS
    public void Knocking()
    {
        if (!knockingAudio.isPlaying)
        {
            knockingAudio.Play();
        }
    }
    

    //PEEKING MECHANICS ON 1 SIDE OF THE DOOR
    public IEnumerator PeekingSide1()
    {
        isInteracting = true;

        //GET CURRENT POSITION OF PLAYER AND THE CAMERA
        playerPosition = player.transform.position;
        playerRotation = player.transform.rotation;
        cameraRotation = cam.transform.localRotation;

        //SET POSITION FOR THE PLAYER AND CAMERA TO GO TO
        playerInteractionPosition = side1.PeekingTransform.position;
        playerInteractionRotationPeeking = side1.PeekingTransform.rotation;
        camInteractionRotation = Quaternion.identity;

        //MOVING SPEEDS
        playerPositionSpeed = Mathf.Abs(Vector3.Distance(player.transform.position, playerInteractionPosition) / timer);
        playerRotationSpeedPeeking = Mathf.Abs((player.transform.rotation.eulerAngles.y - side1.PeekingTransform.eulerAngles.y) / timer);
        if (playerRotationSpeedPeeking > 180 / timer)
        {
            playerRotationSpeedPeeking = Mathf.Abs(playerRotationSpeedPeeking - (360 / timer));
        }
        if (cameraRotation.eulerAngles.x > 180)
        {
            camRotationSpeed = Mathf.Abs((cameraRotation.eulerAngles.x - 360) / timer);
        }
        else
        {
            camRotationSpeed = Mathf.Abs(cameraRotation.eulerAngles.x / timer);
        }

        //DISABLE CHARACTER AND CAMERA CONTROLS
        player.GetComponent<CharacterController>().enabled = false;
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<LookAtInteractable>().enabled = false;
        cam.GetComponent<DimensionCamera>().enabled = false;

        //MOVE THE PLAYER AND CAMERA
        for (float i = 0; i < timer; i += Time.deltaTime)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, playerInteractionPosition, playerPositionSpeed * Time.deltaTime);
            player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, playerInteractionRotationPeeking, playerRotationSpeedPeeking * Time.deltaTime);
            cam.transform.localRotation = Quaternion.RotateTowards(cam.transform.localRotation, camInteractionRotation, camRotationSpeed * Time.deltaTime);

            yield return 0;
        }

        //SWITCH CAMERAS
        cam.gameObject.SetActive(false);
        side1.cam.gameObject.SetActive(true);
        peeking = true;
    }

    //PEEKING MECHANICS ON THE OTHER SIDE OF THE DOOR
    public IEnumerator PeekingSide2()
    {
        isInteracting = true;

        //GET CURRENT POSITION OF PLAYER AND THE CAMERA
        playerPosition = player.transform.position;
        playerRotation = player.transform.rotation;
        cameraRotation = cam.transform.localRotation;

        //SET POSITION FOR THE PLAYER AND CAMERA TO GO TO
        playerInteractionPosition = side2.PeekingTransform.position;
        playerInteractionRotationPeeking = side2.PeekingTransform.rotation;
        camInteractionRotation = side2.PeekingTransform.rotation;

        //MOVING SPEEDS
        playerPositionSpeed = Mathf.Abs(Vector3.Distance(player.transform.position, playerInteractionPosition) / timer);
        playerRotationSpeedPeeking = Mathf.Abs((player.transform.rotation.eulerAngles.y - side2.PeekingTransform.eulerAngles.y) / timer);
        if (playerRotationSpeedPeeking > 180 / timer)
        {
            playerRotationSpeedPeeking = Mathf.Abs(playerRotationSpeedPeeking - (360/timer));
        }
        if (cameraRotation.eulerAngles.x > 180)
        {
            camRotationSpeed = Mathf.Abs((cameraRotation.eulerAngles.x - 360) / timer);
        }
        else
        {
            camRotationSpeed = Mathf.Abs(cameraRotation.eulerAngles.x / timer);
        }

        //DISABLE CHARACTER AND CAMERA CONTROLS
        player.GetComponent<CharacterController>().enabled = false;
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<LookAtInteractable>().enabled = false;
        cam.GetComponent<DimensionCamera>().enabled = false;

        //MOVE THE PLAYER AND CAMERA
        for (float i = 0; i < timer; i += Time.deltaTime)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, playerInteractionPosition, playerPositionSpeed * Time.deltaTime);
            player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, playerInteractionRotationPeeking, playerRotationSpeedPeeking * Time.deltaTime);
            cam.transform.localRotation = Quaternion.RotateTowards(cam.transform.localRotation, camInteractionRotation, camRotationSpeed * Time.deltaTime);

            yield return 0;
        }

        //SWITCH CAMERAS
        cam.gameObject.SetActive(false);
        side2.cam.gameObject.SetActive(true);
        peeking = true;
    }

    //PEEKING MECHANICS STOPPED
    IEnumerator StopPeeking()
    {
        //SWITCH CAMERAS
        peeking = false;
        cam.gameObject.SetActive(true);
        side1.cam.gameObject.SetActive(false);
        side2.cam.gameObject.SetActive(false);

        //MOVE PLAYERS POSITION AND CAMERA
        for (float i = 0; i < timer; i += Time.deltaTime)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, playerPosition, playerPositionSpeed * Time.deltaTime);
            player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, playerRotation, playerRotationSpeedPeeking * Time.deltaTime);
            cam.transform.localRotation = Quaternion.RotateTowards(cam.transform.localRotation, cameraRotation, camRotationSpeed * Time.deltaTime);

            yield return 0;
        }

        //ENABLE CHARACTER AND CAMERA CONTROLS
        player.GetComponent<CharacterController>().enabled = true;
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<LookAtInteractable>().enabled = true;
        cam.GetComponent<DimensionCamera>().enabled = true;

        isInteracting = false;
    }

    public IEnumerator ListeningSide1()
    {
        isInteracting = true;

        //GET CURRENT PLAYER AND CAMERA POSITION/ROTATION
        playerPosition = player.transform.position;
        playerRotation = player.transform.rotation;
        cameraRotation = cam.transform.localRotation;

        //SET PLAYER AND CAMERA POSITION/ROTATION
        playerInteractionPosition = side1.ListeningTransformLeft.position;
        playerInteractionRotationListening = side1.ListeningTransformLeft.rotation;
        camInteractionRotation = Quaternion.identity;

        //SET MOVING SPEEDS
        playerPositionSpeed = Mathf.Abs(Vector3.Distance(player.transform.position, playerInteractionPosition) / timer);
        playerRotationSpeedListening = Mathf.Abs((player.transform.rotation.eulerAngles.y - side1.ListeningTransformLeft.rotation.eulerAngles.y) / timer);
        if (playerRotationSpeedListening > 180 / timer)
        {
            playerRotationSpeedListening = Mathf.Abs(playerRotationSpeedListening - (360 / timer));
        }
        if (cameraRotation.eulerAngles.x > 180)
        {
            camRotationSpeed = Mathf.Abs((cameraRotation.eulerAngles.x - 360) / timer);
        }
        else
        {
            camRotationSpeed = Mathf.Abs(cameraRotation.eulerAngles.x / timer);
        }

        //CHANGE ROTATION(SPEED) BASED ON WHAT SIDE THE PLAYER IS LOOKING AT RELATIVE TO THE DOOR
        if (playerRotationSpeedListening > 90 / timer)
        {
            playerRotationSpeedListening = (180 / timer) - playerRotationSpeedListening;
            playerInteractionRotationListening = side1.ListeningTransformRight.rotation;
        }

        //DISABLE PLAYER AND CAMERA CONTROLS
        player.GetComponent<CharacterController>().enabled = false;
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<LookAtInteractable>().enabled = false;
        cam.GetComponent<DimensionCamera>().enabled = false;

        //PLAY AUDIO
        side1.roomAudio.Play();

        //MOVE PLAYER AND CAMERA
        for (float i = 0; i < timer; i += Time.deltaTime)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, playerInteractionPosition, playerPositionSpeed * Time.deltaTime);
            player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, playerInteractionRotationListening, playerRotationSpeedListening * Time.deltaTime);
            cam.transform.localRotation = Quaternion.RotateTowards(cam.transform.localRotation, camInteractionRotation, camRotationSpeed * Time.deltaTime);
            side1.roomAudio.volume += Time.deltaTime / timer;

            yield return 0;
        }

        listening = true;
    }

    public IEnumerator ListeningSide2()
    {
        isInteracting = true;

        //GET CURRENT PLAYER AND CAMERA POSITION/ROTATION
        playerPosition = player.transform.position;
        playerRotation = player.transform.rotation;
        cameraRotation = cam.transform.localRotation;

        //SET PLAYER AND CAMERAM POSITION/ROTATION
        playerInteractionPosition = side2.ListeningTransformLeft.position;
        playerInteractionRotationListening = side2.ListeningTransformLeft.rotation;
        camInteractionRotation = Quaternion.identity;

        //SET MOVING SPEEDS
        playerPositionSpeed = Mathf.Abs(Vector3.Distance(player.transform.position, playerInteractionPosition) / timer);
        playerRotationSpeedListening = Mathf.Abs((player.transform.rotation.eulerAngles.y - side2.ListeningTransformLeft.rotation.eulerAngles.y) / timer);
        if (playerRotationSpeedListening > 180 / timer)
        {
            playerRotationSpeedListening = Mathf.Abs(playerRotationSpeedListening - (360 / timer));
        }
        if (cameraRotation.eulerAngles.x > 180)
        {
            camRotationSpeed = Mathf.Abs((cameraRotation.eulerAngles.x - 360) / timer);
        }
        else
        {
            camRotationSpeed = Mathf.Abs(cameraRotation.eulerAngles.x / timer);
        }

        //CHANGE ROTATION(SPEED) BASED ON WHAT SIDE THE PLAYER IS LOOKING AT RELATIVE TO THE DOOR
        if (playerRotationSpeedListening > 90 / timer)
        {
            playerRotationSpeedListening = (180 / timer) - playerRotationSpeedListening;
            playerInteractionRotationListening = side2.ListeningTransformRight.rotation;
        }

        //DISABLE PLAYER AND CAMERA CONTROLS
        player.GetComponent<CharacterController>().enabled = false;
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<LookAtInteractable>().enabled = false;
        cam.GetComponent<DimensionCamera>().enabled = false;

        //PLAY AUDIO
        side2.roomAudio.Play();

        //MOVE PLAYER AND CAMERA
        for (float i = 0; i < timer; i += Time.deltaTime)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, playerInteractionPosition, playerPositionSpeed * Time.deltaTime);
            player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, playerInteractionRotationListening, playerRotationSpeedListening * Time.deltaTime);
            cam.transform.localRotation = Quaternion.RotateTowards(cam.transform.localRotation, camInteractionRotation, camRotationSpeed * Time.deltaTime);
            side2.roomAudio.volume += Time.deltaTime / timer;

            yield return 0;
        }

        listening = true;
    }

    IEnumerator StopListening()
    {
        listening = false;

        for (float i = 0; i < timer; i += Time.deltaTime)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, playerPosition, playerPositionSpeed * Time.deltaTime);
            player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, playerRotation, playerRotationSpeedListening * Time.deltaTime);
            cam.transform.localRotation = Quaternion.RotateTowards(cam.transform.localRotation, cameraRotation, camRotationSpeed * Time.deltaTime);
            side1.roomAudio.volume -= Time.deltaTime / timer;
            side2.roomAudio.volume -= Time.deltaTime / timer;

            yield return 0;
        }

        player.GetComponent<CharacterController>().enabled = true;
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<LookAtInteractable>().enabled = true;
        cam.GetComponent<DimensionCamera>().enabled = true;
        side1.roomAudio.Stop();
        side2.roomAudio.Stop();

        isInteracting = false;
    }
}

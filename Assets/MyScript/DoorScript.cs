using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private Animator Anim;
    public bool IsOpen = false;
    private AudioSource MyPlayer;
    [SerializeField] AudioClip CabinSound;
    [SerializeField] AudioClip RoomSound;
    [SerializeField] AudioClip HouseSound;

    [SerializeField] bool Cabin;
    [SerializeField] bool Room;
    [SerializeField] bool House;

    public bool Locked;
    public string DoorType;

    private float ClosedAngle = 0;
    private float RightOpenedAngle = 90;
    private float LeftOpenendAngle = -90;
    private float DoorSwingSmoothingTime = 0.5f;
    private float DoorSwingMaxSpeed = 90;

    private float TargetAngle;
    private float CurrentAngle;
    private float CurrentAngularVelocity;

    public GameObject LookAtDoor;
    private Pickup LookAtDoorScript;

    public float TriggerRadius = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        MyPlayer = GetComponent<AudioSource>();
        LookAtDoor = GameObject.Find("FPSController/FirstPersonCharacter");
        LookAtDoorScript = LookAtDoor.GetComponent<Pickup>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Cabin == true)
        {
            DoorType = "Cabin";
            if (SaveScript.CabinKey == true)
            {
                Locked = false;
            }
        }

        if (Room == true)
        {
            DoorType = "Room";
            if (SaveScript.RoomKey == true)
            {
                Locked = false;
            }
        }

        if (House == true)
        {
            DoorType = "House";
            if (SaveScript.HouseKey == true)
            {
                Locked = false;
            }
        }


        if (Locked == false && LookAtDoorScript.CanSeeDoor == true)
        {
            if (((LookAtDoor.transform.position - transform.position).sqrMagnitude < TriggerRadius * TriggerRadius))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    ToggleAngle();
                }
            }
        }

        UpdateAngle();
        UpdateRotation();
    }

    public void DoorOpen()
    {
        if (IsOpen == false)
        {
            //Anim.SetTrigger("Open");
            IsOpen = true;

            if (Cabin == true)
            {
                MyPlayer.clip = CabinSound;
                MyPlayer.Play();
            }

            if (Room == true)
            {
                MyPlayer.clip = RoomSound;
                MyPlayer.Play();
            }

            if (House == true)
            {
                MyPlayer.clip = HouseSound;
                MyPlayer.Play();
            }


        }
        else if (IsOpen == true)
        {
            //Anim.SetTrigger("Close");
            IsOpen = false;

            if (Cabin == true)
            {
                MyPlayer.clip = CabinSound;
                MyPlayer.Play();
            }

            if (Room == true)
            {
                MyPlayer.clip = RoomSound;
                MyPlayer.Play();
            }

            if (House == true)
            {
                MyPlayer.clip = HouseSound;
                MyPlayer.Play();
            }
        }
    }

    void ToggleAngle()
    {
        if (transform.CompareTag("RightDoor") && LookAtDoorScript.isRightDoor == true)
        {
            if (TargetAngle == RightOpenedAngle)
            {
                TargetAngle = ClosedAngle;
            }
            else
            {
                TargetAngle = RightOpenedAngle;
            }
        }

        if (transform.CompareTag("LeftDoor") && LookAtDoorScript.isLeftDoor == true)
        {
            if (TargetAngle == LeftOpenendAngle)
            {
                TargetAngle = ClosedAngle;
            }
            else
            {
                TargetAngle = LeftOpenendAngle;
            }
        }
    }

    void UpdateAngle()
    {
        CurrentAngle = Mathf.SmoothDamp(CurrentAngle, TargetAngle, ref CurrentAngularVelocity, DoorSwingSmoothingTime, DoorSwingMaxSpeed);
    }

    void UpdateRotation()
    {
        transform.localRotation = Quaternion.AngleAxis(CurrentAngle, Vector3.up);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (Locked == false)
            {
                if (IsOpen == false)
                {
                    if (((other.transform.position - transform.position).sqrMagnitude < TriggerRadius * TriggerRadius))
                    {
                        StartCoroutine(OpenDoor());
                    }
                }

                if(IsOpen == true)
                {
                    if (((other.transform.position - transform.position).sqrMagnitude < TriggerRadius * TriggerRadius))
                    {
                        StartCoroutine(CloseDoor());
                    }
                }
            }
        }
    }

    IEnumerator OpenDoor()
    {
        yield return new WaitForSeconds(0f);
        Anim.SetTrigger("Open");

        yield return new WaitForSeconds(5f);
        IsOpen = true;
    }

    IEnumerator CloseDoor()
    {
        yield return new WaitForSeconds(3f);
        Anim.SetTrigger("Close");

        yield return new WaitForSeconds(5f);
        IsOpen = false;
    }

}

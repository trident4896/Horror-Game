using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    RaycastHit hit;
    [SerializeField]
    float Distance = 4.0f;
    [SerializeField]
    GameObject PickupMessage;
    [SerializeField]
    Text PickUpMessageText;

    [SerializeField] GameObject PlayerArms;

    private AudioSource MyPlayer;

    private float RayDistance;
    public bool CanSeePickup = false;
    public bool CanSeeDoor = false;

    [SerializeField] GameObject DoorMessage;
    [SerializeField] Text DoorText;

    private bool isApple = false;
    private bool isBattery = false;
    private bool isAmmo = false;

    public static bool PickArrow = false;
    public static bool PickBullet = false;

    public float DoorTriggerRadius = 4.0f;

    public bool isRightDoor = false;
    public bool isLeftDoor = false;

    [SerializeField] AudioClip PickUpSound;

    // Start is called before the first frame update
    void Start()
    {
        PickupMessage.gameObject.SetActive(false);
        DoorMessage.gameObject.SetActive(false);
        PlayerArms.gameObject.SetActive(false);
        RayDistance = Distance;
        MyPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, RayDistance))
        {
            //Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
            //Debug.DrawRay(transform.position, forward, Color.green);

            if (hit.transform.tag == "Apple")
            {

                CanSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.Apples < 6)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.Apples += 1;

                        MyPlayer.clip = PickUpSound;
                        MyPlayer.Play();
                    }
                }

                isApple = true;

            }
            else if (hit.transform.tag == "Battery")
            {

                CanSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.Batteries < 4)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.Batteries += 1;

                        MyPlayer.clip = PickUpSound;
                        MyPlayer.Play();
                    }

                }

                isBattery = true;

            }
            else if (hit.transform.tag == "Knife")
            {
                CanSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.Knife == false)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.Knife = true;

                        MyPlayer.clip = PickUpSound;
                        MyPlayer.Play();
                    }
                }
            }
            else if (hit.transform.tag == "Axe")
            {
                CanSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.Axe == false)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.Axe = true;

                        MyPlayer.clip = PickUpSound;
                        MyPlayer.Play();
                    }
                }
            }
            else if (hit.transform.tag == "Bat")
            {
                CanSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.Bat == false)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.Bat = true;

                        MyPlayer.clip = PickUpSound;
                        MyPlayer.Play();
                    }
                }
            }
            else if (hit.transform.tag == "Gun")
            {
                CanSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.Gun == false)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.Gun = true;

                        MyPlayer.clip = PickUpSound;
                        MyPlayer.Play();
                    }
                }
            }
            else if (hit.transform.tag == "Crossbow")
            {
                CanSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.Crossbow == false)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.Crossbow = true;

                        MyPlayer.clip = PickUpSound;
                        MyPlayer.Play();
                    }
                }
            }
            else if (hit.transform.tag == "CabinKey")
            {
                CanSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.CabinKey == false)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.CabinKey = true;

                        MyPlayer.clip = PickUpSound;
                        MyPlayer.Play();
                    }
                }
            }
            else if (hit.transform.tag == "HouseKey")
            {
                CanSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.HouseKey == false)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.HouseKey = true;

                        MyPlayer.clip = PickUpSound;
                        MyPlayer.Play();
                    }
                }
            }
            else if (hit.transform.tag == "RoomKey")
            {
                CanSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.RoomKey == false)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.RoomKey = true;

                        MyPlayer.clip = PickUpSound;
                        MyPlayer.Play();
                    }
                }
            }
            else if (hit.transform.tag == "Bullet")
            {
                CanSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.AmmoCount < 5)
                    {
                        PickBullet = true;
                        Destroy(hit.transform.gameObject);
                        SaveScript.AmmoCount += 1;
                        Inventory.isPickup = false;

                        MyPlayer.clip = PickUpSound;
                        MyPlayer.Play();
                    }

                    isAmmo = true;
                }

            }
            else if (hit.transform.tag == "Arrow")
            {
                CanSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.AmmoCount < 5)
                    {
                        PickArrow = true;
                        Destroy(hit.transform.gameObject);
                        SaveScript.AmmoCount += 1;
                        Inventory.isPickup = false;

                        MyPlayer.clip = PickUpSound;
                        MyPlayer.Play();
                    }

                    isAmmo = true;
                }

            }
            else if (hit.transform.tag == "RightDoor" || hit.transform.tag == "LeftDoor")
            {

                if ((transform.position - hit.transform.position).sqrMagnitude < DoorTriggerRadius * DoorTriggerRadius)
                {
                    if (hit.transform.tag == "RightDoor" && hit.collider.transform.parent.gameObject == hit.transform.parent.gameObject)
                    {
                        isRightDoor = true;
                        isLeftDoor = false;
                    }

                    if (hit.transform.tag == "LeftDoor" && hit.collider.transform.parent.gameObject == hit.transform.parent.gameObject)
                    {
                        isLeftDoor = true;
                        isRightDoor = false;
                    }

                    CanSeeDoor = true;
                    if (hit.transform.gameObject.GetComponent<DoorScript>().Locked == false)
                    {
                        if (hit.transform.gameObject.GetComponent<DoorScript>().IsOpen == false)
                        {
                            DoorText.text = "Press E to open";
                        }

                        if (hit.transform.gameObject.GetComponent<DoorScript>().IsOpen == true)
                        {
                            DoorText.text = "Press E to close";
                        }

                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            hit.transform.gameObject.SendMessage("DoorOpen");
                        }
                    }
                    else if (hit.transform.gameObject.GetComponent<DoorScript>().Locked == true)
                    {
                        DoorText.text = "You need " + hit.transform.gameObject.GetComponent<DoorScript>().DoorType + " key to unlock";
                    }

                }
            }
            else
            {
                CanSeePickup = false;
                CanSeeDoor = false;
            }
        }

        if (CanSeePickup == true)
        {
            PickupMessage.gameObject.SetActive(true);
            RayDistance = 1000f;

            if (SaveScript.Batteries >= 4 && isBattery == true)
            {
                PickUpMessageText.text = "No more space for Batteries";
            }

            if (SaveScript.Apples >= 6 && isApple == true)
            {
                PickUpMessageText.text = "No more space for Apples";
            }

            if (SaveScript.AmmoCount >= 5 && isAmmo == true)
            {
                PickUpMessageText.text = "No more space for Ammo";
            }

        }

        if (CanSeePickup == false)
        {
            PickupMessage.gameObject.SetActive(false);
            RayDistance = Distance;
            isApple = false;
            isBattery = false;
            isAmmo = false;
            PickUpMessageText.text = "Press E to pickup";
        }

        if (CanSeeDoor == true)
        {
            DoorMessage.gameObject.SetActive(true);

        }

        if (CanSeeDoor == false)
        {
            DoorMessage.gameObject.SetActive(false);
            isLeftDoor = false;
            isRightDoor = false;
        }
    }
}

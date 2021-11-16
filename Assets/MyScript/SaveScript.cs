using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScript : MonoBehaviour
{
    public static int PlayerHealth = 100;
    public static bool HealthChange = false;
    public static float BatteryPower = 1.0f;
    public static bool BatteryRefill = false;
    public static bool FlashLightOn = false;
    public static bool NVLightOn = false;
    public static int Apples = 0;
    public static int Batteries = 0;
    public static bool Knife = false;
    public static bool Bat = false;
    public static bool Axe = false;
    public static bool Gun = false;
    public static bool Crossbow = false;
    public static bool CabinKey = false;
    public static bool HouseKey = false;
    public static bool RoomKey = false;
    public static int AmmoCount = 0;
    public static int BulletClips = 0;
    public static bool ArrowRefill = false;
    public static bool HaveKnife = false;
    public static bool HaveBat = false;
    public static bool HaveAxe = false;
    public static bool HaveGun = false;
    public static bool HaveBow = false;
    public static int Bullets = 12;
    public static int Arrows = 6;
    public static bool NewGame = false;

    [SerializeField] 
    public Transform PlayerPrefab;

    [SerializeField]
    public Transform[] Patrol_Targets;

    [SerializeField]
    public GameObject Chase;

    [SerializeField]
    public GameObject Hurt;

    [SerializeField]
    public Animator HurtAnime;

    [SerializeField]
    public AudioSource Stab;

    [SerializeField]
    public GameObject Arm;

    [SerializeField]
    public GameObject KnifeBlood;
    [SerializeField]
    public GameObject BatBlood;
    [SerializeField]
    public GameObject AxeBlood;


    private void Start()
    {
        if (NewGame == true)
        {
            PlayerHealth = 100;
            HealthChange = false;
            BatteryPower = 1.0f;
            BatteryRefill = false;
            FlashLightOn = false;
            NVLightOn = false;
            Apples = 0;
            Batteries = 0;
            Knife = false;
            Bat = false;
            Axe = false;
            Gun = false;
            Crossbow = false;
            CabinKey = false;
            HouseKey = false;
            RoomKey = false;
            AmmoCount = 0;
            BulletClips = 0;
            ArrowRefill = false;
            HaveKnife = false;
            HaveBat = false;
            HaveAxe = false;
            HaveGun = false;
            HaveBow = false;
            Bullets = 12;
            Arrows = 6;
        }
    }
}

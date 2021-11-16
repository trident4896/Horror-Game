using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject InventoryMenu;
    public bool InventoryActive = false;
    [SerializeField] GameObject PlayerArms;
    [SerializeField] GameObject Knife;
    [SerializeField] GameObject BaseballBat;
    [SerializeField] GameObject Axe;
    [SerializeField] GameObject Gun;
    [SerializeField] GameObject Crossbow;
    [SerializeField] AudioClip WeaponChangeSFX;
    [SerializeField] AudioClip GunShot;
    [SerializeField] AudioClip ArrowShot;
    [SerializeField] AudioClip GunReloadSFX;
    [SerializeField] AudioClip BowReloadSFX;

    [SerializeField] Animator Anim;

    [SerializeField] GameObject GunUI_Object;
    [SerializeField] GameObject Bullet_Amounts;

    [SerializeField] GameObject BowUI_Object;
    [SerializeField] GameObject Arrow_Amounts;

    private GunUI GunUI_Script;

    //Apple
    [SerializeField] public GameObject[] AppleImage;
    [SerializeField] public GameObject[] AppleButton;

    [SerializeField] public GameObject[] BatteryImage;
    [SerializeField] public GameObject[] BatteryButton;

    //Battery
    private AudioSource MyPlayer;
    [SerializeField] AudioClip AppleBite;
    [SerializeField] AudioClip BatteryLoad;

    //Weapon
    [SerializeField] public GameObject KnifeImage;
    [SerializeField] public GameObject KnifeButton;

    [SerializeField] public GameObject BatImage;
    [SerializeField] public GameObject BatButton;

    [SerializeField] public GameObject AxeImage;
    [SerializeField] public GameObject AxeButton;

    [SerializeField] public GameObject GunImage;
    [SerializeField] public GameObject GunButton;

    [SerializeField] public GameObject CrossbowImage;
    [SerializeField] public GameObject CrossbowButton;

    [SerializeField] public GameObject CabinKeyImage;
    [SerializeField] public GameObject HouseKeyImage;
    [SerializeField] public GameObject RoomKeyImage;

    [SerializeField] public GameObject[] AmmoSlot;

    public GameObject BulletIconPrefab;
    public GameObject ArrowIconPrefab;

    public GameObject BulletButtonPrefab;
    public GameObject ArrowButtonPrefab;

    public static bool isPickup = false;

    private string button_name;

    void Start()
    {
        InventoryMenu.gameObject.SetActive(false);
        InventoryActive = false;

        GunUI_Object.gameObject.SetActive(false);
        Bullet_Amounts.gameObject.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        MyPlayer = GetComponent<AudioSource>();

        foreach (GameObject Apple_Image in AppleImage)
        {
            Apple_Image.SetActive(false);
        }

        foreach (GameObject Apple_Button in AppleButton)
        {
            Apple_Button.SetActive(false);
        }

        foreach (GameObject Battery_Image in BatteryImage)
        {
            Battery_Image.SetActive(false);
        }

        foreach (GameObject Battery_Button in BatteryButton)
        {
            Battery_Button.SetActive(false);
        }

        KnifeImage.SetActive(false);
        KnifeButton.SetActive(false);

        BatImage.SetActive(false);
        BatButton.SetActive(false);

        AxeImage.SetActive(false);
        AxeButton.SetActive(false);

        GunImage.SetActive(false);
        GunButton.SetActive(false);

        CrossbowImage.SetActive(false);
        CrossbowButton.SetActive(false);

        CabinKeyImage.SetActive(false);
        HouseKeyImage.SetActive(false);
        RoomKeyImage.SetActive(false);

        foreach (GameObject Ammo_Slot in AmmoSlot)
        {
            Ammo_Slot.SetActive(false);
        }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            
            if (InventoryActive == false)
            {
                InventoryMenu.gameObject.SetActive(true);
                InventoryActive = true;
                Time.timeScale = 0f;

                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

                /*SaveScript.HaveAxe = false;
                SaveScript.HaveBat = false;
                SaveScript.HaveKnife = false;
                SaveScript.HaveGun = false;
                SaveScript.HaveBow = false;*/

                GunUI_Object.gameObject.SetActive(false);
                Bullet_Amounts.gameObject.SetActive(false);

                BowUI_Object.gameObject.SetActive(false);
                Arrow_Amounts.gameObject.SetActive(false);

            }
            else if (InventoryActive == true)
            {
                InventoryMenu.gameObject.SetActive(false);
                InventoryActive = false;

                Time.timeScale = 1f;

                if (SaveScript.HaveGun == true)
                {
                    GunUI_Object.gameObject.SetActive(true);
                    Bullet_Amounts.gameObject.SetActive(true);
                }

                if(SaveScript.HaveBow == true)
                {
                    BowUI_Object.gameObject.SetActive(true);
                    Arrow_Amounts.gameObject.SetActive(true);
                }

                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

        if(SaveScript.HaveGun == false)
        {
            GunUI_Object.gameObject.SetActive(false);
            Bullet_Amounts.gameObject.SetActive(false);
        }

        if(SaveScript.HaveBow == false)
        {
            BowUI_Object.gameObject.SetActive(false);
            Arrow_Amounts.gameObject.SetActive(false);
        }

        CheckInventory();
        CheckWeapons();
        CheckKeys();
        CheckAmmo();
    }

    void CheckInventory()
    {

        if (SaveScript.Apples >= 1)
        {
            for (int i = 0; i < AppleImage.Length; i++)
            {
                if (i == SaveScript.Apples - 1)
                {
                    AppleImage[i].SetActive(true);
                }
            }

            for (int j = 0; j < AppleButton.Length; j++)
            {
                if (j == SaveScript.Apples - 1)
                {
                    AppleButton[j].SetActive(true);
                }
            }
        }

        if (SaveScript.Batteries >= 1)
        {
            for (int i = 0; i < BatteryImage.Length; i++)
            {
                if (i == SaveScript.Batteries - 1)
                {
                    BatteryImage[i].SetActive(true);
                }
            }

            for (int j = 0; j < BatteryButton.Length; j++)
            {
                if (j == SaveScript.Batteries - 1)
                {
                    BatteryButton[j].SetActive(true);
                }
            }
        }

    }

    void CheckAmmo()
    {
        if (SaveScript.AmmoCount >= 1)
        {
            if (Pickup.PickBullet == true)
            {
                for (int k = 0; k < AmmoSlot.Length; k++)
                {
                    if (k == SaveScript.AmmoCount - 1)
                    {
                        AmmoSlot[k].SetActive(true);
                        if (isPickup == false)
                        {
                            GameObject bulletIcon_prefab = Instantiate(BulletIconPrefab, new Vector2(AmmoSlot[k].transform.position.x, AmmoSlot[k].transform.position.y), Quaternion.identity) as GameObject;
                            bulletIcon_prefab.transform.SetParent(AmmoSlot[k].transform);

                            GameObject bullet_button = Instantiate(BulletButtonPrefab, new Vector2(AmmoSlot[k].transform.position.x, AmmoSlot[k].transform.position.y), Quaternion.identity) as GameObject;
                            bullet_button.transform.SetParent(AmmoSlot[k].transform);
                            bullet_button.GetComponent<Button>().onClick.AddListener(() => BulletAmmoUpdate(bullet_button, bulletIcon_prefab));
                            bullet_button.GetComponent<Button>().onClick.AddListener(() => AmmoRefill());

                            isPickup = true;
                            Pickup.PickBullet = false;
                        }
                    }
                }

            }

            if (Pickup.PickArrow == true)
            {
                for (int k = 0; k < AmmoSlot.Length; k++)
                {
                    if (k == SaveScript.AmmoCount - 1)
                    {
                        AmmoSlot[k].SetActive(true);
                        if (isPickup == false)
                        {
                            GameObject arrowIcon_prefab = Instantiate(ArrowIconPrefab, new Vector2(AmmoSlot[k].transform.position.x, AmmoSlot[k].transform.position.y), Quaternion.identity) as GameObject;
                            arrowIcon_prefab.transform.SetParent(AmmoSlot[k].transform);

                            GameObject arrow_button = Instantiate(ArrowButtonPrefab, new Vector2(AmmoSlot[k].transform.position.x, AmmoSlot[k].transform.position.y), Quaternion.identity) as GameObject;
                            arrow_button.transform.SetParent(AmmoSlot[k].transform);
                            arrow_button.GetComponent<Button>().onClick.AddListener(() => ArrowAmmoUpdate(arrow_button, arrowIcon_prefab));
                            arrow_button.GetComponent<Button>().onClick.AddListener(() => ArrowRefill());

                            isPickup = true;
                            Pickup.PickArrow = false;
                        }
                    }
                }

            }
        }
    }

    void CheckWeapons()
    {
        if (SaveScript.Knife == true)
        {
            KnifeImage.SetActive(true);
            KnifeButton.SetActive(true);
        }

        if (SaveScript.Bat == true)
        {
            BatImage.SetActive(true);
            BatButton.SetActive(true);
        }

        if (SaveScript.Axe == true)
        {
            AxeImage.SetActive(true);
            AxeButton.SetActive(true);
        }

        if (SaveScript.Gun == true)
        {
            GunImage.SetActive(true);
            GunButton.SetActive(true);
        }

        if (SaveScript.Crossbow == true)
        {
            CrossbowImage.SetActive(true);
            CrossbowButton.SetActive(true);
        }
    }

    void CheckKeys()
    {
        if (SaveScript.CabinKey == true)
        {
            CabinKeyImage.SetActive(true);
        }

        if (SaveScript.HouseKey == true)
        {
            HouseKeyImage.SetActive(true);
        }

        if (SaveScript.RoomKey == true)
        {
            RoomKeyImage.SetActive(true);
        }
    }

    public void HealthUpdate()
    {

        if (SaveScript.PlayerHealth < 100)
        {
            SaveScript.PlayerHealth += 10;
            SaveScript.HealthChange = true;
            SaveScript.Apples -= 1;

            MyPlayer.clip = AppleBite;
            MyPlayer.Play();

            if (SaveScript.PlayerHealth > 100)
            {
                SaveScript.PlayerHealth = 100;
            }
        }

        for (int i = 0; i < AppleImage.Length; i++)
        {
            if (i == SaveScript.Apples)
            {
                AppleImage[i].SetActive(false);
            }
        }

        for (int j = 0; j < AppleButton.Length; j++)
        {
            if (j == SaveScript.Apples)
            {
                AppleButton[j].SetActive(false);
            }
        }
    }

    public void BatteryUpdate()
    {
        SaveScript.BatteryRefill = true;
        SaveScript.Batteries -= 1;

        MyPlayer.clip = BatteryLoad;
        MyPlayer.Play();

        for (int i = 0; i < BatteryImage.Length; i++)
        {
            if (i == SaveScript.Batteries)
            {
                BatteryImage[i].SetActive(false);
            }
        }

        for (int j = 0; j < BatteryButton.Length; j++)
        {
            if (j == SaveScript.Batteries)
            {
                BatteryButton[j].SetActive(false);
            }
        }
    }

    public void BulletAmmoUpdate(GameObject button, GameObject Icon)
    {
        SaveScript.AmmoCount -= 1;

        for (int k = 0; k < AmmoSlot.Length; k++)
        {

            if (button != null)
            {
                button_name = button.transform.parent.name;
            }

            if (button_name != null)
            {
                if (button_name == AmmoSlot[k].name)
                {
                    AmmoSlot[k].transform.DetachChildren();
                    Destroy(button);
                    button = null;
                    Destroy(Icon);
                    Icon = null;

                    if (k + 1 < AmmoSlot.Length)
                    {

                        if (AmmoSlot[k].transform.childCount == 0)
                        {

                            for (int p = k + 1; p < AmmoSlot.Length; p++)
                            {

                                int t = p - 1;

                                for (int m = AmmoSlot[p].transform.childCount - 1; m >= 0; --m)
                                {
                                    if (t < AmmoSlot.Length)
                                    {

                                        Transform child = AmmoSlot[p].transform.GetChild(m);
                                        child.SetParent(AmmoSlot[t].transform, false);

                                    }
                                }

                            }

                        }

                    }
                }
            }
            
        }


    }

    public void ArrowAmmoUpdate(GameObject button, GameObject Icon)
    {
        SaveScript.AmmoCount -= 1;
        
        for (int k = 0; k < AmmoSlot.Length; k++)
        {
 
            if (button != null)
            {
                button_name = button.transform.parent.name;
            }

            if (button_name != null)
            {
                if (button_name == AmmoSlot[k].name)
                {
                    AmmoSlot[k].transform.DetachChildren();
                    Destroy(button);
                    button = null;
                    Destroy(Icon);
                    Icon = null;

                    if (k + 1 < AmmoSlot.Length)
                    {
                        if (AmmoSlot[k].transform.childCount == 0)
                        {
                            for (int p = k + 1; p < AmmoSlot.Length; p++)
                            {

                                int t = p - 1;

                                for (int m = AmmoSlot[p].transform.childCount - 1; m >= 0; --m)
                                {
                                    if (t < AmmoSlot.Length)
                                    {

                                        Transform child = AmmoSlot[p].transform.GetChild(m);
                                        child.SetParent(AmmoSlot[t].transform, false);

                                    }
                                }
                            }

                        }
                    }
                }
            }
           
        }
    }

    public void KnifeEnable()
    {
        PlayerArms.gameObject.SetActive(true);
        Knife.gameObject.SetActive(true);
        Anim.SetBool("Meelee", true);
        MyPlayer.clip = WeaponChangeSFX;
        MyPlayer.Play();

        SaveScript.HaveKnife = true;
        SaveScript.HaveBat = false;
        SaveScript.HaveAxe = false;
        SaveScript.HaveGun = false;
        SaveScript.HaveBow = false;
    }

    public void BatEnable()
    {
        PlayerArms.gameObject.SetActive(true);
        BaseballBat.gameObject.SetActive(true);
        Anim.SetBool("Meelee", true);
        MyPlayer.clip = WeaponChangeSFX;
        MyPlayer.Play();

        SaveScript.HaveKnife = false;
        SaveScript.HaveBat = true;
        SaveScript.HaveAxe = false;
        SaveScript.HaveGun = false;
        SaveScript.HaveBow = false;
    }

    public void AxeEnable()
    {
        PlayerArms.gameObject.SetActive(true);
        Axe.gameObject.SetActive(true);
        Anim.SetBool("Meelee", true);
        MyPlayer.clip = WeaponChangeSFX;
        MyPlayer.Play();

        SaveScript.HaveKnife = false;
        SaveScript.HaveBat = false;
        SaveScript.HaveAxe = true;
        SaveScript.HaveGun = false;
        SaveScript.HaveBow = false;
    }

    public void GunEnable()
    {
        PlayerArms.gameObject.SetActive(true);
        Gun.gameObject.SetActive(true);
        Anim.SetBool("Meelee", false);
        MyPlayer.clip = GunShot;
        MyPlayer.Play();

        SaveScript.HaveKnife = false;
        SaveScript.HaveBat = false;
        SaveScript.HaveAxe = false;
        SaveScript.HaveGun = true;
        SaveScript.HaveBow = false;
    }

    public void CrossbowEnable()
    {
        PlayerArms.gameObject.SetActive(true);
        Crossbow.gameObject.SetActive(true);
        Anim.SetBool("Meelee", false);
        MyPlayer.clip = ArrowShot;
        MyPlayer.Play();

        SaveScript.HaveKnife = false;
        SaveScript.HaveBat = false;
        SaveScript.HaveAxe = false;
        SaveScript.HaveGun = false;
        SaveScript.HaveBow = true;
    }

    public void DisableAllWeapons()
    {
        Knife.gameObject.SetActive(false);
        BaseballBat.gameObject.SetActive(false);
        Axe.gameObject.SetActive(false);
        Gun.gameObject.SetActive(false);
        Crossbow.gameObject.SetActive(false);
    }

    public void AmmoRefill()
    {
        SaveScript.Bullets += 12;
        MyPlayer.clip = GunReloadSFX;
        MyPlayer.Play();

        if (SaveScript.Bullets >= 12)
        {
            SaveScript.Bullets = 12;
        }

    }

    public void ArrowRefill()
    {
        SaveScript.Arrows += 6;
        MyPlayer.clip = BowReloadSFX;
        MyPlayer.Play();

        if(SaveScript.Arrows >= 6)
        {
            SaveScript.Arrows = 6;
        }
    }
}



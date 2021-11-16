using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponDamage : MonoBehaviour
{
    [SerializeField] int WeaponDamage = 20;
    [SerializeField] Animator HurtAnim;
    [SerializeField] AudioSource MyPlayer;
    [SerializeField] GameObject FPSarm;

    private PlayerAttack StaminaScript;

    [SerializeField]
    private bool HitActive = false;

    [SerializeField]
    GameObject MySaveScript;
    private SaveScript PassSaveScript;

    private void Start()
    {
        MySaveScript = GameObject.Find("FPSController");

        PassSaveScript = MySaveScript.GetComponent<SaveScript>();

        HurtAnim = PassSaveScript.HurtAnime;
        MyPlayer = PassSaveScript.Stab;
        FPSarm = PassSaveScript.Arm;

        StaminaScript = FPSarm.GetComponent<PlayerAttack>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (HitActive == false)
            {
                HitActive = true;
                HurtAnim.SetTrigger("Hurt");
                SaveScript.PlayerHealth -= WeaponDamage;
                SaveScript.HealthChange = true;
                MyPlayer.Play();
                StaminaScript.AttackStamina -= 0.4f;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (HitActive == true)
            {
                HitActive = false;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int EnemyHealth = 100;
    [SerializeField]
    Animator Anim;
    private AudioSource MyPlayer;
    [SerializeField]
    AudioSource StabSound;
    [SerializeField]
    GameObject EnemyObject;

    [HideInInspector]
    public bool isDead = false;

    [SerializeField]
    GameObject KnifeBlood_VFX;
    [SerializeField]
    GameObject BatBlood_VFX;
    [SerializeField]
    GameObject AxeBlood_VFX;
    /*[SerializeField]
    GameObject BowBlood_VFX;*/

    [SerializeField]
    GameObject MySaveScript;
    private SaveScript PassSaveScript;

    private bool DamageOn = false;

    // Start is called before the first frame update
    void Start()
    {
        MySaveScript = GameObject.Find("FPSController");

        PassSaveScript = MySaveScript.GetComponent<SaveScript>();

        MyPlayer = GetComponent<AudioSource>();

        StartCoroutine(StartElements());

    }

    // Update is called once per frame
    void Update()
    {
        if (DamageOn == true)
        {
            if (EnemyHealth <= 0)
            {
                if (isDead == false)
                {

                    Anim.SetTrigger("Die");

                    Anim.SetBool("EnemyDeath", true);
                    isDead = true;

                    Destroy(EnemyObject, 8f);

                }
            }
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("P_Knife"))
        {
            EnemyHealth -= 20;
            Anim.SetTrigger("Twitch");
            KnifeBlood_VFX.gameObject.SetActive(true);

            MyPlayer.Play();
            StabSound.Play();
        }

        if(other.gameObject.CompareTag("P_Bat"))
        {
            EnemyHealth -= 10;
            Anim.SetTrigger("Twitch");
            BatBlood_VFX.gameObject.SetActive(true);

            MyPlayer.Play();
            StabSound.Play();
        }

        if(other.gameObject.CompareTag("P_Axe"))
        {
            EnemyHealth -= 30;
            Anim.SetTrigger("BigReact");
            AxeBlood_VFX.gameObject.SetActive(true);

            MyPlayer.Play();
            StabSound.Play();
        }

        if (other.gameObject.CompareTag("P_Crossbow"))
        {
            EnemyHealth -= 60;
            Anim.SetTrigger("BigReact");
            //BowBlood_VFX.transform.position = other.gameObject.transform.position;
            //BowBlood_VFX.gameObject.SetActive(true);

            MyPlayer.Play();
            StabSound.Play();

            Destroy(other.gameObject, 0.05f);
        }
    }

    IEnumerator StartElements()
    {
        yield return new WaitForSeconds(0.1f);

        StabSound = PassSaveScript.Stab;
        KnifeBlood_VFX = PassSaveScript.KnifeBlood;
        BatBlood_VFX = PassSaveScript.BatBlood;
        AxeBlood_VFX = PassSaveScript.AxeBlood;

        KnifeBlood_VFX.gameObject.SetActive(false);
        BatBlood_VFX.gameObject.SetActive(false);
        AxeBlood_VFX.gameObject.SetActive(false);

        DamageOn = true;
    }
}

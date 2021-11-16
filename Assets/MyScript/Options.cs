using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    [SerializeField] GameObject OptionsMenu;
    public bool OptionsActive = false;

    [SerializeField] GameObject FirstPeronObject;
    private FirstPersonController FirstPersonScript;

    [SerializeField] GameObject VisualsPanel;
    [SerializeField] GameObject SoundsPanel;
    [SerializeField] GameObject ControlsPanel;
    [SerializeField] GameObject DifficultyPanel;
    [SerializeField] GameObject SavePanel;
    [SerializeField] GameObject BackToMenuPanel;

    public Slider LightSlider;
    public Toggle FogAtmosphere;

    [SerializeField] PostProcessLayer MyLayer;
    private bool FogSwitch = true;

    [SerializeField] GameObject FogStorm;

    public Toggle AA_Off;
    public Toggle FXAA;
    public Toggle SMAA;
    public Toggle TAA;
    private int AA_State = 4;

    public Slider AmbienceLevel;
    public Slider SFXLevel;
    public AudioMixer AmbienceMixer;
    public AudioMixer SFXMixer;
    // Start is called before the first frame update
    void Start()
    {
        OptionsMenu.gameObject.SetActive(false);
        OptionsActive = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        FirstPersonScript = FirstPeronObject.GetComponent<FirstPersonController>();

        VisualsPanel.gameObject.SetActive(true);
        SoundsPanel.gameObject.SetActive(false);
        ControlsPanel.gameObject.SetActive(false);
        DifficultyPanel.gameObject.SetActive(false);
        SavePanel.gameObject.SetActive(false);
        BackToMenuPanel.gameObject.SetActive(false);

        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(OptionsActive == false)
            {
                FirstPersonScript.enabled = false;

                OptionsMenu.gameObject.SetActive(true);
                OptionsActive = true;

                Time.timeScale = 0f;

                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else if (OptionsActive == true)
            {
                FirstPersonScript.enabled = true;

                Time.timeScale = 1f;

                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

                OptionsMenu.gameObject.SetActive(false);
                OptionsActive = false;

                
            }
        }
    }

    public void VisualsEnable()
    {
        VisualsPanel.gameObject.SetActive(true);
        SoundsPanel.gameObject.SetActive(false);
        ControlsPanel.gameObject.SetActive(false);
        DifficultyPanel.gameObject.SetActive(false);
        SavePanel.gameObject.SetActive(false);
        BackToMenuPanel.gameObject.SetActive(false);
    }

    public void SoundsEnable()
    {
        VisualsPanel.gameObject.SetActive(false);
        SoundsPanel.gameObject.SetActive(true);
        ControlsPanel.gameObject.SetActive(false);
        DifficultyPanel.gameObject.SetActive(false);
        SavePanel.gameObject.SetActive(false);
        BackToMenuPanel.gameObject.SetActive(false);
    }

    public void ControlsEnable()
    {
        VisualsPanel.gameObject.SetActive(false);
        SoundsPanel.gameObject.SetActive(false);
        ControlsPanel.gameObject.SetActive(true);
        DifficultyPanel.gameObject.SetActive(false);
        SavePanel.gameObject.SetActive(false);
        BackToMenuPanel.gameObject.SetActive(false);
    }

    public void DifficultyEnable()
    {
        VisualsPanel.gameObject.SetActive(false);
        SoundsPanel.gameObject.SetActive(false);
        ControlsPanel.gameObject.SetActive(false);
        DifficultyPanel.gameObject.SetActive(true);
        SavePanel.gameObject.SetActive(false);
        BackToMenuPanel.gameObject.SetActive(false);
    }

    public void SaveEnable()
    {
        VisualsPanel.gameObject.SetActive(false);
        SoundsPanel.gameObject.SetActive(false);
        ControlsPanel.gameObject.SetActive(false);
        DifficultyPanel.gameObject.SetActive(false);
        SavePanel.gameObject.SetActive(true);
        BackToMenuPanel.gameObject.SetActive(false);
    }

    public void BackToMenuEnable()
    {
        VisualsPanel.gameObject.SetActive(false);
        SoundsPanel.gameObject.SetActive(false);
        ControlsPanel.gameObject.SetActive(false);
        DifficultyPanel.gameObject.SetActive(false);
        SavePanel.gameObject.SetActive(false);
        BackToMenuPanel.gameObject.SetActive(true);
    }

    public void LightBrightnessValue()
    {
        RenderSettings.ambientIntensity = LightSlider.value;
    }

    public void FogEnable()
    {
        if(FogAtmosphere.isOn == true)
        {
            if(FogSwitch == true)
            {
                MyLayer.fog.enabled = false;
                FogStorm.gameObject.SetActive(false);
                FogSwitch = false;
            }
            else if (FogSwitch == false)
            {
                MyLayer.fog.enabled = true;
                FogStorm.gameObject.SetActive(true);
                FogSwitch = true;
            }
        }

        if (FogAtmosphere.isOn == false)
        {
            if (FogSwitch == true)
            {
                MyLayer.fog.enabled = false;
                FogStorm.gameObject.SetActive(false);
                FogSwitch = false;
            }
            else if (FogSwitch == false)
            {
                MyLayer.fog.enabled = true;
                FogStorm.gameObject.SetActive(true);
                FogSwitch = true;
            }
        }

    }

    public void AntiAliasingDisable()
    {
        if (AA_State != 1)
        {
            if (AA_Off.isOn == true)
            {
                MyLayer.antialiasingMode = PostProcessLayer.Antialiasing.None;
                FXAA.isOn = false;
                SMAA.isOn = false;
                TAA.isOn = false;
                AA_State = 1;
            }
        }
    }

    public void AntiAliasingFXAA()
    {
        if (AA_State != 2)
        {
            if (FXAA.isOn == true)
            {
                MyLayer.antialiasingMode = PostProcessLayer.Antialiasing.FastApproximateAntialiasing;
                AA_Off.isOn = false;
                SMAA.isOn = false;
                TAA.isOn = false;
                AA_State = 2;
            }
        }
    }

    public void AntiAliasingSMAA()
    {
        if (AA_State != 3)
        {
            if (SMAA.isOn == true)
            {
                MyLayer.antialiasingMode = PostProcessLayer.Antialiasing.SubpixelMorphologicalAntialiasing;
                AA_Off.isOn = false;
                FXAA.isOn = false;
                TAA.isOn = false;
                AA_State = 3;
            }
        }
    }

    public void AntiAliasingTAA()
    {
        if (AA_State != 4)
        {
            if (TAA.isOn == true)
            {
                MyLayer.antialiasingMode = PostProcessLayer.Antialiasing.TemporalAntialiasing;
                AA_Off.isOn = false;
                FXAA.isOn = false;
                SMAA.isOn = false;
                AA_State = 4;
            }
        }
    }

    public void AmbienceVolumeAdjust()
    {
        AmbienceMixer.SetFloat("Ambience Volume", AmbienceLevel.value);
    }

    public void SFXVolumeAdjust()
    {
        SFXMixer.SetFloat("SFX Volume", SFXLevel.value);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}

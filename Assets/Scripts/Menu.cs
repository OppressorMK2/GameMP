using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

namespace UnityEngine.PostProcessing
{
    public class Menu : MonoBehaviour
    {
        public GameObject crossHairs;
        public GameObject ammoCounter;
        public GameObject optionsMenu;
        public GameObject pauseMenu;
        public GameObject BackOPTMENU;
        public GameObject miniProfiler;
        public GameObject player;
        public GameObject weaponry;
        public Toggle miniProfilerToggle;
        public Toggle VsyncToggle;
        public PostProcessingProfile cc;
        public Dropdown dropDown;
        public AudioMixer audiomixer;
        public bool Paused = false;
        List<string> prests = new List<string>() { "Extreme Performance", "Performance", "Default", "Quality", "Extreme Quality" };

        public Slider MotiobBlursliderVolume;
        public Slider VolumesliderMaster;
        public Slider VolumesliderEffects;

        void Start()
        {
            if (dropDown)
            {
                dropDown.AddOptions(prests);
            }
            if (PlayerPrefs.GetInt("Vsync") == 0)
            {
                VsyncToggle.isOn = false;
            }
            else if (PlayerPrefs.GetInt("Vsync") == 1)
            {
                VsyncToggle.isOn = true;
            }
            if (PlayerPrefs.GetString("profiler") == "False")
            {
                miniProfilerToggle.isOn = false;
            }
            else if (PlayerPrefs.GetString("profiler") == "True")
            {
                miniProfilerToggle.isOn = true;
            }
            VolumesliderMaster.value = PlayerPrefs.GetFloat("volumeMaster");
            VolumesliderEffects.value = PlayerPrefs.GetFloat("volumeEffects");
            MotiobBlursliderVolume.value = PlayerPrefs.GetFloat("motionBlur");
            dropDown.value = PlayerPrefs.GetInt("aaIndex");
            QualitySettings.vSyncCount = PlayerPrefs.GetInt("Vsync");
        }

        void Update()
        {
            if (SceneManager.GetActiveScene().name == "Menu")
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                Paused = false;
            }

            if (!Paused && SceneManager.GetActiveScene().name != "Menu")
            {
                optionsMenu.SetActive(false);
                BackOPTMENU.SetActive(false);
            }

            if (SceneManager.GetActiveScene().name == "Menu")
            {
                return;
            }
            
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Paused = !Paused;
            }
            if (Paused && !optionsMenu.activeSelf)
            {
                player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
                weaponry.GetComponent<WeaponManager>().enabled = false;
                weaponry.GetComponentInChildren<GunMouvement>().enabled = false;
                Cursor.visible = true;
                ammoCounter.SetActive(false);
                crossHairs.SetActive(false);
                pauseMenu.SetActive(true);
            }
            else if (Paused && optionsMenu.activeSelf)
            {
                pauseMenu.SetActive(false);
            }
            else
            {
                player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
                weaponry.GetComponent<WeaponManager>().enabled = true;
                weaponry.GetComponentInChildren<GunMouvement>().enabled = true;
                ammoCounter.SetActive(true);
                crossHairs.SetActive(true);
                pauseMenu.SetActive(false);
            }
            if (!Paused)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
            }
        }

        public void ChangeMiniProfiler(bool state)
        {
            miniProfiler.SetActive(state);
            PlayerPrefs.SetString("profiler", state.ToString());
            print(state.ToString());
        }

        public void ChangeVSync(bool state)
        {
            if(!state)
            {
                QualitySettings.vSyncCount = 0;
            }else
            {
                QualitySettings.vSyncCount = 1;
            }
            PlayerPrefs.SetInt("Vsync", QualitySettings.vSyncCount);
        }

        public void SetVolumeMaster(float volumeMaster)
        {
            audiomixer.SetFloat("volumeMaster", volumeMaster);
            PlayerPrefs.SetFloat("volumeMaster", volumeMaster);
        }

        public void SetVolumeEffects(float volumeEffects)
        {
            audiomixer.SetFloat("volumeEffects", volumeEffects);
            PlayerPrefs.SetFloat("volumeEffects", volumeEffects);
        }

        public void changeScene(string SceneName)
        {
            SceneManager.LoadScene(SceneName);
        }

        public void Quit()
        {
            Application.Quit();
        }

        public void ChangeMotionBlur(float amount)
        {
            MotionBlurModel.Settings MotionBlurSettings = cc.motionBlur.settings;
            MotionBlurSettings.shutterAngle = amount;
            cc.motionBlur.settings = MotionBlurSettings;
            PlayerPrefs.SetFloat("motionBlur", amount);
        }

        public void resume()
        {
            Paused = false;
        }

        public void ChangeAA(int index)
        {
            if (index == 0)
            {
                AntialiasingModel.Settings AntialiasingSettings = cc.antialiasing.settings;
                AntialiasingSettings.fxaaSettings.preset = AntialiasingModel.FxaaPreset.ExtremePerformance;
                cc.antialiasing.settings = AntialiasingSettings;
            }
            if (index == 1)
            {
                AntialiasingModel.Settings AntialiasingSettings = cc.antialiasing.settings;
                AntialiasingSettings.fxaaSettings.preset = AntialiasingModel.FxaaPreset.Performance;
                cc.antialiasing.settings = AntialiasingSettings;
            }
            if (index == 2)
            {
                AntialiasingModel.Settings AntialiasingSettings = cc.antialiasing.settings;
                AntialiasingSettings.fxaaSettings.preset = AntialiasingModel.FxaaPreset.Default;
                cc.antialiasing.settings = AntialiasingSettings;
            }
            if (index == 3)
            {
                AntialiasingModel.Settings AntialiasingSettings = cc.antialiasing.settings;
                AntialiasingSettings.fxaaSettings.preset = AntialiasingModel.FxaaPreset.Quality;
                cc.antialiasing.settings = AntialiasingSettings;
            }
            if (index == 4)
            {
                AntialiasingModel.Settings AntialiasingSettings = cc.antialiasing.settings;
                AntialiasingSettings.fxaaSettings.preset = AntialiasingModel.FxaaPreset.ExtremeQuality;
                cc.antialiasing.settings = AntialiasingSettings;
            }
            PlayerPrefs.SetInt("aaIndex", index);
        }
    }
}
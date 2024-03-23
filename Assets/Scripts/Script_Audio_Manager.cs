using UnityEditor;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Script_Audio_Manager : MonoBehaviour
{
    [Header("------------Audio Source------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("------------Audio Clip------------")]
    public AudioClip Music_MainMenu;
    public AudioClip Music_Game;
    public AudioClip SFX_YouWantToPlay;
    public AudioClip SFX_non;
    public AudioClip SFX_Meow;
    public AudioClip SFX_bullet;

    public static Script_Audio_Manager instance;

    private void Awake()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        string sceneName = currentScene.name;

        if (instance == null)
        {
            if (sceneName == "SCN_Final Game")
            {
                Script_Audio_Manager.instance.GetComponent<AudioSource>().Pause();
                musicSource.clip = Music_Game;
                musicSource.Play();
            }

            instance = this;
            DontDestroyOnLoad(gameObject);

        }
       
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        string sceneName = currentScene.name;

        if (sceneName == "SCN_Main Menu")
        {
            musicSource.clip = Music_MainMenu;
            musicSource.Play();
        }
        else if (sceneName == "SCN_Final Game")
        {
            musicSource.clip = Music_Game;
            musicSource.Play();
           
        }
    }

    private void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        string sceneName = currentScene.name;

        if (sceneName == "SCN_Final Game")
        {
            Script_Audio_Manager.instance.GetComponent<AudioSource>().Pause();
            musicSource.clip = Music_Game;
            musicSource.Play();
        }
    }

    public void PlayMusic(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }


}

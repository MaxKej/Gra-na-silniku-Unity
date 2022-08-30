using UnityEngine;
using UnityEngine.SceneManagement;

public class Kolizje : MonoBehaviour
{
    [SerializeField] float loadTime = 2f;
    [SerializeField] AudioClip crash;
    [SerializeField] AudioClip win;

    [SerializeField] ParticleSystem crashParticle;
    [SerializeField] ParticleSystem winParticle;

    AudioSource audioSource;
    bool przejscie = false;
    bool collisionDisabled = false;

    void Start() 
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        GoToMenu();
        DebugKeys();
    }

    void GoToMenu()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    void DebugKeys()
    {
        if(Input.GetKey(KeyCode.L))
        {
            LoadNextLevel();
        }
        else if (Input.GetKey(KeyCode.C))
        {
            collisionDisabled = !collisionDisabled;
        }
    }

    void CrashSequence()
    {        
        audioSource.Stop();
        crashParticle.Play();
        audioSource.volume = 0.05f;
        audioSource.PlayOneShot(crash);
        GetComponent<Ruch>().enabled = false;
        Invoke("ReloadLevel", loadTime);
    }
    
    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void NextLevel()
    {
        przejscie = true;
        audioSource.Stop();
        winParticle.Play();
        audioSource.volume = 0.5f;
        audioSource.PlayOneShot(win);
        GetComponent<Ruch>().enabled = false;
        Invoke("LoadNextLevel", loadTime);
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    void OnCollisionEnter(Collision other) 
    {
        if(przejscie || collisionDisabled) return;
        switch(other.gameObject.tag)
        {
            case "Start":
                Debug.Log("Start");
            break;
            case "Finish":
                NextLevel();
            break;
            default:
                CrashSequence();
            break;
        }
    }
}

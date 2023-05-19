using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentMusicManager : MonoBehaviour
{
    public AudioClip[] levelMusicChangeArray;
    private AudioSource audioSource;
    private void Awake()
    {
        GameObject.DontDestroyOnLoad(gameObject);
        Debug.Log($"[{gameObject.name}:{gameObject.GetInstanceID()}] Don't destroy on load");
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource= GetComponent<AudioSource>();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    // Update is called once per frame
    void Update()
    {
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        int sceneId = scene.buildIndex;
        if (sceneId < levelMusicChangeArray.Length)
        {
            var thisSceneMusic = levelMusicChangeArray[sceneId];
            Debug.Log($"Воспроизведение звука: {thisSceneMusic}");
            if (thisSceneMusic)
            {
                audioSource.clip = thisSceneMusic;
                audioSource.loop = true;
                audioSource.Play();
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesHandler : MonoBehaviour
{
    public SceneNames Scenes;
        
    void Load(string name) {
        SceneManager.LoadScene(name, LoadSceneMode.Additive);
    }

    void Unload(string name) {
        SceneManager.UnloadSceneAsync(name);
    }

    Scene LoadAndGet(string name) {
        SceneManager.LoadScene(name, LoadSceneMode.Additive);

        return SceneManager.GetSceneByName(name);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new PrefabList", menuName = "Scriptable Objects / PrefabList")]
public class PrefabList : ScriptableObject {
    public GameObject MainMenu;
    public GameObject PauseMenu;
    public GameObject LoadingMenu;
    public GameObject PopUpWindow;
}
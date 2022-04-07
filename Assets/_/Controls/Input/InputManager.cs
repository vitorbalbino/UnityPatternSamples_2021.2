using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using InputSys = UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    #region notas
    // Control Scheme handled
    //      Deve alterar o controle para o tipo desejado. Ao importar pro celular não me interessa o mouse.


    // Map Handler
    //      change maps


    // Controls Handler
    //      Last used control by each player
    //      Alert if last used control disconect
    //      Keyboard, mouse, touchscreen, Xbox one, PlayStation, Nintendo Switch



    // Custom input action reader (button, vector, etc)

    // Player - A filter for witch player each control represent - Input action A for player X call Player X Action A

    #endregion notas


    Gamepad gamepad { get { return Gamepad.current; } }
    InputSys.Keyboard keyboard { get { return InputSys.Keyboard.current; } }
    Mouse mouse { get { return Mouse.current; } }

    //[Header("Sub-Behaviours")]
    //public UIMenuBehaviour uiMenuBehaviour;

    //public void SetupManager() {
    //    uiMenuBehaviour.SetupBehaviour();
    //}

    //public void UpdateUIMenuState(bool newState) {
    //    uiMenuBehaviour.UpdateUIMenuState(newState);
    //}

    //public void MenuButtonOptionSelected(int newPanelID) {
    //    uiMenuBehaviour.SwitchUIContextPanels(newPanelID);
    //}


    ////Get Data ----
    //public List<PlayerController> GetActivePlayerControllers() {
    //    return activePlayerControllers;
    //}

    //public PlayerController GetFocusedPlayerController() {
    //    return focusedPlayerController;
    //}

    public int NumberOfConnectedDevices() {
        return InputSystem.devices.Count;
    }

}



public class Control {

}


public class Keyboard : Control {
    Gamepad gamepad = Gamepad.current;
    void FixedUpdate() {
        if(gamepad == null)
            return; // No gamepad connected.

        if(gamepad.rightTrigger.wasPressedThisFrame) {
            // 'Use' code here
        }

        Vector2 move = gamepad.leftStick.ReadValue();
        // 'Move' code here
    }
}

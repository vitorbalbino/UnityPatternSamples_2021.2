using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace State
{
    // Ref: https://youtu.be/Vt8aZDPzRjI?t=596


    public class StateMachine
    {
        #region A State Machine Study

        public State currentState;
        public ExampleState exampleState = new ExampleState();


        public virtual void StartMachine()
        {
            ToState(exampleState);
        }


        public void ToState(State state)
        {
            currentState.ExitState(this);
            currentState = state;
            exampleState.EnterState(this);
        }

        #endregion
    }



    // Abstract class for all states
    public abstract class State
    {
        #region A state study
        
        public abstract void EnterState(StateMachine stateManager);
        public abstract void UpdateState(StateMachine stateManager);
        public abstract void ExitState(StateMachine stateManager);

        // Exemplo com um segundo parâmetro, que pode vir do OnCollisionEnter do Monobehaviour com colisor.
        public abstract void OnCollisionEnter(StateMachine stateManager, Collision collision);
        
    }



    // Example of a concrete state
    public class ExampleState : State
    {
        public override void EnterState(StateMachine stateManager) { }
        public override void UpdateState(StateMachine stateManager) { }
        public override void ExitState(StateMachine stateManager) { }
        public override void OnCollisionEnter(StateMachine stateManager, Collision collision)
        { 
            stateManager.ToState(stateManager.exampleState);
        }

        #endregion A state study
    }
}



public static class Do // Custom commands
{
    #region Custom Logs

    // Ref https://docs.unity3d.com/ScriptReference/Debug.html
    // Ref https://docs.unity3d.com/Packages/com.unity.ugui@1.0/manual/StyledText.html
    // Ref https://youtu.be/lRqR4YF8iQs

    public static void Log(object text, Object context = null, bool condition = true)
    {
        string prefix = "";
        DoLog(LogType.Log, prefix, text, condition, context);
    }

    public static void LogSucess(object text, Object context = null, bool condition = true)
    {
        string prefix = "<color=green>Sucess!</color>";
        DoLog(LogType.Log, prefix, text, condition, context);
    }

    public static void LogWarning(object text, Object context = null, bool condition = true)
    {
        string prefix = "<color=yellow>Warning!</color>";
        DoLog(LogType.Warning, prefix, text, condition, context);
    }

    public static void LogError(object text, Object context = null, bool condition = true)
    {
        string prefix = "<color=red>Error!</color>";
        DoLog(LogType.Error, prefix, text, condition, context);
    }


    static void DoLog(LogType type, string prefix, object text, bool condition, Object context)
    {
        if (condition)
        {
            #if UNITY_EDITOR

            if (context != null)
            {
                object message = $"<b>{prefix}</b> " + text + $"\n\n<b>{context.name}; {context.GetType().ToString()}\n</b>";
                Debug.unityLogger.Log(type, message, context);
            }
            else
            {
                Debug.unityLogger.Log(type, $"<b>{prefix}</b> {text}");
            }

            #endif
        }
    }

    #endregion Custom Logs

}




public static class Extensions // the extension method for the string with "this" modifier
{
    // Strings
    #region Easy Text Format

    public static string Bold(this string str) => "<b>" + str + "</b>";
    public static string Color(this string str, string color) => string.Format($"<color={color}>{str}</color>");
    public static string Italic(this string str) => "<i>" + str + "</i>";
    public static string Size(this string str, int size) => string.Format($"<size={size}>{str}</sizer>");


    #endregion Easy Text Format


    // Vector3
    #region Value Format

    static public Vector3 AsPositive(this Vector3 vector) {
        if(vector.x < 0) vector.x *= -1;
        if(vector.y < 0) vector.y *= -1;
        if(vector.z < 0) vector.z *= -1;

        return vector;
    }

    static public Vector3 ZeroInNegativeValues(this Vector3 vector) {
        if(vector.x < 0) vector.x = 0;
        if(vector.y < 0) vector.y = 0;
        if(vector.z < 0) vector.z = 0;

        return vector;
    }

    static public Vector3 ZeroInPositiveValues(this Vector3 vector) {
        if(vector.x > 0) vector.x = 0;
        if(vector.y > 0) vector.y = 0;
        if(vector.z > 0) vector.z = 0;

        return vector;
    }

    #endregion
}
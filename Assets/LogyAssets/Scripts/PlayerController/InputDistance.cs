using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InputDistance : MonoBehaviour{
    //Singleton
    static InputDistance Singleton;
    InputDistance() {}

    [SerializeField] Vector2 differencePos;
    static public Vector2 Get_DifferencePos() {return Singleton.differencePos;}

    [SerializeField] float dis;
    static public float Get_Dis() {return Singleton.dis;}

    void Awake() {
        //Singleton
        if(Singleton != null) {
            Destroy(this);
            Debug.LogError("Input_Distance is instantiated");
        }
        else Singleton = this;
    }

    void Update() {
        _Input_Distance();
    }

    void _Input_Distance() {
        if(Mobile_Input.Get_onTouch()) {
            differencePos = Mobile_Input.Get_TouchPosition() - Mobile_Input.Get_TouchStartPosition();
            dis = Vector2.Distance(differencePos, Vector2.zero);
        }
        else if(Mobile_Input.Get_onTouchUp()) {
            differencePos = Vector2.zero;
            dis = 0f;
        }
    }
}

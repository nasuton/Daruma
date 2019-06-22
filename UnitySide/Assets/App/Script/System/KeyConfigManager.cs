using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyConfigManager : MonoBehaviour
{
    private static KeyConfigManager mInstance;

    private bool isAxisUse = false;

    public static KeyConfigManager Instance
    {
        get
        {
            if(mInstance == null)
            {
                GameObject obj = new GameObject("KeyConfigManager");
                mInstance = obj.AddComponent<KeyConfigManager>();
                DontDestroyOnLoad(obj);
            }

            return mInstance;
        }
    }

    //移動などに使う
    public Vector2 GetLeftAnalogStickValue()
    {
        Vector2 _value = new Vector2(Input.GetAxis("Axis 1"), Input.GetAxis("Axis 2"));
        Debug.Log("LeftAnalogStick value : " + _value);
        return _value;
    }

    public Vector2 GetRightAnalogStickValue()
    {
        Vector2 _value = new Vector2(Input.GetAxis("Axis 3"), Input.GetAxis("Axis 4"));
        Debug.Log("RightAnalogStick value : " + _value);
        return _value;
    }

    public Vector2 GetDirectionalPadValue()
    {
        Vector2 _value = new Vector2(Input.GetAxis("Axis 5"), Input.GetAxis("Axis 6"));
        Debug.Log("DirectionalPad value : " + _value);
        return _value;
    }

    //ボタンイベント
    public bool GetDirectionalPadUp()
    {
        if(Input.GetAxisRaw("Axis 6") < 0.0f)
        {
            if(!isAxisUse)
            {
                isAxisUse = true;
                return true;
            }
        }
        else
        {
            isAxisUse = false;
        }

        return false;
    }

    public bool GetDirectionalPadDown()
    {
        if (0.0f < Input.GetAxisRaw("Axis 6"))
        {
            if (!isAxisUse)
            {
                isAxisUse = true;
                return true;
            }
        }
        else
        {
            isAxisUse = false;
        }

        return false;
    }

    public bool GetDirectionalPadLeft()
    {
        if(Input.GetAxis("Axis 5") < 0.0f)
        {
            if (!isAxisUse)
            {
                isAxisUse = true;
                return true;
            }
        }
        else
        {
            isAxisUse = false;
        }

        return false;
    }

    public bool GetDirectionalPadRight()
    {
        if (0.0f < Input.GetAxis("Axis 5"))
        {
            if (!isAxisUse)
            {
                isAxisUse = true;
                return true;
            }
        }
        else
        {
            isAxisUse = false;
        }

        return false;
    }

    public bool GetStartButton()
    {
        return Input.GetKey(KeyCode.JoystickButton10) ? true : false;
    }

    public bool GetA_Button()
    {
        return Input.GetKey(KeyCode.JoystickButton0) ? true : false;
    }

    public bool GetB_Button()
    {
        return Input.GetKey(KeyCode.JoystickButton1) ? true : false;
    }

    public bool GetX_Button()
    {
        return Input.GetKey(KeyCode.JoystickButton2) ? true : false;
    }

    public bool GetY_Button()
    {
        return Input.GetKey(KeyCode.JoystickButton3) ? true : false;
    }

    public bool GetR1_Button()
    {
        return Input.GetKey(KeyCode.JoystickButton5) ? true : false;
    }

    public bool GetR2_Button()
    {
        return Input.GetKey(KeyCode.JoystickButton7) ? true : false;
    }

    public bool GetL1_Button()
    {
        return Input.GetKey(KeyCode.JoystickButton4) ? true : false;
    }

    public bool GetL2_Button()
    {
        return Input.GetKey(KeyCode.JoystickButton6) ? true : false;
    }

}

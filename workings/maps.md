# Controller Maps

***
    Buttons
    Square  = joystick button 0
    X       = joystick button 1
    Circle  = joystick button 2
    Triangle= joystick button 3
    L1      = joystick button 4
    R1      = joystick button 5
    L2      = joystick button 6
    R2      = joystick button 7
    Share	= joystick button 8
    Options = joystick button 9
    L3      = joystick button 10
    R3      = joystick button 11
    PS      = joystick button 12
    PadPress= joystick button 13
    
    Axes:
    LeftStickX      = X-Axis
    LeftStickY      = Y-Axis (Inverted?)
    RightStickX     = 3rd Axis
    RightStickY     = 4th Axis (Inverted?)
    L2              = 5th Axis (-1.0f to 1.0f range, unpressed is -1.0f)
    R2              = 6th Axis (-1.0f to 1.0f range, unpressed is -1.0f)
    DPadX           = 7th Axis
    DPadY           = 8th Axis (Inverted?)
***

```c#
    bool x, circle, triangle, square, l1, l2, r1, r2, opts, l3, r3, pad;

    private void Start()
    {
        square = Input.GetKey(KeyCode.Joystick1Button0);
        x = Input.GetKey(KeyCode.Joystick1Button1);
        circle = Input.GetKey(KeyCode.Joystick1Button2);
        triangle = Input.GetKey(KeyCode.Joystick1Button3);

        l1 = Input.GetKey(KeyCode.Joystick1Button4);
        l2 = Input.GetKey(KeyCode.Joystick1Button5);
        r1 = Input.GetKey(KeyCode.Joystick1Button6);
        r2 = Input.GetKey(KeyCode.Joystick1Button7);

        opts = Input.GetKey(KeyCode.Joystick1Button9);
        l3 = Input.GetKey(KeyCode.Joystick1Button10);
        r3 = Input.GetKey(KeyCode.Joystick1Button11);
        pad = Input.GetKey(KeyCode.Joystick1Button3);
    }
```

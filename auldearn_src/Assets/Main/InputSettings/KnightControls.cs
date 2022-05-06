// GENERATED AUTOMATICALLY FROM 'Assets/Main/InputSettings/KnightControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using Object = UnityEngine.Object;

public class KnightControls : IInputActionCollection, IDisposable
{
    // Profiler
    private readonly InputActionMap m_Profiler;
    private readonly InputAction m_Profiler_AttackLeft;
    private readonly InputAction m_Profiler_AttackRight;
    private readonly InputAction m_Profiler_Dodge;
    private readonly InputAction m_Profiler_Look;
    private readonly InputAction m_Profiler_Move;
    private IProfilerActions m_ProfilerActionsCallbackInterface;

    public KnightControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""KnightControls"",
    ""maps"": [
        {
            ""name"": ""Profiler"",
            ""id"": ""8ed4e45a-5a90-472e-aa3b-b3cfcae73feb"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""0ab2d4fe-2448-404d-b7f0-e2bda59effa5"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dodge"",
                    ""type"": ""Button"",
                    ""id"": ""3d6b731b-c6f3-40fd-ada7-bd505afff4e4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AttackLeft"",
                    ""type"": ""Button"",
                    ""id"": ""7ef0df8e-574b-4ad8-a3d2-103fc4280d33"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AttackRight"",
                    ""type"": ""Button"",
                    ""id"": ""7705b456-4078-4e54-aa77-0cde96883802"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""PassThrough"",
                    ""id"": ""6971a9d3-cb76-4f1b-89d2-9b5d6e9c5396"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2285d443-ed43-4289-8eec-c8365d02f3ef"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""31b9029d-b3cc-4b26-980b-0ecc9e7362f3"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""0ff50595-fb8a-4d5e-8042-a99cd535ab39"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ba86ba60-2441-4ed0-8274-50a827150b22"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7eadafe5-04d7-49ae-9334-2c921c418789"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""27385fc7-ce11-49e7-8e3c-11f16808d8b1"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d7fea6e1-ba82-462c-ac82-12cfc110a618"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dodge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2d7e8be2-2545-4790-8943-5b758fe2d6ea"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dodge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6fcebc52-53fa-472d-99e0-dcda0a219e80"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AttackLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""28cf6334-9ba8-4f57-879b-3c8979f30a8e"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AttackLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f1ad3714-dc56-4826-922e-7663df1a5b05"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AttackRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4dc6f2fb-9d95-4128-b530-c43964c18ae7"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AttackRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d0ee5e5f-e3bd-40ba-adb6-1079788facf5"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""646e7074-5cde-44fa-94d6-26e4010ed711"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Profiler
        m_Profiler = asset.FindActionMap("Profiler", true);
        m_Profiler_Move = m_Profiler.FindAction("Move", true);
        m_Profiler_Dodge = m_Profiler.FindAction("Dodge", true);
        m_Profiler_AttackLeft = m_Profiler.FindAction("AttackLeft", true);
        m_Profiler_AttackRight = m_Profiler.FindAction("AttackRight", true);
        m_Profiler_Look = m_Profiler.FindAction("Look", true);
    }

    public InputActionAsset asset { get; }
    public ProfilerActions Profiler => new ProfilerActions(this);

    public void Dispose()
    {
        Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public struct ProfilerActions
    {
        private readonly KnightControls m_Wrapper;

        public ProfilerActions(KnightControls wrapper)
        {
            m_Wrapper = wrapper;
        }

        public InputAction Move => m_Wrapper.m_Profiler_Move;
        public InputAction Dodge => m_Wrapper.m_Profiler_Dodge;
        public InputAction AttackLeft => m_Wrapper.m_Profiler_AttackLeft;
        public InputAction AttackRight => m_Wrapper.m_Profiler_AttackRight;
        public InputAction Look => m_Wrapper.m_Profiler_Look;

        public InputActionMap Get()
        {
            return m_Wrapper.m_Profiler;
        }

        public void Enable()
        {
            Get().Enable();
        }

        public void Disable()
        {
            Get().Disable();
        }

        public bool enabled => Get().enabled;

        public static implicit operator InputActionMap(ProfilerActions set)
        {
            return set.Get();
        }

        public void SetCallbacks(IProfilerActions instance)
        {
            if (m_Wrapper.m_ProfilerActionsCallbackInterface != null)
            {
                Move.started -= m_Wrapper.m_ProfilerActionsCallbackInterface.OnMove;
                Move.performed -= m_Wrapper.m_ProfilerActionsCallbackInterface.OnMove;
                Move.canceled -= m_Wrapper.m_ProfilerActionsCallbackInterface.OnMove;
                Dodge.started -= m_Wrapper.m_ProfilerActionsCallbackInterface.OnDodge;
                Dodge.performed -= m_Wrapper.m_ProfilerActionsCallbackInterface.OnDodge;
                Dodge.canceled -= m_Wrapper.m_ProfilerActionsCallbackInterface.OnDodge;
                AttackLeft.started -= m_Wrapper.m_ProfilerActionsCallbackInterface.OnAttackLeft;
                AttackLeft.performed -= m_Wrapper.m_ProfilerActionsCallbackInterface.OnAttackLeft;
                AttackLeft.canceled -= m_Wrapper.m_ProfilerActionsCallbackInterface.OnAttackLeft;
                AttackRight.started -= m_Wrapper.m_ProfilerActionsCallbackInterface.OnAttackRight;
                AttackRight.performed -= m_Wrapper.m_ProfilerActionsCallbackInterface.OnAttackRight;
                AttackRight.canceled -= m_Wrapper.m_ProfilerActionsCallbackInterface.OnAttackRight;
                Look.started -= m_Wrapper.m_ProfilerActionsCallbackInterface.OnLook;
                Look.performed -= m_Wrapper.m_ProfilerActionsCallbackInterface.OnLook;
                Look.canceled -= m_Wrapper.m_ProfilerActionsCallbackInterface.OnLook;
            }

            m_Wrapper.m_ProfilerActionsCallbackInterface = instance;
            if (instance != null)
            {
                Move.started += instance.OnMove;
                Move.performed += instance.OnMove;
                Move.canceled += instance.OnMove;
                Dodge.started += instance.OnDodge;
                Dodge.performed += instance.OnDodge;
                Dodge.canceled += instance.OnDodge;
                AttackLeft.started += instance.OnAttackLeft;
                AttackLeft.performed += instance.OnAttackLeft;
                AttackLeft.canceled += instance.OnAttackLeft;
                AttackRight.started += instance.OnAttackRight;
                AttackRight.performed += instance.OnAttackRight;
                AttackRight.canceled += instance.OnAttackRight;
                Look.started += instance.OnLook;
                Look.performed += instance.OnLook;
                Look.canceled += instance.OnLook;
            }
        }
    }

    public interface IProfilerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnDodge(InputAction.CallbackContext context);
        void OnAttackLeft(InputAction.CallbackContext context);
        void OnAttackRight(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
    }
}
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
    private readonly InputAction m_Profiler_DodgeLeft;
    private readonly InputAction m_Profiler_DodgeRight;
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
                    ""name"": ""DodgeRight"",
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
                },
                {
                    ""name"": ""DodgeLeft"",
                    ""type"": ""Button"",
                    ""id"": ""3c384269-dbb3-4b65-9e88-d49f56c26803"",
                    ""expectedControlType"": ""Button"",
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
                    ""name"": """",
                    ""id"": ""d7fea6e1-ba82-462c-ac82-12cfc110a618"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DodgeRight"",
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
                    ""id"": ""ca147525-195f-4176-b7eb-6d91e0ae0933"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DodgeLeft"",
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
        m_Profiler_DodgeRight = m_Profiler.FindAction("DodgeRight", true);
        m_Profiler_AttackLeft = m_Profiler.FindAction("AttackLeft", true);
        m_Profiler_AttackRight = m_Profiler.FindAction("AttackRight", true);
        m_Profiler_Look = m_Profiler.FindAction("Look", true);
        m_Profiler_DodgeLeft = m_Profiler.FindAction("DodgeLeft", true);
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
        public InputAction DodgeRight => m_Wrapper.m_Profiler_DodgeRight;
        public InputAction AttackLeft => m_Wrapper.m_Profiler_AttackLeft;
        public InputAction AttackRight => m_Wrapper.m_Profiler_AttackRight;
        public InputAction Look => m_Wrapper.m_Profiler_Look;
        public InputAction DodgeLeft => m_Wrapper.m_Profiler_DodgeLeft;

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
                DodgeRight.started -= m_Wrapper.m_ProfilerActionsCallbackInterface.OnDodgeRight;
                DodgeRight.performed -= m_Wrapper.m_ProfilerActionsCallbackInterface.OnDodgeRight;
                DodgeRight.canceled -= m_Wrapper.m_ProfilerActionsCallbackInterface.OnDodgeRight;
                AttackLeft.started -= m_Wrapper.m_ProfilerActionsCallbackInterface.OnAttackLeft;
                AttackLeft.performed -= m_Wrapper.m_ProfilerActionsCallbackInterface.OnAttackLeft;
                AttackLeft.canceled -= m_Wrapper.m_ProfilerActionsCallbackInterface.OnAttackLeft;
                AttackRight.started -= m_Wrapper.m_ProfilerActionsCallbackInterface.OnAttackRight;
                AttackRight.performed -= m_Wrapper.m_ProfilerActionsCallbackInterface.OnAttackRight;
                AttackRight.canceled -= m_Wrapper.m_ProfilerActionsCallbackInterface.OnAttackRight;
                Look.started -= m_Wrapper.m_ProfilerActionsCallbackInterface.OnLook;
                Look.performed -= m_Wrapper.m_ProfilerActionsCallbackInterface.OnLook;
                Look.canceled -= m_Wrapper.m_ProfilerActionsCallbackInterface.OnLook;
                DodgeLeft.started -= m_Wrapper.m_ProfilerActionsCallbackInterface.OnDodgeLeft;
                DodgeLeft.performed -= m_Wrapper.m_ProfilerActionsCallbackInterface.OnDodgeLeft;
                DodgeLeft.canceled -= m_Wrapper.m_ProfilerActionsCallbackInterface.OnDodgeLeft;
            }

            m_Wrapper.m_ProfilerActionsCallbackInterface = instance;
            if (instance != null)
            {
                Move.started += instance.OnMove;
                Move.performed += instance.OnMove;
                Move.canceled += instance.OnMove;
                DodgeRight.started += instance.OnDodgeRight;
                DodgeRight.performed += instance.OnDodgeRight;
                DodgeRight.canceled += instance.OnDodgeRight;
                AttackLeft.started += instance.OnAttackLeft;
                AttackLeft.performed += instance.OnAttackLeft;
                AttackLeft.canceled += instance.OnAttackLeft;
                AttackRight.started += instance.OnAttackRight;
                AttackRight.performed += instance.OnAttackRight;
                AttackRight.canceled += instance.OnAttackRight;
                Look.started += instance.OnLook;
                Look.performed += instance.OnLook;
                Look.canceled += instance.OnLook;
                DodgeLeft.started += instance.OnDodgeLeft;
                DodgeLeft.performed += instance.OnDodgeLeft;
                DodgeLeft.canceled += instance.OnDodgeLeft;
            }
        }
    }

    public interface IProfilerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnDodgeRight(InputAction.CallbackContext context);
        void OnAttackLeft(InputAction.CallbackContext context);
        void OnAttackRight(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnDodgeLeft(InputAction.CallbackContext context);
    }
}
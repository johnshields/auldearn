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
    private readonly InputActionMap _mProfiler;
    private readonly InputAction _mProfilerAttackLeft;
    private readonly InputAction _mProfilerAttackRight;
    private readonly InputAction _mProfilerDodgeLeft;
    private readonly InputAction _mProfilerDodgeRight;
    private readonly InputAction _mProfilerLook;
    private readonly InputAction _mProfilerMove;
    private IProfilerActions _mProfilerActionsCallbackInterface;

    public KnightControls()
    {
        Asset = InputActionAsset.FromJson(@"{
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
        _mProfiler = Asset.FindActionMap("Profiler", true);
        _mProfilerMove = _mProfiler.FindAction("Move", true);
        _mProfilerDodgeRight = _mProfiler.FindAction("DodgeRight", true);
        _mProfilerAttackLeft = _mProfiler.FindAction("AttackLeft", true);
        _mProfilerAttackRight = _mProfiler.FindAction("AttackRight", true);
        _mProfilerLook = _mProfiler.FindAction("Look", true);
        _mProfilerDodgeLeft = _mProfiler.FindAction("DodgeLeft", true);
    }

    public InputActionAsset Asset { get; }
    public ProfilerActions Profiler => new ProfilerActions(this);

    public void Dispose()
    {
        Object.Destroy(Asset);
    }

    public InputBinding? bindingMask
    {
        get => Asset.bindingMask;
        set => Asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => Asset.devices;
        set => Asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => Asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return Asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return Asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        Asset.Enable();
    }

    public void Disable()
    {
        Asset.Disable();
    }

    public struct ProfilerActions
    {
        private readonly KnightControls _mWrapper;

        public ProfilerActions(KnightControls wrapper)
        {
            _mWrapper = wrapper;
        }

        public InputAction Move => _mWrapper._mProfilerMove;
        public InputAction DodgeRight => _mWrapper._mProfilerDodgeRight;
        public InputAction AttackLeft => _mWrapper._mProfilerAttackLeft;
        public InputAction AttackRight => _mWrapper._mProfilerAttackRight;
        public InputAction Look => _mWrapper._mProfilerLook;
        public InputAction DodgeLeft => _mWrapper._mProfilerDodgeLeft;

        public InputActionMap Get()
        {
            return _mWrapper._mProfiler;
        }

        public void Enable()
        {
            Get().Enable();
        }

        public void Disable()
        {
            Get().Disable();
        }

        public bool Enabled => Get().enabled;

        public static implicit operator InputActionMap(ProfilerActions set)
        {
            return set.Get();
        }

        public void SetCallbacks(IProfilerActions instance)
        {
            if (_mWrapper._mProfilerActionsCallbackInterface != null)
            {
                Move.started -= _mWrapper._mProfilerActionsCallbackInterface.OnMove;
                Move.performed -= _mWrapper._mProfilerActionsCallbackInterface.OnMove;
                Move.canceled -= _mWrapper._mProfilerActionsCallbackInterface.OnMove;
                DodgeRight.started -= _mWrapper._mProfilerActionsCallbackInterface.OnDodgeRight;
                DodgeRight.performed -= _mWrapper._mProfilerActionsCallbackInterface.OnDodgeRight;
                DodgeRight.canceled -= _mWrapper._mProfilerActionsCallbackInterface.OnDodgeRight;
                AttackLeft.started -= _mWrapper._mProfilerActionsCallbackInterface.OnAttackLeft;
                AttackLeft.performed -= _mWrapper._mProfilerActionsCallbackInterface.OnAttackLeft;
                AttackLeft.canceled -= _mWrapper._mProfilerActionsCallbackInterface.OnAttackLeft;
                AttackRight.started -= _mWrapper._mProfilerActionsCallbackInterface.OnAttackRight;
                AttackRight.performed -= _mWrapper._mProfilerActionsCallbackInterface.OnAttackRight;
                AttackRight.canceled -= _mWrapper._mProfilerActionsCallbackInterface.OnAttackRight;
                Look.started -= _mWrapper._mProfilerActionsCallbackInterface.OnLook;
                Look.performed -= _mWrapper._mProfilerActionsCallbackInterface.OnLook;
                Look.canceled -= _mWrapper._mProfilerActionsCallbackInterface.OnLook;
                DodgeLeft.started -= _mWrapper._mProfilerActionsCallbackInterface.OnDodgeLeft;
                DodgeLeft.performed -= _mWrapper._mProfilerActionsCallbackInterface.OnDodgeLeft;
                DodgeLeft.canceled -= _mWrapper._mProfilerActionsCallbackInterface.OnDodgeLeft;
            }

            _mWrapper._mProfilerActionsCallbackInterface = instance;
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
// GENERATED AUTOMATICALLY FROM 'Assets/Input/InputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""Player Control"",
            ""id"": ""b88badb7-9f1a-4d7d-a090-f2d3a0fade6c"",
            ""actions"": [
                {
                    ""name"": ""Horizontal Movement"",
                    ""type"": ""Button"",
                    ""id"": ""4e397bc8-6f85-4cda-a647-dabdbfe35b09"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Vertical Movement"",
                    ""type"": ""Button"",
                    ""id"": ""b1b87628-74a2-43f5-9dec-55e04a773b6c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aiming"",
                    ""type"": ""Button"",
                    ""id"": ""efa1a26e-7da4-47fd-843c-9f1b1f65bc54"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Primary Trigger"",
                    ""type"": ""Button"",
                    ""id"": ""433a2a8d-76cd-4499-8d9e-dc5ebb340cde"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Secondary Trigger"",
                    ""type"": ""Button"",
                    ""id"": ""299858f2-5766-4795-9c91-8e27d3d9f4e5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""c9248d33-45c7-42cc-b913-823ce3f75950"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""6220702a-9a63-4c69-911f-a813cda8dfb0"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""New control scheme"",
                    ""action"": ""Horizontal Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""94aae6c9-d7d8-48f0-9b28-003f035994a9"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""New control scheme"",
                    ""action"": ""Horizontal Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left Joystick"",
                    ""id"": ""7d6fa713-b304-4642-9e4a-d6523300b36f"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""bf0f7b04-fa3b-4fbe-a864-3d3b0dd92e6f"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""7f6a03f3-50bc-4dea-b8c8-e5f0fe7d4031"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""04075a38-d5c0-46bb-b575-92d616f8f347"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""a767308c-a4b1-4443-9e66-af61dc4746f7"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""9a114d49-f991-4a48-a563-d1f872bfbcf6"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left Joystick + ABXY"",
                    ""id"": ""2117e798-7869-4845-bd93-114fc7714170"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""0f40b6a6-76a2-4c14-8e15-c65ac4413cf4"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""0fdee864-19d9-4ea5-b48c-6cb01490c2f5"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d3b0d0a0-86ab-439d-8cc3-c1a4ddb57a3b"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aiming"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""30b65cbf-43b1-46ef-9aa4-9e1803dfdce1"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Primary Trigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""442b0ca3-f772-4083-a569-fde166062898"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Primary Trigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4be978d6-423d-4337-9501-d0848eb771c6"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Secondary Trigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c6628d1a-4a7f-484a-a8a8-8e0dbf342756"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Secondary Trigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player Control
        m_PlayerControl = asset.FindActionMap("Player Control", throwIfNotFound: true);
        m_PlayerControl_HorizontalMovement = m_PlayerControl.FindAction("Horizontal Movement", throwIfNotFound: true);
        m_PlayerControl_VerticalMovement = m_PlayerControl.FindAction("Vertical Movement", throwIfNotFound: true);
        m_PlayerControl_Aiming = m_PlayerControl.FindAction("Aiming", throwIfNotFound: true);
        m_PlayerControl_PrimaryTrigger = m_PlayerControl.FindAction("Primary Trigger", throwIfNotFound: true);
        m_PlayerControl_SecondaryTrigger = m_PlayerControl.FindAction("Secondary Trigger", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
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

    // Player Control
    private readonly InputActionMap m_PlayerControl;
    private IPlayerControlActions m_PlayerControlActionsCallbackInterface;
    private readonly InputAction m_PlayerControl_HorizontalMovement;
    private readonly InputAction m_PlayerControl_VerticalMovement;
    private readonly InputAction m_PlayerControl_Aiming;
    private readonly InputAction m_PlayerControl_PrimaryTrigger;
    private readonly InputAction m_PlayerControl_SecondaryTrigger;
    public struct PlayerControlActions
    {
        private @InputActions m_Wrapper;
        public PlayerControlActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @HorizontalMovement => m_Wrapper.m_PlayerControl_HorizontalMovement;
        public InputAction @VerticalMovement => m_Wrapper.m_PlayerControl_VerticalMovement;
        public InputAction @Aiming => m_Wrapper.m_PlayerControl_Aiming;
        public InputAction @PrimaryTrigger => m_Wrapper.m_PlayerControl_PrimaryTrigger;
        public InputAction @SecondaryTrigger => m_Wrapper.m_PlayerControl_SecondaryTrigger;
        public InputActionMap Get() { return m_Wrapper.m_PlayerControl; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerControlActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerControlActions instance)
        {
            if (m_Wrapper.m_PlayerControlActionsCallbackInterface != null)
            {
                @HorizontalMovement.started -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnHorizontalMovement;
                @HorizontalMovement.performed -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnHorizontalMovement;
                @HorizontalMovement.canceled -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnHorizontalMovement;
                @VerticalMovement.started -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnVerticalMovement;
                @VerticalMovement.performed -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnVerticalMovement;
                @VerticalMovement.canceled -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnVerticalMovement;
                @Aiming.started -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnAiming;
                @Aiming.performed -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnAiming;
                @Aiming.canceled -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnAiming;
                @PrimaryTrigger.started -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnPrimaryTrigger;
                @PrimaryTrigger.performed -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnPrimaryTrigger;
                @PrimaryTrigger.canceled -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnPrimaryTrigger;
                @SecondaryTrigger.started -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnSecondaryTrigger;
                @SecondaryTrigger.performed -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnSecondaryTrigger;
                @SecondaryTrigger.canceled -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnSecondaryTrigger;
            }
            m_Wrapper.m_PlayerControlActionsCallbackInterface = instance;
            if (instance != null)
            {
                @HorizontalMovement.started += instance.OnHorizontalMovement;
                @HorizontalMovement.performed += instance.OnHorizontalMovement;
                @HorizontalMovement.canceled += instance.OnHorizontalMovement;
                @VerticalMovement.started += instance.OnVerticalMovement;
                @VerticalMovement.performed += instance.OnVerticalMovement;
                @VerticalMovement.canceled += instance.OnVerticalMovement;
                @Aiming.started += instance.OnAiming;
                @Aiming.performed += instance.OnAiming;
                @Aiming.canceled += instance.OnAiming;
                @PrimaryTrigger.started += instance.OnPrimaryTrigger;
                @PrimaryTrigger.performed += instance.OnPrimaryTrigger;
                @PrimaryTrigger.canceled += instance.OnPrimaryTrigger;
                @SecondaryTrigger.started += instance.OnSecondaryTrigger;
                @SecondaryTrigger.performed += instance.OnSecondaryTrigger;
                @SecondaryTrigger.canceled += instance.OnSecondaryTrigger;
            }
        }
    }
    public PlayerControlActions @PlayerControl => new PlayerControlActions(this);
    public interface IPlayerControlActions
    {
        void OnHorizontalMovement(InputAction.CallbackContext context);
        void OnVerticalMovement(InputAction.CallbackContext context);
        void OnAiming(InputAction.CallbackContext context);
        void OnPrimaryTrigger(InputAction.CallbackContext context);
        void OnSecondaryTrigger(InputAction.CallbackContext context);
    }
}

// GENERATED AUTOMATICALLY FROM 'Assets/Scirpts/Player Controlls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControlls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControlls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player Controlls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""a90dd816-9b7a-4b22-92b7-34116edb4387"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""f1f85ef1-7c08-488d-9cd1-16a87a750631"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Repair"",
                    ""type"": ""Button"",
                    ""id"": ""36a1a8c7-c6a4-46c7-a9ca-5cd4b84d828f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Ammo"",
                    ""type"": ""Button"",
                    ""id"": ""8e1c9f5b-5e4f-4156-9d0f-a82305574f5b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pick Up"",
                    ""type"": ""Button"",
                    ""id"": ""23444d9c-817f-4fe4-bb5f-f179a20da9e5"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Help_Mole"",
                    ""type"": ""Button"",
                    ""id"": ""2c2532bc-9cac-487d-afd4-1bf1d2e7fb27"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""969c377e-9c3f-4adb-867f-b677cad15dc0"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Button"",
                    ""id"": ""d236e793-3c88-48b9-886a-fb7c5007dd98"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move_Forwards"",
                    ""type"": ""Button"",
                    ""id"": ""46e76eef-b349-4fdd-b0d5-49d59fd03649"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""Move_Backwards"",
                    ""type"": ""Button"",
                    ""id"": ""dd004c60-a017-406f-b840-632e0ee76e65"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move_Left"",
                    ""type"": ""Button"",
                    ""id"": ""c1a7586e-16f0-47a5-b78f-98c48c7188e0"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move_Right"",
                    ""type"": ""Button"",
                    ""id"": ""6c669804-3a9b-4eac-80c1-2787f3096389"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Stop"",
                    ""type"": ""Button"",
                    ""id"": ""3d0d11aa-f0fa-4a2b-bc01-01435c300f97"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ArmMoveUp"",
                    ""type"": ""Button"",
                    ""id"": ""af6cb136-830f-4373-a73e-615020562d79"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ArmMoveLeft"",
                    ""type"": ""Button"",
                    ""id"": ""2b667a9d-341e-4e0d-a067-a0b66213ac7d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ArmMoveRight"",
                    ""type"": ""Button"",
                    ""id"": ""4a952553-9e28-484b-95e8-b9c97b318403"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ArmMoveDown"",
                    ""type"": ""Button"",
                    ""id"": ""cac91b34-d82b-4c0f-b4c8-1db69a59b071"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right Stick"",
                    ""type"": ""Button"",
                    ""id"": ""079a27af-18c8-470f-a98c-43e864d95330"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9de17016-610b-49fc-bf9e-ddaeeaa05b21"",
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
                    ""id"": ""d3913dae-8261-48d9-b8e1-c86668a9deed"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Repair"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a7d8ee38-6356-4bad-bc51-5476f3377e71"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ammo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""768881f9-fcb0-406c-8495-aa1cca167081"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pick Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c3a5a538-0df7-4549-82c2-643aedbca4fe"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Help_Mole"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""60550bcb-2b80-4b9a-a328-bb99a92360f8"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cce18245-ae7e-435c-9af8-d097dd7bfa49"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""19891c93-82af-4cb9-979e-d1d965c6fc69"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move_Forwards"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""077c99f7-348e-4f7c-88cf-65bf94646dd6"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move_Forwards"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""25e3764c-66b8-4705-ad69-1a64c46faf85"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move_Backwards"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""92dc1c8b-97a9-4aa1-8100-2d729e9ca6af"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move_Backwards"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ef87f3fe-3352-4c6f-a563-7dbdf4739063"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move_Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a187483c-02c9-40eb-b199-7ea0d8215086"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move_Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""13e1b37a-4d3c-4c3b-b487-23e2deded7d7"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move_Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c2053c88-de00-417e-bc2b-609b37332c34"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move_Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d81c0c0b-08a9-4cbf-9d94-326a5789c9ac"",
                    ""path"": ""<Gamepad>/rightStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Stop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fe216e94-7c6d-4112-959a-f2c66890f521"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ArmMoveUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bbb1dfae-ed60-4c2b-92e7-ddf1773e0eb1"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ArmMoveLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""417056b2-0eaf-4149-b83b-7d806f30eec0"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ArmMoveDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""00dd20de-a931-4efc-97b2-2411affc2881"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ArmMoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3c7a243b-10fb-49b0-ae15-517d7ce5b142"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right Stick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""New action map"",
            ""id"": ""5bc86c5f-a9bd-4f96-bf2d-77e878f4bbe9"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""537a6a55-ce6d-417b-97bc-56f54dcd5bdd"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""cae61fb1-6f11-4974-af3d-a8d043ef84b2"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Move = m_Gameplay.FindAction("Move", throwIfNotFound: true);
        m_Gameplay_Repair = m_Gameplay.FindAction("Repair", throwIfNotFound: true);
        m_Gameplay_Ammo = m_Gameplay.FindAction("Ammo", throwIfNotFound: true);
        m_Gameplay_PickUp = m_Gameplay.FindAction("Pick Up", throwIfNotFound: true);
        m_Gameplay_Help_Mole = m_Gameplay.FindAction("Help_Mole", throwIfNotFound: true);
        m_Gameplay_Shoot = m_Gameplay.FindAction("Shoot", throwIfNotFound: true);
        m_Gameplay_Rotate = m_Gameplay.FindAction("Rotate", throwIfNotFound: true);
        m_Gameplay_Move_Forwards = m_Gameplay.FindAction("Move_Forwards", throwIfNotFound: true);
        m_Gameplay_Move_Backwards = m_Gameplay.FindAction("Move_Backwards", throwIfNotFound: true);
        m_Gameplay_Move_Left = m_Gameplay.FindAction("Move_Left", throwIfNotFound: true);
        m_Gameplay_Move_Right = m_Gameplay.FindAction("Move_Right", throwIfNotFound: true);
        m_Gameplay_Stop = m_Gameplay.FindAction("Stop", throwIfNotFound: true);
        m_Gameplay_ArmMoveUp = m_Gameplay.FindAction("ArmMoveUp", throwIfNotFound: true);
        m_Gameplay_ArmMoveLeft = m_Gameplay.FindAction("ArmMoveLeft", throwIfNotFound: true);
        m_Gameplay_ArmMoveRight = m_Gameplay.FindAction("ArmMoveRight", throwIfNotFound: true);
        m_Gameplay_ArmMoveDown = m_Gameplay.FindAction("ArmMoveDown", throwIfNotFound: true);
        m_Gameplay_RightStick = m_Gameplay.FindAction("Right Stick", throwIfNotFound: true);
        // New action map
        m_Newactionmap = asset.FindActionMap("New action map", throwIfNotFound: true);
        m_Newactionmap_Newaction = m_Newactionmap.FindAction("New action", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Move;
    private readonly InputAction m_Gameplay_Repair;
    private readonly InputAction m_Gameplay_Ammo;
    private readonly InputAction m_Gameplay_PickUp;
    private readonly InputAction m_Gameplay_Help_Mole;
    private readonly InputAction m_Gameplay_Shoot;
    private readonly InputAction m_Gameplay_Rotate;
    private readonly InputAction m_Gameplay_Move_Forwards;
    private readonly InputAction m_Gameplay_Move_Backwards;
    private readonly InputAction m_Gameplay_Move_Left;
    private readonly InputAction m_Gameplay_Move_Right;
    private readonly InputAction m_Gameplay_Stop;
    private readonly InputAction m_Gameplay_ArmMoveUp;
    private readonly InputAction m_Gameplay_ArmMoveLeft;
    private readonly InputAction m_Gameplay_ArmMoveRight;
    private readonly InputAction m_Gameplay_ArmMoveDown;
    private readonly InputAction m_Gameplay_RightStick;
    public struct GameplayActions
    {
        private @PlayerControlls m_Wrapper;
        public GameplayActions(@PlayerControlls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Gameplay_Move;
        public InputAction @Repair => m_Wrapper.m_Gameplay_Repair;
        public InputAction @Ammo => m_Wrapper.m_Gameplay_Ammo;
        public InputAction @PickUp => m_Wrapper.m_Gameplay_PickUp;
        public InputAction @Help_Mole => m_Wrapper.m_Gameplay_Help_Mole;
        public InputAction @Shoot => m_Wrapper.m_Gameplay_Shoot;
        public InputAction @Rotate => m_Wrapper.m_Gameplay_Rotate;
        public InputAction @Move_Forwards => m_Wrapper.m_Gameplay_Move_Forwards;
        public InputAction @Move_Backwards => m_Wrapper.m_Gameplay_Move_Backwards;
        public InputAction @Move_Left => m_Wrapper.m_Gameplay_Move_Left;
        public InputAction @Move_Right => m_Wrapper.m_Gameplay_Move_Right;
        public InputAction @Stop => m_Wrapper.m_Gameplay_Stop;
        public InputAction @ArmMoveUp => m_Wrapper.m_Gameplay_ArmMoveUp;
        public InputAction @ArmMoveLeft => m_Wrapper.m_Gameplay_ArmMoveLeft;
        public InputAction @ArmMoveRight => m_Wrapper.m_Gameplay_ArmMoveRight;
        public InputAction @ArmMoveDown => m_Wrapper.m_Gameplay_ArmMoveDown;
        public InputAction @RightStick => m_Wrapper.m_Gameplay_RightStick;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Repair.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRepair;
                @Repair.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRepair;
                @Repair.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRepair;
                @Ammo.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAmmo;
                @Ammo.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAmmo;
                @Ammo.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAmmo;
                @PickUp.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPickUp;
                @PickUp.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPickUp;
                @PickUp.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPickUp;
                @Help_Mole.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHelp_Mole;
                @Help_Mole.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHelp_Mole;
                @Help_Mole.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHelp_Mole;
                @Shoot.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShoot;
                @Rotate.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotate;
                @Move_Forwards.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove_Forwards;
                @Move_Forwards.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove_Forwards;
                @Move_Forwards.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove_Forwards;
                @Move_Backwards.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove_Backwards;
                @Move_Backwards.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove_Backwards;
                @Move_Backwards.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove_Backwards;
                @Move_Left.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove_Left;
                @Move_Left.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove_Left;
                @Move_Left.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove_Left;
                @Move_Right.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove_Right;
                @Move_Right.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove_Right;
                @Move_Right.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove_Right;
                @Stop.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnStop;
                @Stop.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnStop;
                @Stop.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnStop;
                @ArmMoveUp.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnArmMoveUp;
                @ArmMoveUp.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnArmMoveUp;
                @ArmMoveUp.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnArmMoveUp;
                @ArmMoveLeft.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnArmMoveLeft;
                @ArmMoveLeft.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnArmMoveLeft;
                @ArmMoveLeft.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnArmMoveLeft;
                @ArmMoveRight.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnArmMoveRight;
                @ArmMoveRight.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnArmMoveRight;
                @ArmMoveRight.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnArmMoveRight;
                @ArmMoveDown.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnArmMoveDown;
                @ArmMoveDown.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnArmMoveDown;
                @ArmMoveDown.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnArmMoveDown;
                @RightStick.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRightStick;
                @RightStick.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRightStick;
                @RightStick.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRightStick;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Repair.started += instance.OnRepair;
                @Repair.performed += instance.OnRepair;
                @Repair.canceled += instance.OnRepair;
                @Ammo.started += instance.OnAmmo;
                @Ammo.performed += instance.OnAmmo;
                @Ammo.canceled += instance.OnAmmo;
                @PickUp.started += instance.OnPickUp;
                @PickUp.performed += instance.OnPickUp;
                @PickUp.canceled += instance.OnPickUp;
                @Help_Mole.started += instance.OnHelp_Mole;
                @Help_Mole.performed += instance.OnHelp_Mole;
                @Help_Mole.canceled += instance.OnHelp_Mole;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @Move_Forwards.started += instance.OnMove_Forwards;
                @Move_Forwards.performed += instance.OnMove_Forwards;
                @Move_Forwards.canceled += instance.OnMove_Forwards;
                @Move_Backwards.started += instance.OnMove_Backwards;
                @Move_Backwards.performed += instance.OnMove_Backwards;
                @Move_Backwards.canceled += instance.OnMove_Backwards;
                @Move_Left.started += instance.OnMove_Left;
                @Move_Left.performed += instance.OnMove_Left;
                @Move_Left.canceled += instance.OnMove_Left;
                @Move_Right.started += instance.OnMove_Right;
                @Move_Right.performed += instance.OnMove_Right;
                @Move_Right.canceled += instance.OnMove_Right;
                @Stop.started += instance.OnStop;
                @Stop.performed += instance.OnStop;
                @Stop.canceled += instance.OnStop;
                @ArmMoveUp.started += instance.OnArmMoveUp;
                @ArmMoveUp.performed += instance.OnArmMoveUp;
                @ArmMoveUp.canceled += instance.OnArmMoveUp;
                @ArmMoveLeft.started += instance.OnArmMoveLeft;
                @ArmMoveLeft.performed += instance.OnArmMoveLeft;
                @ArmMoveLeft.canceled += instance.OnArmMoveLeft;
                @ArmMoveRight.started += instance.OnArmMoveRight;
                @ArmMoveRight.performed += instance.OnArmMoveRight;
                @ArmMoveRight.canceled += instance.OnArmMoveRight;
                @ArmMoveDown.started += instance.OnArmMoveDown;
                @ArmMoveDown.performed += instance.OnArmMoveDown;
                @ArmMoveDown.canceled += instance.OnArmMoveDown;
                @RightStick.started += instance.OnRightStick;
                @RightStick.performed += instance.OnRightStick;
                @RightStick.canceled += instance.OnRightStick;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);

    // New action map
    private readonly InputActionMap m_Newactionmap;
    private INewactionmapActions m_NewactionmapActionsCallbackInterface;
    private readonly InputAction m_Newactionmap_Newaction;
    public struct NewactionmapActions
    {
        private @PlayerControlls m_Wrapper;
        public NewactionmapActions(@PlayerControlls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_Newactionmap_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_Newactionmap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(NewactionmapActions set) { return set.Get(); }
        public void SetCallbacks(INewactionmapActions instance)
        {
            if (m_Wrapper.m_NewactionmapActionsCallbackInterface != null)
            {
                @Newaction.started -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnNewaction;
            }
            m_Wrapper.m_NewactionmapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
            }
        }
    }
    public NewactionmapActions @Newactionmap => new NewactionmapActions(this);
    public interface IGameplayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRepair(InputAction.CallbackContext context);
        void OnAmmo(InputAction.CallbackContext context);
        void OnPickUp(InputAction.CallbackContext context);
        void OnHelp_Mole(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnMove_Forwards(InputAction.CallbackContext context);
        void OnMove_Backwards(InputAction.CallbackContext context);
        void OnMove_Left(InputAction.CallbackContext context);
        void OnMove_Right(InputAction.CallbackContext context);
        void OnStop(InputAction.CallbackContext context);
        void OnArmMoveUp(InputAction.CallbackContext context);
        void OnArmMoveLeft(InputAction.CallbackContext context);
        void OnArmMoveRight(InputAction.CallbackContext context);
        void OnArmMoveDown(InputAction.CallbackContext context);
        void OnRightStick(InputAction.CallbackContext context);
    }
    public interface INewactionmapActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
}

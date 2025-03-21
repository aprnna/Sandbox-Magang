//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.11.2
//     from Assets/Input/GameInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace GameInput
{
    public partial class @InputActions: IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @InputActions()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameInput"",
    ""maps"": [
        {
            ""name"": ""Game"",
            ""id"": ""239001f9-91f4-4578-a15a-09d95237d289"",
            ""actions"": [
                {
                    ""name"": ""PerformAction"",
                    ""type"": ""Button"",
                    ""id"": ""ccfe5bd0-ceff-465b-8bae-0e20d97133b8"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""ca90ecb8-4618-4347-a526-14a35c1dcf56"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""CancelAction"",
                    ""type"": ""Button"",
                    ""id"": ""cfce0516-be22-4058-a0de-9aaae337ca24"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""NextItem"",
                    ""type"": ""Button"",
                    ""id"": ""b044f07a-d68d-4c89-84d8-d8416215571a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PreviousItem"",
                    ""type"": ""Button"",
                    ""id"": ""aa3e1291-edd5-467f-b627-105e906c0a05"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RotateRightObject"",
                    ""type"": ""Button"",
                    ""id"": ""0983bc7d-76f6-431d-9bda-4a6ebf8f10c7"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RotateLeftObject"",
                    ""type"": ""Button"",
                    ""id"": ""03679a92-a844-4f14-ab44-f1c5aebb8013"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6f340846-9b74-4cfa-afda-c2b543261347"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PerformAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1ab40098-dd4d-459b-9310-d3cfae76fd0b"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""544d12e5-2d80-4984-ba7f-a76efdf19c46"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CancelAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c5b08336-1827-4a28-87cc-b91f9cded4d3"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9e2e63d7-7eb0-4d4a-b3bf-fb27df6427f1"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PreviousItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f6e65e44-399a-4deb-bce9-5cebe54fc62b"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateRightObject"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0248bc4b-3a7b-4c92-97fb-91c6a1b6e1df"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateLeftObject"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Player"",
            ""id"": ""9288fe42-8b82-4fc0-accb-cc05ef70c780"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""a61cfb15-3bb4-48d3-9a52-09672daf262a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""e9556435-6844-4528-ae5b-0201fa461207"",
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
                    ""id"": ""c05724d7-d4e2-4463-bb96-8ebda8050faf"",
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
                    ""id"": ""3983de8f-21b7-49ad-a14c-55d41f1fcc68"",
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
                    ""id"": ""d23c0010-956b-4090-9329-14e580930317"",
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
                    ""id"": ""ec62e806-2072-4a85-9ef7-1bf501760459"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Game
            m_Game = asset.FindActionMap("Game", throwIfNotFound: true);
            m_Game_PerformAction = m_Game.FindAction("PerformAction", throwIfNotFound: true);
            m_Game_MousePosition = m_Game.FindAction("MousePosition", throwIfNotFound: true);
            m_Game_CancelAction = m_Game.FindAction("CancelAction", throwIfNotFound: true);
            m_Game_NextItem = m_Game.FindAction("NextItem", throwIfNotFound: true);
            m_Game_PreviousItem = m_Game.FindAction("PreviousItem", throwIfNotFound: true);
            m_Game_RotateRightObject = m_Game.FindAction("RotateRightObject", throwIfNotFound: true);
            m_Game_RotateLeftObject = m_Game.FindAction("RotateLeftObject", throwIfNotFound: true);
            // Player
            m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
            m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        }

        ~@InputActions()
        {
            UnityEngine.Debug.Assert(!m_Game.enabled, "This will cause a leak and performance issues, InputActions.Game.Disable() has not been called.");
            UnityEngine.Debug.Assert(!m_Player.enabled, "This will cause a leak and performance issues, InputActions.Player.Disable() has not been called.");
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

        public IEnumerable<InputBinding> bindings => asset.bindings;

        public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
        {
            return asset.FindAction(actionNameOrId, throwIfNotFound);
        }

        public int FindBinding(InputBinding bindingMask, out InputAction action)
        {
            return asset.FindBinding(bindingMask, out action);
        }

        // Game
        private readonly InputActionMap m_Game;
        private List<IGameActions> m_GameActionsCallbackInterfaces = new List<IGameActions>();
        private readonly InputAction m_Game_PerformAction;
        private readonly InputAction m_Game_MousePosition;
        private readonly InputAction m_Game_CancelAction;
        private readonly InputAction m_Game_NextItem;
        private readonly InputAction m_Game_PreviousItem;
        private readonly InputAction m_Game_RotateRightObject;
        private readonly InputAction m_Game_RotateLeftObject;
        public struct GameActions
        {
            private @InputActions m_Wrapper;
            public GameActions(@InputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @PerformAction => m_Wrapper.m_Game_PerformAction;
            public InputAction @MousePosition => m_Wrapper.m_Game_MousePosition;
            public InputAction @CancelAction => m_Wrapper.m_Game_CancelAction;
            public InputAction @NextItem => m_Wrapper.m_Game_NextItem;
            public InputAction @PreviousItem => m_Wrapper.m_Game_PreviousItem;
            public InputAction @RotateRightObject => m_Wrapper.m_Game_RotateRightObject;
            public InputAction @RotateLeftObject => m_Wrapper.m_Game_RotateLeftObject;
            public InputActionMap Get() { return m_Wrapper.m_Game; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(GameActions set) { return set.Get(); }
            public void AddCallbacks(IGameActions instance)
            {
                if (instance == null || m_Wrapper.m_GameActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_GameActionsCallbackInterfaces.Add(instance);
                @PerformAction.started += instance.OnPerformAction;
                @PerformAction.performed += instance.OnPerformAction;
                @PerformAction.canceled += instance.OnPerformAction;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @CancelAction.started += instance.OnCancelAction;
                @CancelAction.performed += instance.OnCancelAction;
                @CancelAction.canceled += instance.OnCancelAction;
                @NextItem.started += instance.OnNextItem;
                @NextItem.performed += instance.OnNextItem;
                @NextItem.canceled += instance.OnNextItem;
                @PreviousItem.started += instance.OnPreviousItem;
                @PreviousItem.performed += instance.OnPreviousItem;
                @PreviousItem.canceled += instance.OnPreviousItem;
                @RotateRightObject.started += instance.OnRotateRightObject;
                @RotateRightObject.performed += instance.OnRotateRightObject;
                @RotateRightObject.canceled += instance.OnRotateRightObject;
                @RotateLeftObject.started += instance.OnRotateLeftObject;
                @RotateLeftObject.performed += instance.OnRotateLeftObject;
                @RotateLeftObject.canceled += instance.OnRotateLeftObject;
            }

            private void UnregisterCallbacks(IGameActions instance)
            {
                @PerformAction.started -= instance.OnPerformAction;
                @PerformAction.performed -= instance.OnPerformAction;
                @PerformAction.canceled -= instance.OnPerformAction;
                @MousePosition.started -= instance.OnMousePosition;
                @MousePosition.performed -= instance.OnMousePosition;
                @MousePosition.canceled -= instance.OnMousePosition;
                @CancelAction.started -= instance.OnCancelAction;
                @CancelAction.performed -= instance.OnCancelAction;
                @CancelAction.canceled -= instance.OnCancelAction;
                @NextItem.started -= instance.OnNextItem;
                @NextItem.performed -= instance.OnNextItem;
                @NextItem.canceled -= instance.OnNextItem;
                @PreviousItem.started -= instance.OnPreviousItem;
                @PreviousItem.performed -= instance.OnPreviousItem;
                @PreviousItem.canceled -= instance.OnPreviousItem;
                @RotateRightObject.started -= instance.OnRotateRightObject;
                @RotateRightObject.performed -= instance.OnRotateRightObject;
                @RotateRightObject.canceled -= instance.OnRotateRightObject;
                @RotateLeftObject.started -= instance.OnRotateLeftObject;
                @RotateLeftObject.performed -= instance.OnRotateLeftObject;
                @RotateLeftObject.canceled -= instance.OnRotateLeftObject;
            }

            public void RemoveCallbacks(IGameActions instance)
            {
                if (m_Wrapper.m_GameActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IGameActions instance)
            {
                foreach (var item in m_Wrapper.m_GameActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_GameActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public GameActions @Game => new GameActions(this);

        // Player
        private readonly InputActionMap m_Player;
        private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
        private readonly InputAction m_Player_Move;
        public struct PlayerActions
        {
            private @InputActions m_Wrapper;
            public PlayerActions(@InputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_Player_Move;
            public InputActionMap Get() { return m_Wrapper.m_Player; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
            public void AddCallbacks(IPlayerActions instance)
            {
                if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
            }

            private void UnregisterCallbacks(IPlayerActions instance)
            {
                @Move.started -= instance.OnMove;
                @Move.performed -= instance.OnMove;
                @Move.canceled -= instance.OnMove;
            }

            public void RemoveCallbacks(IPlayerActions instance)
            {
                if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IPlayerActions instance)
            {
                foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public PlayerActions @Player => new PlayerActions(this);
        public interface IGameActions
        {
            void OnPerformAction(InputAction.CallbackContext context);
            void OnMousePosition(InputAction.CallbackContext context);
            void OnCancelAction(InputAction.CallbackContext context);
            void OnNextItem(InputAction.CallbackContext context);
            void OnPreviousItem(InputAction.CallbackContext context);
            void OnRotateRightObject(InputAction.CallbackContext context);
            void OnRotateLeftObject(InputAction.CallbackContext context);
        }
        public interface IPlayerActions
        {
            void OnMove(InputAction.CallbackContext context);
        }
    }
}

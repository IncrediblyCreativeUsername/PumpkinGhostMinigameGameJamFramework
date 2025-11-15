using System;
using Game.MinigameFramework.Scripts.Framework.Input;
using Game.MinigameFramework.Scripts.Tags;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PumpkinGhost {
    [RequireComponent(typeof(Rigidbody))]
    public class PumpkinGhostPawn : Pawn {
        [SerializeField] private float speed = 0.25f;
        [SerializeField] private float gravity = -80f;
        [SerializeField] private float friction = 0.98f;
        
        private Rigidbody _rigidbody;
        public static bool isPawnInputEnabled = true;
        private Vector2 _moveInput = Vector2.zero;
        public float rotation = 180;

        public GameObject pumpkin;
        public float pumpkinSize;

        // Disable Unity's default gravity when this component is added
        private void Reset() {
            GetComponent<Rigidbody>().useGravity = false;
        }
        private void Awake() {
            _rigidbody = GetComponent<Rigidbody>();
        }
        
        // Handle input
        protected override void OnActionPressed(InputAction.CallbackContext context) {
            if (!isPawnInputEnabled) return;
            
            // Move
            if (context.action.name == PawnAction.Move) {
                _moveInput = context.ReadValue<Vector2>();
                if (_moveInput.magnitude > 0.1) {
                    rotation = Vector2.Angle(Vector2.up, _moveInput) * (_moveInput.x < 0 ? -1 : 1);
                }
            }
        }
        
        private void Update() {
            if (!isPawnInputEnabled) {
                _rigidbody.velocity = Vector3.zero;
                _rigidbody.angularVelocity = Vector3.zero;
                return;
            }

            _rigidbody.velocity = (gravity * Time.deltaTime * Vector3.up) + (((float) Math.Pow(friction, Time.deltaTime + 1)) * (_rigidbody.velocity + new Vector3(_moveInput.x * speed, 0, _moveInput.y * speed)));
            
            if (_rigidbody.velocity.magnitude < 0.7) {
                _rigidbody.velocity = new Vector3(0, _rigidbody.velocity.y, 0);
            }

            transform.eulerAngles = new Vector3(0, Mathf.LerpAngle(transform.eulerAngles.y, rotation, 0.1f), 0);
        }
    }
}
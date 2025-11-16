using System;
using System.Collections;
using System.Collections.Generic;
using Game.MinigameFramework.Scripts.Framework.Input;
using TMPro;
using UnityEngine;

namespace PumpkinGhost {
    public class PumpkinGhostGameManager : MonoBehaviour {
        // TIME VARIABLES
        [Header("Time")]
        public float duration = 20;
        [HideInInspector] public float timer = 0;
        // SCORING VARIABLES
        private MinigameManager.Ranking _ranking = new();
        private int[] playerScores = new int[4];
        // UI VARIABLES
        [Header("UI")]
        [SerializeField] private GameObject readyText;
        
        //SOUND
        [SerializeField] private AudioClip sound_music;
        private AudioSource _audio;
        

        private void Start() {
            _audio = GetComponent<AudioSource>();
            _ranking.SetAllPlayersToRank(1); // set all players to first place
            StartCoroutine(GameTimer());
        }
        IEnumerator GameTimer() {
            // Intro Animation
            PumpkinGhostPawn.isPawnInputEnabled = false;
            readyText.SetActive(true);
            yield return new WaitForSeconds(1);
            readyText.SetActive(false);
            PumpkinGhostPawn.isPawnInputEnabled = true;
            _audio.PlayOneShot(sound_music);
            // Timer
            
            yield return new WaitForSeconds(68);

            StartCoroutine(EndMinigame());
        }

        private void OnTriggerEnter(Collider other) {
            Pawn pawn = other.GetComponent<Pawn>();
            if (pawn != null) {
                KillPlayer(pawn);
            }
        }
        private void KillPlayer(Pawn pawn) {
            /*
            print($"Player {pawn.playerIndex} has been eliminated.");
            
            if(pawn.playerIndex >= 0) { // if pawn is bound to a player
                _ranking[pawn.playerIndex] = 4 - _deaths;
            }
            _deaths++; // also count deaths for pawns not bound to a player

            if (_deaths == 3) {
                StartCoroutine(EndMinigame());
            }
            */
        }

        private void Update()
        {
            _audio.pitch = Time.timeScale;
        }
        
        public void AddScore(int player, float pumpkinSize){
            playerScores[player] += (int)(pumpkinSize * 4.0F) - 3;
            Debug.Log(playerScores[player]);
        }

        private void CalculateScores() {
            
        }

        IEnumerator EndMinigame() {
            //Calculate Scores
            CalculateScores();
            // End
            yield return new WaitForSeconds(2);
            MinigameManager.instance.EndMinigame(_ranking);
        }
    }
}

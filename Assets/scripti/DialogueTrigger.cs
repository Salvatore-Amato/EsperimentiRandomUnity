using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogueScript;
    public float detectionRadius = 2.5f;
    private bool playerDetected;

    private void Update()
    {
        // Check if player is within detection radius
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, detectionRadius);
        bool detected = false;
        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("Player"))
            {
                detected = true;
                break;
            }
        }

        // If player detected, show indicator and wait for interaction
        if (detected)
        {
            if (!playerDetected)
            {
                playerDetected = true;
                dialogueScript.ToggleIndicator(true);
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                dialogueScript.StartDialogue();
            }
        }
        // If player not detected, hide indicator and end dialogue
        else
        {
            if (playerDetected)
            {
                playerDetected = false;
                dialogueScript.ToggleIndicator(false);
                dialogueScript.EndDialogue();
            }
        }
    }
}

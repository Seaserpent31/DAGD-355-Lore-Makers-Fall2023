using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Creating an easy way to set up power-ups with help from: https://youtu.be/PkNRPOrtyls?si=6Uozc7HJ0DEE3mP6.
// Scriptable/Delegate Objects.

// ==========[ PHASING ]==========
// Power-Up: Phasing.
    // The player gets the ability to phase in and out. 
    // When they phase, they become "invisible" and invincible to enemies.
    // To-Do:
        // Decide whether I want the power-up to be instantly activated upon pickup, or have a key they can press.
        // Decide how I want the power-up to spawn:
            // Randomly around the map?
            // Dropped by enemies?

[CreateAssetMenu(menuName = "Powerups/Phasing")] // For making things neat.
public class Phasing_Lauren : PowerUpEffects_Lauren
{
    // ==========[ VARIABLES ]==========
    // public float phaseTime; // How long the player will be phasing for.

    // We do NOT need Start or Update for this, so I took them out.

    public override void Apply(GameObject target)
    {
        // Do something here.
    }

} // End of Phasing.

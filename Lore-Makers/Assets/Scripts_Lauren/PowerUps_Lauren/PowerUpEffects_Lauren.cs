using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Creating an easy way to set up power-ups with help from: https://youtu.be/PkNRPOrtyls?si=6Uozc7HJ0DEE3mP6.
// Scriptable/Delegate Objects.

// ==========[ POWER UP EFFECTS ]==========
// Used with Power-Ups.

public abstract class PowerUpEffects_Lauren : ScriptableObject
// Abstract means we can't initialize the class (we can't make an instance of PowerUp).
// We can, however, INHERIT from the class.
{
    // We do NOT need Start or Update for this, so I took them out.

    public abstract void Apply(GameObject target);

} // End of Power Up Effects.

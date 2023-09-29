using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

// Help from: https://www.youtube.com/watch?v=46TqkhJu7uA&t=510s.

public class EmitExample : MonoBehaviour
{
    public int numColumns;
    public float speed;
    public Sprite texture;
    public Color color;
    public float lifetime;
    public float firerate;
    public float size;
    private float angle;
    public Material material;
    
    public ParticleSystem system;
    private ParticleSystemRenderer render;

    private void Awake()
    {
        Summon();
    }

    void Summon()
    {
        angle = 360f / numColumns;
        
        for(int i = 0; i < numColumns; i++)
        {
            // A simple particle material with no texture.
            Material particleMaterial = material;

            // Create a green Particle System.
            var go = new GameObject("Particle System");
            go.transform.Rotate(angle * i, 90, 0);
            go.transform.parent = this.transform;
            go.transform.position = this.transform.position;
            system = go.AddComponent<ParticleSystem>();
            go.GetComponent<ParticleSystemRenderer>().material = particleMaterial;
            var mainModule = system.main;
            mainModule.startColor = Color.green;
            mainModule.startSize = 0.5f;
            mainModule.startSpeed = speed;

            // var renderModule = render;
            // render.renderMode = ParticleSystemRenderMode.Stretch;
            // render.lengthScale = 1f;

            var emission = system.emission;
            emission.enabled = false;

            var shape = system.shape;
            shape.enabled = true;
            shape.shapeType = ParticleSystemShapeType.Sprite;
            shape.sprite = null;
            // shape.alignToDirection = false;

            var text = system.textureSheetAnimation;
            text.mode = ParticleSystemAnimationMode.Sprites;
            text.AddSprite(texture);
            text.enabled = true;
        }

        // Every 2 secs we will emit.
        InvokeRepeating("DoEmit", 0f, firerate);
    }

    void DoEmit()
    {
        foreach(Transform child in transform)
        {
            system = child.GetComponent<ParticleSystem>();
            
            // Any parameters we assign in emitParams will override the current system's when we call Emit.
            // Here we will override the start color and size.
            var emitParams = new ParticleSystem.EmitParams();
            emitParams.startColor = color;
            emitParams.startSize = size;
            emitParams.startLifetime = lifetime;

            system.Emit(emitParams, 10);
        }
    }
}
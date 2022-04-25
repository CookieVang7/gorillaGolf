using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{

    [SerializeField] private Animator animator;
    [SerializeField] Sprite smileIdle;
    [SerializeField] Sprite idle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void updateAnimation(SpriteRenderer gorillaSprite, Animator animator) 
    {
        if (DragNShoot.closeToBall)
        {
            Debug.Log("Please god work");
            //gorillaSprite.sprite = smileIdle;
            animator.SetLayerWeight(animator.GetLayerIndex("Smile Layer"), 1);
            animator.SetLayerWeight(animator.GetLayerIndex("Base Layer"), 0);
        }
        else
        {
            //gorillaSprite.sprite = idle;
            animator.SetLayerWeight(animator.GetLayerIndex("Smile Layer"), 0);
            animator.SetLayerWeight(animator.GetLayerIndex("Base Layer"), 1);
        }
    }
}

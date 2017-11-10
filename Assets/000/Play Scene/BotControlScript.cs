using UnityEngine;
using System.Collections;

// Require these components when using this script
[RequireComponent(typeof (Animator))]
[RequireComponent(typeof (CapsuleCollider))]
[RequireComponent(typeof (Rigidbody))]
public class BotControlScript : MonoBehaviour, SpeechRecognitionInterface
{
//	[System.NonSerialized]					
//	public float lookWeight;					// the amount to transition when using head look
//	
//	[System.NonSerialized]
//	public Transform enemy;						// a transform to Lerp the camera to during head look

	[Tooltip("Overall animation speed.")]
	public float animSpeed = 1.5f;				// a public setting for overall animator animation speed

	//public float lookSmoother = 3f;				// a smoothing setting for camera motion

	[Tooltip("Whether to use the extra curves for animation or not.")]
	public bool useCurves;						// a setting for teaching purposes to show use of curves


	private Animator anim;							// a reference to the animator on the character
	private AnimatorStateInfo currentBaseState;			// a reference to the current state of the animator, used for base layer
	private AnimatorStateInfo layer2CurrentState;	// a reference to the current state of the animator, used for layer 2
	private CapsuleCollider col;					// a reference to the capsule collider of the character
	
	private SpeechManager speechManager;
	private float walkSpeed;
	private float walkDirection;
	private bool jumpNow;
	private bool waveNow;
    private bool playNow;

	static int idleState = Animator.StringToHash("Base Layer.Idle");	
	static int locoState = Animator.StringToHash("Base Layer.Locomotion");			// these integers are references to our animator's states
	static int jumpState = Animator.StringToHash("Base Layer.Jump");				// and are used to check state for various actions to occur
	static int waveState = Animator.StringToHash("Layer2.Wave");


	// invoked when a speech phrase gets recognized
	public bool SpeechPhraseRecognized(string phraseTag, float condidence)
	{
		switch(phraseTag)
		{
			case "FORWARD":
				walkSpeed = 0.2f;
				walkDirection = 0f;
				break;

			case "BACK":
				walkSpeed = -0.2f;
				walkDirection = 0f;
				break;

			case "LEFT":
				walkDirection = -0.2f;
				if(walkSpeed == 0f)
					walkSpeed = 0.2f;
				break;

			case "RIGHT":
				walkDirection = 0.2f;
				if(walkSpeed == 0f)
					walkSpeed = 0.2f;
				break;

			case "RUN":
				walkSpeed = 0.5f;
				walkDirection = 0f;
				break;

			case "STOP":
				walkSpeed = 0f;
				walkDirection = 0f;
				break;

			case "JUMP":
				jumpNow = true;
				walkSpeed = 0.5f;
				walkDirection = 0f;
				break;

			case "HELLO":
				waveNow = true;
				walkSpeed = 0.0f;
				walkDirection = 0f;
				break;

            case "PLAY":
                playNow = true;
                break;
		}

		return true;
	}


	void Start ()
	{
		
	}
	
	
	void FixedUpdate ()
	{
        if (playNow == true)
        {
            Application.LoadLevel(1);
        }
	}

}

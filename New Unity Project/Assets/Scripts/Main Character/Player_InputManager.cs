using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player_InputManager : MonoBehaviour {

    private static Player_InputManager instance = null;

    [SerializeField]
    [HideInInspector]
    public float horizontal = 0.0f;
    [SerializeField]
    [HideInInspector]
    public float vertical = 0.0f;

    #region EvenInit Area
    [HideInInspector]
    public UnityEvent OnMoveForward = new UnityEvent();
    [HideInInspector]
    public UnityEvent OnMoveBackwards = new UnityEvent();
    [HideInInspector]
    public UnityEvent OnMoveUp = new UnityEvent();
    [HideInInspector]
    public UnityEvent OnMoveDown = new UnityEvent();
    [HideInInspector]
    public UnityEvent OnJump = new UnityEvent();
    [HideInInspector]
    public UnityEvent OnRegularAttack = new UnityEvent();
    [HideInInspector]
    public UnityEvent OnJumpingAttack = new UnityEvent();
    #endregion EventInit Area

    // Use this for initialization
    void Start () {
        
    }

    public static Player_InputManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = (Player_InputManager)FindObjectOfType(typeof(Player_InputManager));
                if(instance == null)
                {
                    instance = (new GameObject("PLayer-InputManager")).AddComponent<Player_InputManager>();
                }
            }

            return instance;
        }
    }
    
    // Update is called once per frame
    void Update ()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        #region Player Control Invokes
        if(Input.GetKeyDown(KeyCode.D))
        {
            OnMoveForward.Invoke();
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            OnMoveBackwards.Invoke();
        }
        #endregion Player Control Invokes
    }
}

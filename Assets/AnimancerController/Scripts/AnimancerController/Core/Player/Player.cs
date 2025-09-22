using Mirror;
using Animancer;
using UnityEngine;

[RequireComponent(typeof(AnimancerComponent))]
public class Player : CharacterBase
{
    public PlayerSO playerSO;
    public AnimancerComponent animancer { get; private set; }
    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerReusableData ReusableData { get; private set; }
    public PlayerReusableLogic ReusableLogic { get; private set; }
    public Transform camTransform { get; private set; }

    public InputService InputService { get; private set; }
    public TimerService TimerService { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        InputService = InputService.Instance;
        TimerService = TimerService.Instance;

        camTransform = Camera.main.transform;
        animancer = GetComponent<AnimancerComponent>();
        ReusableData = new PlayerReusableData(animancer, playerSO);
        ReusableLogic = new PlayerReusableLogic(this);
        StateMachine = new PlayerStateMachine(this);
        StateMachine.ChangeState(StateMachine.idleState);
    }
    
    private void Start()
    {
        if (!isLocalPlayer)
        {
            enabled = false;
        }
    }
    protected override void Update()
    {
        Debug.Log($"[{gameObject.name}] netId={netId} isLocalPlayer={isLocalPlayer} isServer={isServer}");
        base.Update();
        StateMachine?.OnUpdate();
    }
    protected override void OnAnimatorMove()
    {
        base.OnAnimatorMove();
        StateMachine?.OnAnimationUpdate();
    }
    public void AnimationEnd()
    {
        StateMachine?.OnAnimationEnd();
    }

}

using UnityEngine;
using UnityEngine.Rendering;

public class StateMachineBase
{
    public IState currentState;
    public IState lastState;
    
    public virtual void ChangeState(IState targetState)
    {
        currentState?.OnExit();
        lastState = currentState;
        currentState = targetState;
        currentState?.OnEnter();
    }
   
    public void OnAnimationEnd()
    {
        currentState.OnAnimationEnd();
    }
  
    public void OnUpdate()
    {
        currentState?.OnUpdate();
    }
    public void OnAnimationUpdate()
    {
        currentState?.OnAnimationUpdate();
    }

}

using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
    public class MoveTowardsTarget : ActionTask<Unit>
    {
        protected override string OnInit()
        {
            return null;
        }

        protected override void OnExecute()
        {
            agent.StartMoving();
        }

        protected override void OnUpdate()
        {
            if (agent.Position == agent.Target.Position)
                EndAction(true);

            agent.MoveTowardsTarget();
        }

        protected override void OnStop()
        {
            agent.Idle();
        }
    }
}
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
    public class MoveTowardsTarget : ActionTask<Unit>
    {
        [RequiredField] public BBParameter<ITargetable> TargetVariable;

        protected override string OnInit()
        {
            return null;
        }

        protected override void OnUpdate()
        {
            if (agent.Position == TargetVariable.value.Position)
                EndAction(true);

            agent.MoveTowardsTarget();
        }

        protected override void OnStop()
        {
            agent.Idle();
        }
    }
}
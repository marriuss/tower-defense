using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
    public class MoveTowardsTarget : ActionTask<Unit>
    {
        [RequiredField] public BBParameter<ITargetable> TargetVariable;

        private float _speed;

        protected override string OnInit()
        {
            _speed = agent.Stats.Speed;
            return null;
        }

        protected override void OnExecute()
        { 
            agent.StartMoving();
        }

        protected override void OnUpdate()
        {
            ITargetable target = TargetVariable.value;

            if (agent.Position == target.Position)
                EndAction(true);

            agent.MoveTo(Vector2.MoveTowards(agent.Position, target.Position, _speed * Time.deltaTime));
        }

        protected override void OnStop()
        {
            agent.Idle();
        }

        protected override void OnPause()
        {
        }
    }
}
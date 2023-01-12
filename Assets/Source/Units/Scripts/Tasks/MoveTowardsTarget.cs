using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
    public class MoveTowardsTarget : ActionTask<Unit>
    {
        [RequiredField] public BBParameter<ITargetable> TargetVariable;

        private ITargetable _target;
        private float _speed;

        protected override string OnInit()
        {
            _target = TargetVariable.value;
            _speed = agent.Stats.Speed;
            agent.StartMoving();
            return null;
        }

        protected override void OnExecute()
        {
        }

        protected override void OnUpdate()
        {
            if (agent.Position == _target.Position)
                EndAction(true);

            agent.MoveTo(Vector2.MoveTowards(agent.Position, _target.Position, _speed * Time.deltaTime));
        }

        protected override void OnStop()
        {
            agent.Stop();
        }

        protected override void OnPause()
        {
        }
    }
}
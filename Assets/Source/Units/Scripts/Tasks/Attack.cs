using UnityEngine;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Actions
{
    public class Attack : ActionTask<Unit>
    {
        [RequiredField] public BBParameter<ITargetable> Target;

        private ITargetable _target;
        private float _lastAttackTime;

        protected override string OnInit()
        {
            _target = Target.value;
            _lastAttackTime = 0;
            return null;
        }

        protected override void OnUpdate()
        {
            float time = Time.time;

            if (_lastAttackTime + agent.Stats.AttackDelay <= time)
            {
                _lastAttackTime = time;
                agent.Attack(_target);
            }
        }
    }
}
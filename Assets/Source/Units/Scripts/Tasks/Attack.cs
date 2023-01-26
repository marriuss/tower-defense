using UnityEngine;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Actions
{
    public class Attack : ActionTask<Unit>
    {
        private float _lastAttackTime;

        protected override string OnInit()
        {
            _lastAttackTime = 0;
            return null;
        }

        protected override void OnUpdate()
        {
            float time = Time.time;

            if (_lastAttackTime + agent.Stats.AttackDelay <= time)
            {
                _lastAttackTime = time;
                agent.AttackTarget();
            }
        }
    }
}
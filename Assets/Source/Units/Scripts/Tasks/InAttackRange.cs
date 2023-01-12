using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
    public class InAttackRange : ConditionTask<Unit>
    {
        [RequiredField] public BBParameter<ITargetable> Target;
        
        private float _attackRange;

        protected override string OnInit()
        {
            _attackRange = agent.Stats.AttackRange;
            return null;
        }

        protected override bool OnCheck()
        {
            return Vector2.Distance(agent.Position, Target.value.Position) < _attackRange;
        }
    }
}
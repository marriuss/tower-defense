using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
    public class InAttackRange : ConditionTask<Unit>
    {
        [RequiredField] public BBParameter<ITargetable> TargetVariable;

        protected override string OnInit()
        {
            return null;
        }

        protected override bool OnCheck()
        {
            return agent.TargetInRange;
        }
    }
}
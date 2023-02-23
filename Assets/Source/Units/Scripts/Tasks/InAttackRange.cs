using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
    public class InAttackRange : ConditionTask<Unit>
    {
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
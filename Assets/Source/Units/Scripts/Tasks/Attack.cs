using UnityEngine;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Actions
{
    public class Attack : ActionTask<Unit>
    {
        [RequiredField] public BBParameter<ITargetable> TargetVariable;

        protected override string OnInit()
        {
            return null;
        }

        protected override void OnUpdate()
        {
            agent.AttackTarget();
        }
    }
}
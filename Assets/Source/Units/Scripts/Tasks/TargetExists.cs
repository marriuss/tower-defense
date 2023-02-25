using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace NodeCanvas.Tasks.Conditions
{
    public class TargetExists : ConditionTask<Unit>
    {
        protected override string OnInit()
        {
            return null;
        }

        protected override bool OnCheck()
        {
            bool result = agent.Target != null;

            if (result)
                result &= !agent.Target.HealthState.IsDead;

            return result;
        }
    }
}
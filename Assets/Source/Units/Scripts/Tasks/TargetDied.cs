using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Conditions
{
    public class TargetDied : ConditionTask<Unit>
    {
        [RequiredField] public BBParameter<ITargetable> TargetVariable;

        protected override string OnInit()
        {
            return null;
        }

        protected override bool OnCheck()
        {
            return TargetVariable.value.HealthState.IsDead;
        }
    }
}
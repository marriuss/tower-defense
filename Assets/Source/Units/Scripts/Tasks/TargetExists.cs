using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace NodeCanvas.Tasks.Conditions
{
    public class TargetExists : ConditionTask<Unit>
    {
        public BBParameter<ITargetable> TargetVariable;

        protected override string OnInit()
        {
            return null;
        }

        protected override void OnEnable()
        {

        }

        protected override void OnDisable()
        {

        }

        protected override bool OnCheck()
        {
            bool result = !TargetVariable.isNoneOrNull;

            if (result)
                result &= !TargetVariable.value.HealthState.IsDead;

            return result;
        }
    }
}
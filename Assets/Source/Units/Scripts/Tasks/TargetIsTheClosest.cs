using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Conditions
{
    public class TargetIsTheClosest<T> : ConditionTask<Unit> where T : ITargetable
    {
        [RequiredField] public BBParameter<ITargetable> TargetVariable;

        protected override string OnInit()
        {
            return null;
        }

        protected override bool OnCheck()
        {
            return ReferenceEquals(TargetSelector.FindClosestTarget<T>(agent.Position), TargetVariable.value);
        }
    }
}
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Conditions
{
    public class TargetIsTheClosest<T> : ConditionTask<Unit> where T : ITargetable
    {
        protected override string OnInit()
        {
            return null;
        }

        protected override bool OnCheck()
        {
            return ReferenceEquals(TargetSelector.FindClosestTarget<T>(agent.Position), agent.Target);
        }
    }
}
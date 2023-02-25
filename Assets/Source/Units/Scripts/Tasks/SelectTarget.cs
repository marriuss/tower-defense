using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Actions
{
    public class SelectTarget<T> : ActionTask<Unit> where T : ITargetable
    {
        public BBParameter<ITargetable> TargetVariable;

        protected override string OnInit()
        {
            return null;
        }

        protected override void OnExecute()
        {
            T target = TargetSelector.FindClosestTarget<T>(agent.Position);
            TargetVariable.value = target;
            EndAction(!TargetVariable.isNoneOrNull);
        }
    }
}
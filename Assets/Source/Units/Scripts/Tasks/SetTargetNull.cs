using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Actions
{
    public class SetTargetNull : ActionTask<Unit>
    {
        public BBParameter<ITargetable> TargetVariable;

        protected override string OnInit()
        {
            return null;
        }

        protected override void OnExecute()
        {
            TargetVariable.value = null;
            EndAction(true);
        }
    }
}
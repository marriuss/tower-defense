using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Actions
{
    public class MoveTowardsTarget : ActionTask<Unit>
    {
        [RequiredField] public BBParameter<ITargetable> Target;

        protected override string OnInit()
        {
            return null;
        }

        protected override void OnExecute()
        {
            EndAction(true);
        }

        protected override void OnUpdate()
        {
        }

        protected override void OnStop()
        {
        }

        protected override void OnPause()
        {
        }
    }
}
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Actions
{
    public class Idle : ActionTask<Unit>
    {
        protected override string OnInit()
        {
            return null;
        }

        protected override void OnExecute()
        {
            agent.Idle();
            EndAction(true);
        }
    }
}
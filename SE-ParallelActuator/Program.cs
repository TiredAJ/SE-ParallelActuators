using Sandbox.ModAPI.Ingame;

using SpaceEngineers.Game.ModAPI.Ingame;
using VRageMath;

namespace IngameScript
{
    partial class Program : MyGridProgram
    {
        // This file contains your actual script.
        //
        // You can either keep all your code here, or you can create separate
        // code files to make your program easier to navigate while coding.
        //
        // In order to add a new utility class, right-click on your project, 
        // select 'New' then 'Add Item...'. Now find the 'Space Engineers'
        // category under 'Visual C# Items' on the left hand side, and select
        // 'Utility Class' in the main area. Name it in the box below, and
        // press OK. This utility class will be merged in with your code when
        // deploying your final script.
        //
        // You can also simply create a new utility class manually, you don't
        // have to use the template if you don't want to. Just do so the first
        // time to see what a utility class looks like.
        // 
        // Go to:
        // https://github.com/malware-dev/MDK-SE/wiki/Quick-Introduction-to-Space-Engineers-Ingame-Scripts
        //
        // to learn more about ingame scripts.

        private IMyArtificialMassBlock MA1, MA2, MA3;
        private string BlockNames = "AM_Beacon ";

        public Program()
        {
            // The constructor, called only once every session and
            // always before any other method is called. Use it to
            // initialize your script. 
            //     
            // The constructor is optional and can be removed if not
            // needed.
            // 
            // It's recommended to set Runtime.UpdateFrequency 
            // here, which will allow your script to run itself without a 
            // timer block.

            MA1 = GridTerminalSystem.GetBlockWithName($"{BlockNames}1")
                    as IMyArtificialMassBlock;
            MA2 = GridTerminalSystem.GetBlockWithName($"{BlockNames}2")
                    as IMyArtificialMassBlock;
            MA3 = GridTerminalSystem.GetBlockWithName($"{BlockNames}3")
                    as IMyArtificialMassBlock;
        }

        public void Main(string argument, UpdateType updateSource)
        {
            var Distance = Vector3.Distance(MA1.GetPosition(), MA2.GetPosition());


        }
    }
}

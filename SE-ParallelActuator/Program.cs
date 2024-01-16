﻿using Sandbox.ModAPI.Ingame;

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

        private IMyArtificialMassBlock AM_AB, AM_BC, AM_CA;
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

            AM_AB = GridTerminalSystem.GetBlockWithName("AM-AB")
                    as IMyArtificialMassBlock;
            AM_BC = GridTerminalSystem.GetBlockWithName("AM-BC")
                    as IMyArtificialMassBlock;
            AM_CA = GridTerminalSystem.GetBlockWithName("AM-CA")
                    as IMyArtificialMassBlock;
        }

        public void Main(string argument, UpdateType updateSource)
        {



            var A_Distance = Vector3.Distance(AM_AB.GetPosition(), AM_CA.GetPosition());

            var B_Distance = Vector3.Distance(AM_AB.GetPosition(), AM_BC.GetPosition());

            var C_Distance = Vector3.Distance(AM_BC.GetPosition(), AM_CA.GetPosition());

            Echo($"A: {A_Distance}, B: {B_Distance}, C: {C_Distance}");
        }
    }
}

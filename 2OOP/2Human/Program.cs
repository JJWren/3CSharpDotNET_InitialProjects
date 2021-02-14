using System;

namespace Human
{
    class Program
    {
        static void Main(string[] args)
        {
            Human DefaultH = new Human();
            DefaultH.GetInfo();

            Wizard DefaultW = new Wizard("WizardD");
            DefaultW.GetInfo();

            Ninja DefaultN = new Ninja("NinjaD");
            DefaultN.GetInfo();

            Samurai DefaultS = new Samurai("SamuraiD");
            DefaultS.GetInfo();

            // Gandalf TrueWizard = new Gandalf();
            // TrueWizard.GetInfo();

            DefaultN.Steal(DefaultH);
            DefaultH.GetInfo();
            DefaultN.GetInfo();
            DefaultW.Heal(DefaultH);
            DefaultH.GetInfo();
        }
    }
}

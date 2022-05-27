using System;
using CoffeeMaker;

namespace M4CoffeeMaker
{
	public class M4ContainmentVessel : ContainmentVessel
		                             , Pollable
	{
		private CoffeeMakerAPI api;
		private bool isBrewing = false;

		public M4ContainmentVessel(CoffeeMakerAPI api)
		{
			this.api = api;
		}

        public override bool IsReady()
        {
			WarmerPlateStatus status = api.GetWarmerPlateStatus();
			return status == WarmerPlateStatus.POT_EMPTY;
        }

        public override void Start()
        {
			isBrewing = true;
        }

		public void Poll() { }
    }
}


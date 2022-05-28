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

		public void Poll()
		{
			WarmerPlateStatus potStatus = api.GetWarmerPlateStatus();

			if (isBrewing)
			{
				HandleBrewingEvent(potStatus);
			}
		}

		private void HandleBrewingEvent(WarmerPlateStatus potStatus)
		{
			if (potStatus == WarmerPlateStatus.POT_NOT_EMPTY)
			{
				ContainerAvailable();
				api.SetWarmerState(WarmerState.ON);
			}
			else if (potStatus == WarmerPlateStatus.WARMER_EMPTY)
			{
				ContainerUnavailable();
				api.SetWarmerState(WarmerState.OFF);
			}
			else
			{   // potStatus == POT_EMPTY
				ContainerAvailable();
				api.SetWarmerState(WarmerState.OFF);
			}
		}
    }
}


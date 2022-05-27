using System;
using CoffeeMaker;

namespace M4CoffeeMaker
{
	public class M4UserInterface : UserInterface
								 , Pollable
	{
		private CoffeeMakerAPI api;

		public M4UserInterface(CoffeeMakerAPI api)
		{
			this.api = api;
		}

		public void Poll()
		{
			BrewButtonStatus status = api.GetBrewButtonStatus();
			if (status == BrewButtonStatus.PUSHED)
			{
				StartBrewing();
			}
		}
	}
}


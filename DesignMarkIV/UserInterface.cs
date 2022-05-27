using System;
namespace CoffeeMaker
{
	public class UserInterface
	{
		private HotWaterSource hws;
		private ContainmentVessel cv;

		public void Init(HotWaterSource hws, ContainmentVessel cv)
		{
			this.hws = hws;
			this.cv = cv;
		}

		public void Done() { }
		public void Complete() { }
		protected void StartBrewing()
		{
			if (hws.IsReady() && cv.IsReady())
			{
				hws.Start();
				cv.Start();
			}
		}
	}
}


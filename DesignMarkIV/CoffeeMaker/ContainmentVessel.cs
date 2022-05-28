using System;
namespace CoffeeMaker
{
	public abstract class ContainmentVessel
	{
		private UserInterface ui;
		private HotWaterSource hws;

		public void Init(UserInterface ui, HotWaterSource hws)
		{
			this.ui = ui;
			this.hws = hws;
		}

		public abstract bool IsReady();
		public abstract void Start();
		public void Done() { }

		protected void ContainerAvailable()
		{
			hws.Resume();
		}

		protected void ContainerUnavailable()
		{
			hws.Pause();
		}
	}
}


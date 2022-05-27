using System;
namespace CoffeeMaker
{
	public abstract class HotWaterSource
	{
		private UserInterface ui;
		private ContainmentVessel cv;

		public void Init(UserInterface ui, ContainmentVessel cv)
		{
			this.ui = ui;
			this.cv = cv;
		}

		public abstract bool IsReady();
		public abstract void Start();
		public void Pause() { }
		public void Resume() { }
		public void Done() { }
	}
}


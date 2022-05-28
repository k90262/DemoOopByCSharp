using System;
using CoffeeMaker;

namespace M4CoffeeMaker
{
	public class M4HotWaterSource : HotWaterSource
		                          , Pollable
	{
		private CoffeeMakerAPI api;

		public M4HotWaterSource(CoffeeMakerAPI api)
		{
			this.api = api;
		}

		public override bool IsReady()
		{
			BoilerStatus status = api.GetBoilerStatus();
			return status == BoilerStatus.NOT_EMPTY;
		}

        public override void Start()
        {
			api.SetReleifValveState(ReliefValveState.CLOSED);
			api.SetBoilerState(BoilerState.ON);
		}

		public void Poll()
		{
		}

        public override void Pause()
        {
			api.SetBoilerState(BoilerState.OFF);
			api.SetReleifValveState(ReliefValveState.OPEN);
        }

        public override void Resume()
        {
			api.SetBoilerState(BoilerState.ON);
			api.SetReleifValveState(ReliefValveState.CLOSED);
        }

        public override void Done()
        {
            
        }
    }
}


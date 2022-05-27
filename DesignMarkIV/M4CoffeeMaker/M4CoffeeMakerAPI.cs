using System;
using CoffeeMaker;

namespace M4CoffeeMaker
{
	public class M4CoffeeMakerAPI : CoffeeMakerAPI
	{
		public M4CoffeeMakerAPI()
		{
		}

        public BoilerStatus GetBoilerStatus()
        {
            throw new NotImplementedException();
        }

        public BrewButtonStatus GetBrewButtonStatus()
        {
            throw new NotImplementedException();
        }

        public WarmerPlateStatus GetWarmerPlateStatus()
        {
            throw new NotImplementedException();
        }

        public void SetBoilerState(BoilerState s)
        {
            throw new NotImplementedException();
        }

        public void SetIndicatorSstate(IndicatorState s)
        {
            throw new NotImplementedException();
        }

        public void SetReleifValveState(ReliefValveState s)
        {
            throw new NotImplementedException();
        }

        public void SetWarmerState(WarmerState s)
        {
            throw new NotImplementedException();
        }
    }
}


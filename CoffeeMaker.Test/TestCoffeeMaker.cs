using NUnit.Framework;
using M4CoffeeMaker;

namespace CoffeeMaker.Test
{
    internal class CoffeeMakerStub : CoffeeMakerAPI
    {
        public bool buttonPressed;
        public bool boilerOn;
        public bool lightOn;
        public bool plateOn;
        public bool valveClosed;
        public bool boilerEmpty;
        public bool potPresent;
        public bool potNotEmpty;

        public CoffeeMakerStub()
        {
            buttonPressed = false;
            lightOn = false;
            boilerOn = false;
            valveClosed = true;
            plateOn = false;
            boilerEmpty = true;
            potPresent = true;
            potNotEmpty = false;
        }

        public WarmerPlateStatus GetWarmerPlateStatus()
        {
            if (!potPresent)
                return WarmerPlateStatus.WARMER_EMPTY;
            else if (potNotEmpty)
                return WarmerPlateStatus.POT_NOT_EMPTY;
            else
                return WarmerPlateStatus.POT_EMPTY;
        }

        public BoilerStatus GetBoilerStatus()
        {
            return boilerEmpty ?
                BoilerStatus.EMPTY : BoilerStatus.NOT_EMPTY;
        }

        public BrewButtonStatus GetBrewButtonStatus()
        {
            if (buttonPressed)
            {
                buttonPressed = false;
                return BrewButtonStatus.PUSHED;
            }
            else
            {
                return BrewButtonStatus.NOT_PUSHED;
            }
        }

        public void SetBoilerState(BoilerState boilerState)
        {
            boilerOn = boilerState == BoilerState.ON;
        }

        public void SetWarmerState(WarmerState warmerState)
        {
            plateOn = warmerState == WarmerState.ON;
        }

        public void SetIndicatorState(IndicatorState indicatorState)
        {
            lightOn = indicatorState == IndicatorState.ON;
        }

        public void SetReleifValveState(ReliefValveState reliefValveState)
        {
            valveClosed = reliefValveState == ReliefValveState.CLOSED;
        }
    }

    [TestFixture]
    public class TestCoffeeMaker
    {
        private M4UserInterface ui;
        private M4HotWaterSource hws;
        private M4ContainmentVessel cv;
        private CoffeeMakerStub api;

        [SetUp]
        public void Setup()
        {
            api = new CoffeeMakerStub();
            ui = new M4UserInterface(api);
            hws = new M4HotWaterSource(api);
            cv = new M4ContainmentVessel(api);
            ui.Init(hws, cv);
            hws.Init(ui, cv);
            cv.Init(ui, hws);
        }

        private void Poll()
        {
            ui.Poll();
            hws.Poll();
            cv.Poll();
        }

        [Test]
        public void InitialConditions()
        {
            Poll();
            Assert.IsFalse(api.boilerOn);
            Assert.IsFalse(api.lightOn);
            Assert.IsFalse(api.plateOn);
            Assert.IsTrue(api.valveClosed);
        }

        [Test]
        public void StartNotPot()
        {
            Poll();
            api.buttonPressed = true;
            api.potPresent = false;
            Poll();
            Assert.IsFalse(api.boilerOn);
            Assert.IsFalse(api.lightOn);
            Assert.IsFalse(api.plateOn);
            Assert.IsTrue(api.valveClosed);
        }


        [Test]
        public void StartNotWater()
        {
            Poll();
            api.buttonPressed = true;
            api.boilerEmpty = true;
            Poll();
            Assert.IsFalse(api.boilerOn);
            Assert.IsFalse(api.lightOn);
            Assert.IsFalse(api.plateOn);
            Assert.IsTrue(api.valveClosed);
        }

        [Test]
        public void GoodStart()
        {
            NormalStart();
            Assert.IsTrue(api.boilerOn);
            Assert.IsFalse(api.lightOn);
            Assert.IsFalse(api.plateOn);
            Assert.IsTrue(api.valveClosed);
        }

        private void NormalStart()
        {
            Poll();
            api.boilerEmpty = false;
            api.buttonPressed = true;
            Poll();
        }

        [Test]
        public void StartedPotNotEmpty()
        {
            NormalStart();
            api.potNotEmpty = true;
            Poll();
            Assert.IsTrue(api.boilerOn);
            Assert.IsFalse(api.lightOn);
            Assert.IsTrue(api.plateOn);
            Assert.IsTrue(api.valveClosed);
        }

        [Test]
        public void PotRemovedAndReplacedWhileEmpty()
        {
            NormalStart();
            api.potPresent = false;
            Poll();
            Assert.IsFalse(api.boilerOn);
            Assert.IsFalse(api.lightOn);
            Assert.IsFalse(api.plateOn);
            Assert.IsFalse(api.valveClosed);

            api.potPresent = true;
            Poll();
            Assert.IsTrue(api.boilerOn);
            Assert.IsFalse(api.lightOn);
            Assert.IsFalse(api.plateOn);
            Assert.IsTrue(api.valveClosed);
        }

        [Test]
        public void PotRemovedWhileNotEmptyAndReplacedEmpty()
        {
            NormalFill();
            api.potPresent = false;
            Poll();
            Assert.IsFalse(api.boilerOn);
            Assert.IsFalse(api.lightOn);
            Assert.IsFalse(api.plateOn);
            Assert.IsFalse(api.valveClosed);

            api.potPresent = true;
            api.potNotEmpty = false;
            Poll();
            Assert.IsTrue(api.boilerOn);
            Assert.IsFalse(api.lightOn);
            Assert.IsFalse(api.plateOn);
            Assert.IsTrue(api.valveClosed);
        }

        private void NormalFill()
        {
            NormalStart();
            api.potNotEmpty = true;
            Poll();
        }

        [Test]
        public void PotRemovedWhileNotEmptyAndReplacedNotEmpty()
        {
            NormalFill();
            api.potPresent = false;
            Poll();
            api.potPresent = true;
            Poll();
            Assert.IsTrue(api.boilerOn);
            Assert.IsFalse(api.lightOn);
            Assert.IsTrue(api.plateOn);
            Assert.IsTrue(api.valveClosed);
        }

        [Test]
        public void BoilerEmptyPotNotEmpty()
        {
            NormalBrew();
            Assert.IsFalse(api.boilerOn);
            Assert.IsTrue(api.lightOn);
            Assert.IsTrue(api.plateOn);
            Assert.IsTrue(api.valveClosed);
        }

        private void NormalBrew()
        {
            NormalFill();
            api.boilerEmpty = true;
            Poll();
        }

    }
}

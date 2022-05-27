using System;
namespace CoffeeMaker
{
	public enum WarmerPlateStatus
	{
		WARMER_EMPTY,
		POT_EMPTY,
		POT_NOT_EMPTY
	};

	public enum BoilerStatus
	{
		EMPTY, NOT_EMPTY
	};

	public enum BrewButtonStatus
	{
		PUSHED, NOT_PUSHED
	};

	public enum BoilerState
	{
		ON, OFF
	};

	public enum WarmerState
	{
		ON, OFF
	};

	public enum IndicatorState
	{
		ON, OFF
	};

	public enum ReliefValveState
	{
		OPEN, CLOSED
	};

	public interface CoffeeMakerAPI
	{
		/*
		 * 這個函式回傳保溫盤感測器的狀況。
		 * 感測器檢查有沒有壺，壺中有沒有咖啡。
		 */

		WarmerPlateStatus GetWarmerPlateStatus();

		/*
		 * 這個函式回傳加熱器開關的狀況。
		 * 加熱器開關是浮動的，確保加熱器中至少有半杯水。
		 */

		BoilerStatus GetBoilerStatus();

		/*
		 * 這個函式回傳沖煮按鈕的狀況。
		 * 沖煮按鈕是一個瞬時性開關，可以記住自己的狀態。
		 * 每次呼叫這個函式都會回傳記憶的狀態，
		 * 然後將該狀態重置為 NOT_PUSHED。
		 * 
		 * 因此，即便以非常慢的速度輪詢這函式，
		 * 仍舊可以在沖煮按鈕被按下時正確被偵測。
		 */

		BrewButtonStatus GetBrewButtonStatus();

		/*
		 * 這函式負責開、關加熱器中的加熱元件。
		 */

		void SetBoilerState(BoilerState s);

		/*
		 * 這函式負責開、關保溫盤中的元件。
		 */

		void SetWarmerState(WarmerPlateStatus s);

		/*
		 * 這函式負責開、關指示燈。
		 * 沖煮完成時，燈亮；使用者按下沖煮按鈕時，燈滅。
		 */

		void SetIndicatorSstate(IndicatorState s);

		/*
		 * 這函式負責開、關減壓閥。
		 * 關閉減壓閥時，加熱器中的壓力使熱水灑在咖啡濾水器上。
		 * 打開減壓閥時，加熱器中的蒸氣排到外部，
		 * 加熱器中的水不會再噴到濾水器上。
		 */

		void SetReleifValveState(ReliefValveState s);
	}
}


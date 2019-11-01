using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Estecka.ChainMaths {
	public static class FloatExtension{
		/// <summary>
		/// Clamps this value between a maximum and a minimum.
		/// </summary>
		/// <param name="value">The value to be clamped</param>
		/// <param name="min">The minimum value to return</param>
		/// <param name="max">The maximum value to return</param>
		static public float Clamp(this float value, float min, float max){
			if (min>max)
				throw new System.InvalidOperationException();
			return 
				value < min ? min:
				value > max ? max:
				value;
		}

		/// <summary>
		/// Wraps this value between a maximum and a minimum. 
		/// E.g: 370 wrapped between 0 and 360 returns 10.
		/// </summary>
		public static float Wrap (this float value, float min, float max){
			float range = max-min; 
			while (value < min)
				value += range;
			while (value > max)
				value -= range;
			return value;
		}

		/// <summary>
		/// Clamps this float to the given maximum value.
		/// </summary>
		/// <param name="value">The value to be clamped</param>
		/// <param name="max">The maximum value to return</param>
		/// <returns>Min(value, max)</returns>
		static public float CeilTo(this float value, float max){
			return value > max ? max : value;
		}

		/// <summary>
		/// Clamps this float to the given minimum value.
		/// </summary>
		/// <param name="value">The value to be clamped</param>
		/// <param name="min">The minimum value to return</param>
		/// <returns>Max(value, min)</returns>
		static public float FloorTo(this float value, float min){
			return value < min ? min : value;
		}

		/// <summary>
		/// Remap a value from a Range I to a Range O.
		/// </summary>
		/// <returns>oMin + ( (value-iMin)*(oMax-oMin)/(iMax-iMin) )</returns>
		/// <param name="value">Value to remap</param>
		/// <param name="iMin">Lower bound of the input range</param>
		/// <param name="iMax">Upper bound of the input range</param>
		/// <param name="oMin">Lower bound of the output range</param>
		/// <param name="oMax">Upper bound of the output range</param>
		public static float Remap(this float value, float iMin, float iMax, float oMin, float oMax){
			value -= iMin;
			value *= (oMax-oMin) / (iMax-iMin);
			value += oMin;
			return value;
		}

		/// <summary>
		/// Set the sign of this float.
		/// </summary>
		/// <param name="me">Me</param>
		/// <param name="sign">the sign applied to the float. 0 is considered Positive</param>
		static public float SetSign (this float me, float sign){
			return Mathf.Abs (me) * Mathf.Sign (sign);
		}//


		public static float AntiLerpA(float b, float t, float lerp){
			return (lerp - b*t) / (1-t);
		}
		public static float AntiLerpB(float a, float t, float lerp){
			return (lerp - a*(1-t)) / t;
		}

	} // END Extension
} // END Namespace
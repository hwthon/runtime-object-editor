using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SerializableModelEditor
{
	public static class StringExtension
	{
		/// <summary>
		/// Int型に変換する
		/// 変換に失敗した場合はdefaultValueを使う
		/// </summary>
		public static int ToInt(this string text, int defaultValue = 0)
		{
			int intValue = 0;

			if (!string.IsNullOrEmpty(text))
			{
				bool success = int.TryParse(text, out intValue);
				if (!success)
				{
					return defaultValue;
				}
			}

			return intValue;
		}

		/// <summary>
		/// Float型に変換する
		/// 変換に失敗した場合はdefaultValueを使う
		/// </summary>
		public static float ToFloat(this string text, float defaultValue = 0f)
		{
			float floatValue = 0f;

			if (!string.IsNullOrEmpty(text))
			{
				bool success = float.TryParse(text, out floatValue);
				if (!success)
				{
					return defaultValue;
				}
			}

			return floatValue;
		}
	}
}
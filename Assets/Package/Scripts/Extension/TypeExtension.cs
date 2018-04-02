using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace RuntimeObjectEditor
{
	public static class TypeExtension
	{
		public static IEnumerable<FieldInfo> GetSerializableFields(this System.Type type)
		{
			foreach (FieldInfo fieldInfo in type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
			{
				if (CanSerialize(fieldInfo))
				{
					yield return fieldInfo;
				}
			}
		}

		private static bool CanSerialize(FieldInfo fieldInfo)
		{
			if (fieldInfo.IsPublic)
			{
				return true;
			}

			var attributes = fieldInfo.GetCustomAttributes(typeof(SerializeField), false);
			return (attributes != null && attributes.Length > 0);
		}
	}
}
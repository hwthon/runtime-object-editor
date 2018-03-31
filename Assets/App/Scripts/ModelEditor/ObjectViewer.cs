using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace SerializableModelEditor
{
	public class ObjectViewer : MonoBehaviour
	{
		private ObjectViewer _parent;

		private int _indent;

		public void Initialize(object model, ObjectViewer parent = null)
		{
			_parent = parent;
			_indent = CalculateIndent();
			A(model);
		}

		private void A(object model)
		{
			foreach (FieldInfo fieldInfo in model.GetType().GetFields())
			{
				// if (fieldInfo.FieldType == typeof(string))
				{
					GameObject field = Instantiate(Resources.Load<GameObject>("Fields/Field"));

					field.transform.SetParent(transform);
				}
			}
		}

		/// <summary>
		/// インデントの計算
		/// </summary>
		public int CalculateIndent()
		{
			if (_parent == null)
			{
				return 0;
			}
			return _parent.CalculateIndent() + 1;
		}
	}
}
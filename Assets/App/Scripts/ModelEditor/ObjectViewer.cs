using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace SerializableModelEditor
{
	public class ObjectViewer
	{
		private object _model;

		private ObjectViewer _parent;

		private int _indent;

		public void Initialize(object model, ObjectViewer parent = null)
		{
			_model = model;
			_parent = parent;
			_indent = CalculateIndent();
			// A(model);
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

		public void OnGUI()
		{
			foreach (FieldInfo fieldInfo in _model.GetType().GetFields())
			{
				FieldViewer fieldViewer = FieldFactory.Create(_model, fieldInfo);
				if (fieldViewer == null)
				{
					Debug.LogWarning("field viewer is null.");
					continue;
				}

				fieldViewer.OnGUI();
			}
		}
	}
}
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace SerializableModelEditor
{
	public class FieldViewer
	{
		protected object _model;
		protected FieldInfo _fieldInfo;

		public FieldViewer(object model, FieldInfo fieldInfo)
		{
			_model = model;
			_fieldInfo = fieldInfo;
		}

		public virtual void OnGUI()
		{
			if (_model == null || _fieldInfo == null)
			{
				return;
			}
			
			using(new GUILayout.HorizontalScope())
			{
				GUILayout.Label(_fieldInfo.Name);
				GUILayout.TextField(_fieldInfo.GetValue(_model).ToString());
			}
		}
	}
}
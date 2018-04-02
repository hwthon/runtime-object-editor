using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace RuntimeObjectEditor
{
	public class ObjectFieldViewer : FieldViewer
	{
		private int Indent { get { return Parents; } }

		private bool _foldout = true;

		private List<Viewer> _viewers;

		public ObjectFieldViewer(object model, FieldInfo fieldInfo) : base(model, fieldInfo)
		{
			_model = fieldInfo == null ? model : fieldInfo.GetValue(model);
			_viewers = new List<Viewer>();

			foreach (FieldInfo _fieldInfo in _model.GetType().GetSerializableFields())
			{
				Viewer viewer = ViewerFactory.I.Create(this, _model, _fieldInfo);
				if (viewer == null)
				{
					Debug.LogWarning("viewer is null.");
					continue;
				}

				_viewers.Add(viewer);
			}
		}

		public static bool Available(System.Type type)
		{
			// TODO: not list
			return type.IsClass && type.GetSerializableFields().ToArray().Length > 0;
		}

		public override void OnGUI()
		{
			// TODO: field名が欲しい
			if (_parent != null)
			{
				using(new FieldScope(false))
				{
					if (GUILayout.Button(_foldout ? "▼" : "▶︎", GUILayout.ExpandWidth(false)))
					{
						_foldout = !_foldout;
					}
					GUILayout.Label(_model.GetType().Name);
				}
			}

			if (_foldout)
			{
				using(new IndentScope(Indent))
				{
					foreach (Viewer viewer in _viewers)
					{
						viewer.OnGUI();
					}
				}
			}
		}
	}
}
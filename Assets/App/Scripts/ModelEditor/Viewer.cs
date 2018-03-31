using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.UI;

namespace SerializableModelEditor
{
	public class Viewer : MonoBehaviour
	{
		private ObjectViewer _viewer = new ObjectViewer();

		public void Show(object model)
		{
			// _root.Initialize(model);
			_viewer.Initialize(model);
		}

		private void OnGUI()
		{
			using(new GUILayout.AreaScope(new Rect(0f, 0f, Screen.width, Screen.height)))
			{
				_viewer.OnGUI();
			}
		}
	}
}

/**

Viewer.Show(model);
viewer.onclose?
viewer.onsaved??
いる？

objectのメンバーを辿っていく



*/
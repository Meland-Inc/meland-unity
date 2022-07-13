using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

namespace Gen90Software.Tools
{
	public class TerrainAdjust : EditorWindow
	{
		public enum BlendType
		{
			None,
			Min,
			Max
		}

		public enum OverMaxAngleType
		{
			None,
			Clamp,
			Flat
		}

		private const float radiusMin = 0.1f;
		private const float radiusMax = 50.0f;
		private const float falloffMin = 0.01f;
		private const float falloffMax = 0.99f;
		private const float spacingMin = 0.01f;
		private const float spacingMax = 2.0f;
		private const float maxAngleMin = 10.0f;
		private const float maxAngleMax = 80.0f;
		private const float offsetYMin = -1.0f;
		private const float offsetYMax = 1.0f;
		private const string version = "1.0.2";


		private float radius = 3.0f;
		private float falloff = 0.6f;
		private float spacing = 0.5f;
		private float maxAngle = 60.0f;
		private float offsetY = -0.01f;
		private BlendType blend = BlendType.None;
		private OverMaxAngleType overMaxAngle = OverMaxAngleType.None;
		private LayerMask targetMask = ~0;
		private float maxDistance = 1000.0f;
		private bool excludeTerrains = true;


		private Terrain tRender;
		private TerrainData tData;
		private TerrainCollider tCollider;
		private bool paintActive;
		private AnimationCurve brushCurve;
		private Vector3 adjustPos;
		private Vector3 adjustNormal;
		private Vector3 lastAdjustPos;


		private Vector2 viewScroll;
		private bool foldoutBrush;
		private bool foldoutTarget;
		private bool foldoutSettings;
		private Vector2 shortcutMousePos;


		#region INITIALIZATION
		[MenuItem("Tools/Gen90Software/Terrain Adjust")]
		public static void InitTerrainAdjustWindow ()
		{
			TerrainAdjust ta = GetWindow<TerrainAdjust>();
			ta.titleContent.text = "Terrain Adjust";
			ta.Show();

			ta.viewScroll = Vector2.zero;
			ta.foldoutBrush = true;
			ta.foldoutTarget = true;
			ta.foldoutSettings = false;
		}

		public void OnEnable ()
		{
			SceneView.duringSceneGui += OnSceneGUI;
			InitTerrainConnect();
		}

		public void OnDisable ()
		{
			SceneView.duringSceneGui -= OnSceneGUI;
		}

		public void OnUndoRedo ()
		{
			if (tData)
			{
				tData.SyncHeightmap();
			}

			Repaint();
		}
		#endregion

		#region MAIN
		public void OnGUI ()
		{
			if (!tRender || !tData || !tCollider)
			{
				EditorGUILayout.Space(10);
				tRender = (Terrain) EditorGUILayout.ObjectField("Terrain", tRender, typeof(Terrain), true);

				if (tRender == null)
				{
					EditorGUILayout.Space(10);
					EditorGUILayout.HelpBox("No Terrain connected!", MessageType.Warning);
					return;
				}

				InitTerrainConnect();

				if (tData == null)
				{
					EditorGUILayout.Space(10);
					EditorGUILayout.HelpBox("Terrain Data not available on the target Terrain! Try to fix your Terrain in Debug mode, or select another one!", MessageType.Error);
					return;
				}

				if (tCollider == null)
				{
					EditorGUILayout.Space(10);
					EditorGUILayout.HelpBox("No Terrain Collider component attached to the target Terrain!", MessageType.Warning);
					if (GUILayout.Button("Add Terrain Collider"))
					{
						FixTerrainConnect();
					}
					return;
				}
			}

			//PAINT AREA
			EditorGUILayout.Space(10);
			paintActive = GUILayout.Toggle(paintActive, "Paint", new GUIStyle("Button") { font = EditorStyles.boldFont, fontSize = 14 }, GUILayout.MinHeight(30));

			//SCROLL VIEW START
			EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
			viewScroll = EditorGUILayout.BeginScrollView(viewScroll);
			EditorGUI.BeginChangeCheck();

			//BRUSH AREA
			foldoutBrush = EditorGUILayout.BeginFoldoutHeaderGroup(foldoutBrush, "Brush");
			if (foldoutBrush)
			{
				radius = EditorGUILayout.Slider(new GUIContent("        Radius", "Set the brush radius in meters."), radius, radiusMin, radiusMax);
				falloff = EditorGUILayout.Slider(new GUIContent("        Falloff", "Set the fall of the brush relative to the Radius."), falloff, falloffMin, falloffMax);
				spacing = EditorGUILayout.Slider(new GUIContent("        Spacing", "Set the brush stroke frequency in meters."), spacing, spacingMin, spacingMax);
				maxAngle = EditorGUILayout.Slider(new GUIContent("        Max Angle", "Limits the maximum working angle of the brush."), maxAngle, maxAngleMin, maxAngleMax);
				offsetY = EditorGUILayout.Slider(new GUIContent("        Vertical Offset", "Offset the brush adjust height in meters."), offsetY, offsetYMin, offsetYMax);
			}
			EditorGUILayout.EndFoldoutHeaderGroup();

			//BLEND AREA
			EditorGUILayout.Space(10);
			EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
			GUILayout.Label(new GUIContent("Blend", "Limit the blending of height adjust.\n\nNone:\tOverride height.\nMin:\tSet height if original higher.\nMax:\tSet height if original lower."), EditorStyles.boldLabel);
			blend = (BlendType) GUILayout.Toolbar((int) blend, System.Enum.GetNames(typeof(BlendType)));

			//ANGLE AREA
			EditorGUILayout.Space(10);
			EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
			GUILayout.Label(new GUIContent("Over Max Angle", "Set behavior of angle limitation.\n\nNone:\tForbid the brush usage.\nClamp:\tChange angle to maximum allowed.\nFlat:\tChange angle to zero."), EditorStyles.boldLabel);
			overMaxAngle = (OverMaxAngleType) GUILayout.Toolbar((int) overMaxAngle, System.Enum.GetNames(typeof(OverMaxAngleType)));

			//TARGET AREA
			EditorGUILayout.Space(10);
			EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
			foldoutTarget = EditorGUILayout.BeginFoldoutHeaderGroup(foldoutTarget, "Target");
			if (foldoutTarget)
			{
				targetMask = InternalEditorUtility.ConcatenatedLayersMaskToLayerMask(EditorGUILayout.MaskField(new GUIContent("        Target Mask", "Masking the target collider selection."), InternalEditorUtility.LayerMaskToConcatenatedLayersMask(targetMask), InternalEditorUtility.layers));
				maxDistance = EditorGUILayout.FloatField(new GUIContent("        Max Distance", "Limit the distance of the target collider selection in meters."), maxDistance);
				excludeTerrains = EditorGUILayout.Toggle(new GUIContent("        Exclude Terrains", "Exclude Terrain Collider type from selection."), excludeTerrains);
			}
			EditorGUILayout.EndFoldoutHeaderGroup();

			//SETTINGS AREA
			EditorGUILayout.Space(10);
			EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
			foldoutSettings = EditorGUILayout.BeginFoldoutHeaderGroup(foldoutSettings, "Settings");
			if (foldoutSettings)
			{
				tRender = (Terrain) EditorGUILayout.ObjectField("        Terrain", tRender, typeof(Terrain), true);
				tData = (TerrainData) EditorGUILayout.ObjectField("        Data", tData, typeof(TerrainData), false);
				tCollider = (TerrainCollider) EditorGUILayout.ObjectField("        Collider", tCollider, typeof(TerrainCollider), true);
				EditorGUILayout.Space(20);
				EditorGUILayout.LabelField("        Version: " + version);
			}
			EditorGUILayout.EndFoldoutHeaderGroup();

			//END CHECK
			EditorGUILayout.Space(20);
			if (EditorGUI.EndChangeCheck())
			{
				maxDistance = Mathf.Max(maxDistance, 1.0f);
			}
			EditorGUILayout.EndScrollView();

			//HELP AREA
			EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
			EditorGUILayout.HelpBox("Radius:\tCtrl + Right Mouse + Horizontal move\nFalloff:\tCtrl + Right Mouse + Vertical move", MessageType.None);
			EditorGUILayout.Space(10);
		}

		public void OnSceneGUI (SceneView sceneView)
		{
			if (!paintActive)
				return;

			if (Event.current.type == EventType.Layout)
			{
				HandleUtility.AddDefaultControl(GUIUtility.GetControlID(GetHashCode(), FocusType.Passive));
			}

			Vector3 screenPosition = Event.current.mousePosition;
			screenPosition.y = Camera.current.pixelHeight - screenPosition.y;

			if (!new Rect(0, 0, Camera.current.pixelWidth, Camera.current.pixelHeight).Contains(screenPosition))
				return;

			if (Event.current.modifiers == EventModifiers.Control)
			{
				if (Event.current.type == EventType.MouseDown)
				{
					shortcutMousePos = Event.current.mousePosition;
				}

				if (Event.current.button == 1 && Event.current.type == EventType.MouseDrag)
				{
					Vector2 delta = ConstraitShortcutVector(shortcutMousePos, Event.current.mousePosition, Event.current.delta);
					radius = Mathf.Clamp(radius + delta.x * 0.02f, radiusMin, radiusMax);
					falloff = Mathf.Clamp(falloff - delta.y * 0.01f, falloffMin, falloffMax);
					Repaint();
					Event.current.Use();
				}

				DrawGizmo(true, adjustPos, adjustNormal);
				return;
			}

			RaycastHit hit;
			if (excludeTerrains)
			{
				if (!RaycastExcludeTerrain(Camera.current.ScreenPointToRay(screenPosition), out hit))
					return;
			}
			else
			{
				if (!RaycastIncludeTerrain(Camera.current.ScreenPointToRay(screenPosition), out hit))
					return;
			}

			adjustPos = hit.point;
			bool isAvailable = OverAngleCorrection(hit.normal, out adjustNormal);

			DrawGizmo(isAvailable, adjustPos, adjustNormal);

			if (Event.current.button == 0 && Event.current.type == EventType.MouseDown)
			{
				Undo.RegisterCompleteObjectUndo(tData, "Terrain Adjust");

				if (!isAvailable)
				{
					Event.current.Use();
					return;
				}

				AdjustHeight(adjustPos, adjustNormal);
				Event.current.Use();
			}

			if (Event.current.button == 0 && Event.current.type == EventType.MouseDrag)
			{
				if (!isAvailable || Vector3.Distance(adjustPos, lastAdjustPos) < spacing)
				{
					Event.current.Use();
					return;
				}

				AdjustHeight(adjustPos, adjustNormal);
				Event.current.Use();
			}
		}
		#endregion

		#region TERRAIN_CALCULATIONS
		private void AdjustHeight (Vector3 point, Vector3 normal)
		{
			brushCurve = new AnimationCurve(new Keyframe(0.0f, 1.0f), new Keyframe(falloff, 1.0f), new Keyframe(1.0f, 0.0f));

			Vector3 localPosMin = tRender.transform.InverseTransformPoint(point + new Vector3(-radius, 0.0f, -radius));
			Vector3 localPosMax = tRender.transform.InverseTransformPoint(point + new Vector3(radius, 0.0f, radius));

			Vector3 ratePosMin = new Vector3(
				Mathf.Clamp01(localPosMin.x / tData.size.x),
				Mathf.Clamp01(localPosMin.y / tData.size.y),
				Mathf.Clamp01(localPosMin.z / tData.size.z)
			);
			Vector3 ratePosMax = new Vector3(
				Mathf.Clamp01(localPosMax.x / tData.size.x),
				Mathf.Clamp01(localPosMax.y / tData.size.y),
				Mathf.Clamp01(localPosMax.z / tData.size.z)
			);

			Vector2Int coordMin = new Vector2Int(Mathf.FloorToInt(ratePosMin.x * tData.heightmapResolution), Mathf.FloorToInt(ratePosMin.z * tData.heightmapResolution));
			Vector2Int coordMax = new Vector2Int(Mathf.FloorToInt(ratePosMax.x * tData.heightmapResolution), Mathf.FloorToInt(ratePosMax.z * tData.heightmapResolution));

			int sizeX = coordMax.x - coordMin.x;
			int sizeY = coordMax.y - coordMin.y;

			float[,] heights = tData.GetHeights(coordMin.x, coordMin.y, sizeX, sizeY);

			for (int x = 0; x < sizeX; x++)
			{
				for (int y = 0; y < sizeY; y++)
				{
					heights[y, x] = EvaluateBrush(
						(coordMin.x + x) / (float) (tData.heightmapResolution - 1),
						(coordMin.y + y) / (float) (tData.heightmapResolution - 1),
						heights[y, x],
						point,
						normal
					);
				}
			}

			tData.SetHeights(coordMin.x, coordMin.y, heights);
			lastAdjustPos = point;
		}

		private float EvaluateBrush (float rateX, float rateY, float lastHeight, Vector3 point, Vector3 normal)
		{
			Vector3 realPos = tRender.transform.TransformPoint(new Vector3(rateX * tData.size.x, lastHeight * tData.size.y, rateY * tData.size.z));
			Vector3 vOriginal = new Vector3(realPos.x, 0.0f, realPos.z) - new Vector3(point.x, 0.0f, point.z);

			float heightX = Mathf.Tan(Mathf.Atan2(-normal.x, normal.y)) * vOriginal.x;
			float heightZ = Mathf.Tan(Mathf.Atan2(normal.z, normal.y)) * vOriginal.z;
			Vector3 vProjected = new Vector3(vOriginal.x, heightX - heightZ, vOriginal.z);

			float targetHeight = (point.y + vProjected.y + offsetY - tRender.transform.position.y) / tData.size.y;

			targetHeight = Mathf.Lerp(lastHeight, targetHeight, brushCurve.Evaluate(Mathf.Clamp01(vProjected.magnitude / radius)));

			if (blend == BlendType.Min)
				return Mathf.Min(lastHeight, targetHeight);

			if (blend == BlendType.Max)
				return Mathf.Max(lastHeight, targetHeight);

			return targetHeight;
		}
		#endregion

		#region GIZMOS
		private void DrawGizmo (bool enabled, Vector3 pos, Vector3 up)
		{
			Handles.color = enabled ? new Color(0.0f, 1.0f, 1.0f, 0.1f) : new Color(1.0f, 0.0f, 0.0f, 0.1f);
			Handles.DrawSolidDisc(pos, up, radius * falloff);
			Handles.color = enabled ? Color.cyan : Color.red;
			Handles.DrawWireDisc(pos, up, radius);
		}
		#endregion

		#region UTILITIES
		private void InitTerrainConnect ()
		{
			//Terrain
			if (tRender == null)
			{
				tRender = FindObjectOfType<Terrain>();
				if (tRender == null)
					return;
			}

			//Terrain data
			tData = tRender.terrainData;
			if (tData == null)
				return;

			//Terrain collider
			tCollider = tRender.GetComponent<TerrainCollider>();
			if (tCollider == null)
				return;

			tCollider.terrainData = tData;
			tCollider.enabled = true;
		}

		private void FixTerrainConnect ()
		{
			if (!tRender || !tData)
				return;

			tCollider = tRender.gameObject.AddComponent<TerrainCollider>();
			tCollider.terrainData = tData;
			tCollider.enabled = true;
		}

		private bool RaycastIncludeTerrain (Ray ray, out RaycastHit hit)
		{
			return Physics.Raycast(ray, out hit, maxDistance, targetMask);
		}

		private bool RaycastExcludeTerrain (Ray ray, out RaycastHit hit)
		{
			RaycastHit[] allHits = Physics.RaycastAll(ray, maxDistance, targetMask);

			if (allHits.Length == 0)
			{
				hit = new RaycastHit();
				return false;
			}

			int nearestIndex = -1;
			float nearestDistance = maxDistance;
			for (int i = 0; i < allHits.Length; i++)
			{
				if (allHits[i].collider == tCollider)
					continue;

				if (allHits[i].distance < nearestDistance)
				{
					nearestIndex = i;
					nearestDistance = allHits[i].distance;
				}
			}

			if (nearestIndex == -1)
			{
				hit = new RaycastHit();
				return false;
			}

			hit = allHits[nearestIndex];
			return true;
		}

		private bool OverAngleCorrection (Vector3 currentNormal, out Vector3 correctedNormal)
		{
			float currentAngle = Vector3.Angle(currentNormal, Vector3.up);

			if (overMaxAngle == OverMaxAngleType.Clamp)
			{
				if (currentAngle > maxAngle)
				{
					Quaternion currentRot = Quaternion.LookRotation(currentNormal, Vector3.forward);
					Quaternion targetRot = Quaternion.LookRotation (Vector3.up, Vector3.forward);
					correctedNormal = Quaternion.Slerp(targetRot, currentRot, maxAngle / currentAngle) * Vector3.forward;
					return true;
				}

				correctedNormal = currentNormal;
				return true;
			}

			if (overMaxAngle == OverMaxAngleType.Flat)
			{
				if (currentAngle > maxAngle)
				{
					correctedNormal = Vector3.up;
					return true;
				}

				correctedNormal = currentNormal;
				return true;
			}

			correctedNormal = currentNormal;
			return currentAngle <= maxAngle;
		}

		private Vector2 ConstraitShortcutVector (Vector2 start, Vector2 current, Vector2 delta)
		{
			Vector2 move = current - start;
			if (Mathf.Abs(move.x) > Mathf.Abs(move.y))
			{
				return new Vector2(delta.x, 0.0f);
			}
			else
			{
				return new Vector2(0.0f, delta.y);
			}
		}
		#endregion
	}
}
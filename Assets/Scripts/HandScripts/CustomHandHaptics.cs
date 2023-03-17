using UnityEngine;

namespace Manus.Haptics
{
	/// <summary>
	/// This is the class which needs to be on every hand with haptics in order for all the other haptic related components to function correctly.
	/// In order for the haptics to function each of the fingers on the hand will need a FingerHaptics class with the correct finger type set.
	/// The FingerHaptics will generate haptic values for this class to give to the hand.
	/// </summary>
	[DisallowMultipleComponent]
	[AddComponentMenu("Manus/Haptics/Hand (Haptics)")]
	public class CustomHandHaptics : MonoBehaviour
	{
		Hand.Hand m_Hand;
		FingerHaptics[] m_Fingers;
		
		//set on the lowest possible haptic feedback intensity
		private float _grabIntensity = 0.0315f;

		public bool RumbleActive {get; set;}

		void Start()
		{
			m_Hand = GetComponentInParent<Hand.Hand>();
			m_Fingers = GetComponentsInChildren<FingerHaptics>();
		}

		void FixedUpdate()
		{
			if (m_Hand.data == null) return;
			for (int i = 0; i < m_Fingers.Length; i++)
			{
				if(RumbleActive)
				{
					m_Hand.data.SetFingerHaptic(m_Fingers[i].fingerType, _grabIntensity);
				}
				else
				{
					m_Hand.data.SetFingerHaptic(m_Fingers[i].fingerType, m_Fingers[i].GetHapticValue());
				}
			}
		}

	}
}

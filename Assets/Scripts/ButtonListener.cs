using UnityEngine;

namespace Manus.InteractionScene
{
	/// <summary>
	/// This class is used in the Demo to reset interactable objects to their original positions.
	/// This code is purely demonstrational and probably does not have much use outside this specific scenario.
	/// </summary>
	//[AddComponentMenu("Manus/Interaction Scene/Resettable Interactable")]
	public class ButtonListener : MonoBehaviour
	{
		#region Fields & Properties

		#region Public Fields
		public Interaction.PushButton pushButton = null;
		#endregion // Public Fields

		protected Rigidbody m_RigidBody = null;

		#region Methods

		#region Unity Messages

		protected void Awake()
		{
			if (pushButton == null)
			{
				Debug.LogWarning($"No PushButton was given. This script needs one to function.");
				enabled = false;

				return;
			}

			m_RigidBody = GetComponent<Rigidbody>();
			if (m_RigidBody == null)
			{
				Debug.LogWarning($"No RigidBody was found. This script needs one to function.");
				enabled = false;

				return;
			}
		}

        #endregion

		protected virtual void OnEnable()
		{
			if (pushButton)
			{
				pushButton.onPressed += ReactToPushButtonEnabled;
			}
		}

		protected virtual void OnDisable()
		{
			if (pushButton)
			{
				pushButton.onPressed -= ReactToPushButtonEnabled;
			}
		}

		#endregion // Unity Messages

		#region Protected Methods

		protected void ReactToPushButtonEnabled(Interaction.PushButton p_Button)
		{
            this.transform.position = this.transform.parent.position;
            this.transform.rotation = this.transform.parent.rotation;

			m_RigidBody.velocity = Vector3.zero;
			m_RigidBody.angularVelocity = Vector3.zero;
		}

		protected void ReactToPushButtonDisabled(Interaction.PushButton p_Button)
		{

		}

		#endregion // Protected Methods

		#endregion // Methods
	}
}
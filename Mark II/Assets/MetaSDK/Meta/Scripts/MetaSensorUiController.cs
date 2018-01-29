using UnityEngine;

namespace Meta
{
    /// <summary>
    /// Wraps Unity-related UI and provides an interface to change the messages of the UI. 
    /// </summary>
    public class MetaSensorUiController
    {
        public const string SensorFailurePrefabName = "Prefabs/SensorFailureUi";
        private MetaSensorMessageController _controller;

        private string _majorMessage = string.Empty;
        private string _minorMessage = string.Empty;

        /// <summary>
        /// Constructs the instance and sets the UI as a sibling of the transform passed.
        /// </summary>
        /// <param name="parent"></param>
        public MetaSensorUiController(Transform parent)
        {
            _controller = CreateMessageUi();
            _controller.transform.SetParent(parent);
            _controller.gameObject.SetActive(false);
        }

        public bool IsVisible()
        {
            return _controller.gameObject.activeSelf;
        }

        /// <summary>
        /// Changes the sensor message
        /// </summary>
        /// <param name="message"></param>
        public void ChangeMessage(string message)
        {
            if (message == null)
            {
                return;
            }

            _majorMessage = message;
            UpdateMessage();
        }

        /// <summary>
        /// Changes the minor sensor message
        /// </summary>
        /// <param name="message"></param>
        public void ChangeMinorMessage(string message)
        {
            if (message == null)
            {
                return;
            }

            _minorMessage = message;
            UpdateMessage();
        }


        /// <summary>
        /// Gets the message: a concatenation of the major and minor messages.
        /// </summary>
        /// <returns></returns>
        public string GetMessage()
        {
            return UpdateMessage();
        }

        private string UpdateMessage()
        {
            if (string.IsNullOrEmpty(_majorMessage) && string.IsNullOrEmpty(_minorMessage))
            {
                _controller.ChangeMessage(string.Empty);
                _controller.gameObject.SetActive(false);
                return string.Empty;
            }

            _controller.gameObject.SetActive(true);
            string messageConcat = _majorMessage;
            if (!string.IsNullOrEmpty(_majorMessage) && !string.IsNullOrEmpty(_minorMessage))
            {
                messageConcat += "\n\n";
            }

            messageConcat += _minorMessage;
            _controller.ChangeMessage(messageConcat);
            return messageConcat;
        }

        /// <summary>
        /// Creates the Message UI.
        /// </summary>
        /// <returns></returns>
        private MetaSensorMessageController CreateMessageUi()
        {
            GameObject ui = (GameObject)GameObject.Instantiate(Resources.Load(SensorFailurePrefabName));
            return ui.GetComponent<MetaSensorMessageController>();
        }

        /// <summary>
        /// Releases resources and cleans the instance.
        /// </summary>
        public void Destroy()
        {
            GameObject.DestroyImmediate(_controller.gameObject);
        }

    }
}



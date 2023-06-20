using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ObjectItemCreated : UnityEvent<GameObject> { };

[System.Serializable]
public class HealthChangeEvent : UnityEvent<float> { };

[System.Serializable]
public class HealthExpiredEvent : UnityEvent { };

[System.Serializable]
public class PlayerCollideEvent : UnityEvent<float> { };
[SerializeField]
public class GameOverEvent : UnityEvent { };

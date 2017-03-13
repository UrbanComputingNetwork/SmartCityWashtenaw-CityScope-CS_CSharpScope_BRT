using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class StateManager : Singleton<StateManager> {

	private int LastDelta = 0;

	public int Top;
    public int Middle;
    public int Bottom;

	[Serializable]
    public class StateInfo
    {
        public int Top;
        public int Middle;
        public int Bottom;

        public GameObject StateObject;
    }

    public GameObject ErrorState;
    public List<StateInfo> States;

    public GameObject currentState
    {
        get;
        private set;
    }

    private void AddUpdateRequest(int width, int height, Action handler)
    {
        Action<Dictionary<string, object>> reading = (json) =>
        {
            var update_dict = new Dictionary<int, int>();

            var newDelta = (int)(long)json["new_delta"];
            var grid = ((List<object>)json["grid"]).ConvertAll(b => b as Dictionary<string, object>);
            if (grid.Count == 0)
            {
                AddUpdateRequest(width, height, handler);
                return;
            }
            foreach (var cell in grid)
            {

                var y = (int)(long)cell["y"];
                var type = (int)(long)cell["type"];
                update_dict[y] = type;
            }
            Debug.Log(MiniJSON.Json.Serialize(json));
            
            if(update_dict.ContainsKey(0))
                Top = update_dict[0];
            if (update_dict.ContainsKey(5))
                Middle = update_dict[5];
            if (update_dict.ContainsKey(9))
                Bottom = update_dict[9];

            LastDelta = newDelta;

            handler();
        };

        var data = new Dictionary<string, object>()
        {
            { "delta", LastDelta }
        };

        TCPControllerJSON.Instance.AddRequest("get_updates", data, reading);
    }

    // Use this for initialization
    IEnumerator Start()
    {
        while (true)
        {
            bool done = false;
            AddUpdateRequest(1, 10, () => done = true);
            yield return new WaitWhile(() => !done);
            UpdateState();
        }
    }

    private void UpdateState()
    {
        Debug.LogFormat("Current State: {0} {1} {2}", Bottom, Middle, Top);
        foreach(var s in States)
        {
            if(Bottom == s.Bottom && Middle == s.Middle && Top == s.Top)
            {
                SwitchState(s.StateObject);
                return;
            }
        }
        SwitchState(ErrorState);
    }

    private void SwitchState(GameObject state)
    {
        if(currentState != null)
            Destroy(currentState);

        currentState = Instantiate(state) as GameObject;
        currentState.transform.SetParent(transform);

    }
		
}

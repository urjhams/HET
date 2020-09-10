using System;
using UnityEngine;

public enum TrialState {
    Eye, HeadEye
}

public static class Global
{
    public static TrialState currentState = TrialState.HeadEye;

    public class GameObjectPattern {
        public int[] order;
        public GameObject[] objects = new GameObject[4];
    }

    public class GameObjectPatternGroup {
        public GameObjectPattern[] patterns = 
        new GameObjectPattern[6] {
            new GameObjectPattern(),
            new GameObjectPattern(),
            new GameObjectPattern(),
            new GameObjectPattern(),
            new GameObjectPattern(),
            new GameObjectPattern(),
        };
    }
}

using System;
public enum TrialState {
    Eye, HeadEye
}

public static class Global
{
    public static TrialState currentState = TrialState.Eye;
}

﻿using Infrastructure.StateMachine;

namespace Monobehavior
{
    public interface IMenuButtonsHandler
    {
        public void Constructor(GameStateMachine gameStateMachine);
        public void LoadLevel(string levelName);
    }
}
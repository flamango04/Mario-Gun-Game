using Sprint_2.Sprites;
using Sprint_2.Interfaces;
using Sprint_2.Sound;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint_2;
using Sprint_2.GameStates;
using System.Diagnostics;

public class PauseCommand : ICommands
{
    //private IUpdateable oldGameState;

    public void Execute()
    {   
        // Switch between Pause and Playing state
        SoundManager.Instance.PlaySoundEffect("pause");

        if (Game1.Instance.gameState.GetType() == typeof(PausedState) )
        {
            MediaPlayer.Resume();
            Game1.Instance.gameState = new PlayableState(Game1.Instance.GetKeyboardControl());
        }
        else
        {
            MediaPlayer.Pause();
            Game1.Instance.gameState = new PausedState(Game1.Instance.GetKeyboardControl());
        }
    }
}

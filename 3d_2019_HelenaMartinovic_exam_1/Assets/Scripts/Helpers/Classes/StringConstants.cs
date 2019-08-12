using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StringConstants
{
    public static class Prefabs{
        public const string Player  = "Player/Player";
        public const string Mashroom = "Enemy/Mashroom";
        public const string Turtle = "Enemy/Turtle";
        public const string Fireball = "Player/Pokeball";
    }

    public static class Audio{
        public const string Jump = "Sound/Jump";
        public const string Coin = "Sound/Coin";
        public const string GameOver = "Sound/GameOver";
        public const string Fireball = "Sound/Fireball";
        public const string PowerupAppear = "Sound/Powerup_appear";
        public const string PowerupPickup = "Sound/Powerup_pickup";
        public const string Stomp = "Sound/Stomp";
        public const string EnterLevel = "Sound/EnterLevel";

        public const string AudioSourceObject = "EffectAudio";
    }

    public static class SceneObjects{
        public const string MashroomSpawnPoints = "env/mashroomSpawns";
        public const string TurtleSpawnPoints = "env/turtleSpawns";

        public const string CanvasScore = "LevelPrefab/Canvas/txtScore";
        public const string CanvasHearths = "LevelPrefab/Canvas/txtHearths";
    }

    public static class AnimatorEvents{
        public const string FadeOut  = "FadeOut";
    }

    public static class BtnUI{
        public const string Exit = "Canvas/btnExit";
        public const string Again = "Canvas/btnAgain";
    }
}

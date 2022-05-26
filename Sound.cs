using System.Media;

namespace SoulKnight
{
    static class Sound
    {
        static SoundPlayer soundMenu = new SoundPlayer(Properties.Resources.sound_menu);
        static SoundPlayer soundBattle = new SoundPlayer(Properties.Resources.sound_battle);

        static bool soundEnabled = true;

        public static void Sound_on()
        {
            soundEnabled = true;
        }
        public static void Sound_off()
        {
            soundEnabled = false;
        }
        public static void Play_sound_battle()
        {
            if (soundEnabled)
                soundBattle.PlayLooping();
        }
        public static void Play_menu()
        {
            if (soundEnabled)
                soundMenu.PlayLooping();
        }
        public static void DontPlayInMenu()
        {
            soundMenu.Stop();
        }
    }
}
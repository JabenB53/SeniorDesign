using Unity.Audio;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource menuMusic;
    public AudioSource levelMusic;
    public AudioSource victoryMusic;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject); // this manager will persist throughout scenes
        menuMusic.Play(); // start the game with the menu music
    }

    private void OnLevelWasLoaded(int level)
    {
        if (level == 0 && !menuMusic.isPlaying) // if the current scene is the main menu and the theme isn't playing
        {
            levelMusic.Stop(); // stop any other music that's playing
            victoryMusic.Stop();

            menuMusic.Play(); // play the menu music on a loop
            menuMusic.loop = true;
        }

        if (level != 0 && level != 21 && !levelMusic.isPlaying) // if the current scene is one of the levels and the theme isn't playing
        {
            menuMusic.Stop(); // stop any other music that's playing
            victoryMusic.Stop();

            levelMusic.Play(); // play the level music on a loop
            levelMusic.loop = true;
        }

        if (level ==21 && !victoryMusic.isPlaying) // if the current scene is the end credits and the theme isn't playing
        {
            levelMusic.Stop(); // stop any other music that's playing
            menuMusic.Stop();

            victoryMusic.Play(); // play the victory music
            victoryMusic.loop = false;
        }
    }

}

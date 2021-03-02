using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using KModkit;

public class MssngvWls : MonoBehaviour {

    public KMBombInfo Bomb;
    public KMAudio Audio;
    public TextMesh Text;

    public KMSelectable[] Vowels;
    public KMSelectable CycleButton;

    public SpriteRenderer[] Hieroglyphics;
    public Sprite[] Glyphs;

    int[] Shuffler = {0, 1, 2, 3, 4, 5};
    int[] AnswerButtons = new int[5];
    int ForbiddenNumber;

    static int moduleIdCounter = 1;
    int moduleId;
    private bool moduleSolved;

    void Awake () {
        moduleId = moduleIdCounter++;

        foreach (KMSelectable Vowel in Vowels) {
            Vowel.OnInteract += delegate () { VButton(Vowel); return false; };
        }

        CycleButton.OnInteract += delegate () { Cycle(); return false; };
    }

    void VButton (KMSelectable Vowel) {
      Vowel.AddInteractionPunch();
      Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, Vowel.transform);
      for (int i = 0; i < 5; i++) {
        if (Vowel == Vowels[i]) {
          if (AnswerButtons[i] == ForbiddenNumber) {
            GetComponent<KMBombModule>().HandlePass();
            Audio.PlaySoundAtTransform("Solve", Vowel.transform);
          }
          else {
            GetComponent<KMBombModule>().HandleStrike();
          }
        }
      }
    }

    void Cycle () {
      CycleButton.AddInteractionPunch();
      Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, CycleButton.transform);
      string TargetModule = WordGenerator();
      string TempModuleName = "";
      for (int i = 0; i < TargetModule.Length; i++) {
        if ("ñbcdfghjklmnpqrstvwxyz".Contains(TargetModule[i].ToString().ToLower())) {
          TempModuleName += TargetModule[i];
        }
      }
      TempModuleName = TempModuleName.Replace(" ", "").ToUpper();
      TargetModule = "";
      for (int i = 0; i < TempModuleName.Length; i++) {
        TargetModule += TempModuleName[i].ToString();
        if (UnityEngine.Random.Range(0, 100) <= 33) {
          TargetModule += " ";
        }
      }
      Text.text = TargetModule;
      Debug.LogFormat("[Mssngv Wls #{0}] The module shows this as {1}.", moduleId, TargetModule);
    }

    void Start () {
      ForbiddenNumber = UnityEngine.Random.Range(0, 5);
      Debug.LogFormat("[Mssngv Wls #{0}] The missing vowel is {1}.", moduleId, "AEIOU"[ForbiddenNumber]);
      Shuffler.Shuffle();
      for (int i = 0; i < 5; i++) {
        Hieroglyphics[i].GetComponent<SpriteRenderer>().sprite = Glyphs[Shuffler[i]];
      }
      switch (Shuffler[5]) {
        case 0:
        for (int i = 0; i < 5; i++) {
          switch (Shuffler[i]) {
            case 0:
            //AnswerButtons[i]
            break;
            case 1:
            AnswerButtons[i] = 4;
            break;
            case 2:
            AnswerButtons[i] = 0;
            break;
            case 3:
            AnswerButtons[i] = 1;
            break;
            case 4:
            AnswerButtons[i] = 3;
            break;
            case 5:
            AnswerButtons[i] = 2;
            break;
          }
        }
        Debug.LogFormat("[Mssngv Wls #{0}] The missing hieroglyphic is Twisted Flax. Buttons are arranged {1}{2}{3}{4}{5}.", moduleId, "AEIOU"[AnswerButtons[0]], "AEIOU"[AnswerButtons[1]], "AEIOU"[AnswerButtons[2]], "AEIOU"[AnswerButtons[3]], "AEIOU"[AnswerButtons[4]]);
        break;
        case 1:
        for (int i = 0; i < 5; i++) {
          switch (Shuffler[i]) {
            case 0:
            AnswerButtons[i] = 0;
            break;
            case 1:
            //AnswerButtons[i] = 0;
            break;
            case 2:
            AnswerButtons[i] = 2;
            break;
            case 3:
            AnswerButtons[i] = 3;
            break;
            case 4:
            AnswerButtons[i] = 1;
            break;
            case 5:
            AnswerButtons[i] = 4;
            break;
          }
        }
        Debug.LogFormat("[Mssngv Wls #{0}] The missing hieroglyphic is the Eye of Horus. Buttons are arranged {1}{2}{3}{4}{5}.", moduleId, "AEIOU"[AnswerButtons[0]], "AEIOU"[AnswerButtons[1]], "AEIOU"[AnswerButtons[2]], "AEIOU"[AnswerButtons[3]], "AEIOU"[AnswerButtons[4]]);
        break;
        case 2:
        for (int i = 0; i < 5; i++) {
          switch (Shuffler[i]) {
            case 0:
            AnswerButtons[i] = 1;
            break;
            case 1:
            AnswerButtons[i] = 0;
            break;
            case 2:
            //AnswerButtons[i] = 0;
            break;
            case 3:
            AnswerButtons[i] = 2;
            break;
            case 4:
            AnswerButtons[i] = 4;
            break;
            case 5:
            AnswerButtons[i] = 3;
            break;
          }
        }
        Debug.LogFormat("[Mssngv Wls #{0}] The missing hieroglyphic are the Two Reeds. Buttons are arranged {1}{2}{3}{4}{5}.", moduleId, "AEIOU"[AnswerButtons[0]], "AEIOU"[AnswerButtons[1]], "AEIOU"[AnswerButtons[2]], "AEIOU"[AnswerButtons[3]], "AEIOU"[AnswerButtons[4]]);
        break;
        case 3:
        for (int i = 0; i < 5; i++) {
          switch (Shuffler[i]) {
            case 0:
            AnswerButtons[i] = 4;
            break;
            case 1:
            AnswerButtons[i] = 3;
            break;
            case 2:
            AnswerButtons[i] = 1;
            break;
            case 3:
            //AnswerButtons[i] = 4;
            break;
            case 4:
            AnswerButtons[i] = 2;
            break;
            case 5:
            AnswerButtons[i] = 0;
            break;
          }
        }
        Debug.LogFormat("[Mssngv Wls #{0}] The missing hieroglyphic is the Lion. Buttons are arranged {1}{2}{3}{4}{5}.", moduleId, "AEIOU"[AnswerButtons[0]], "AEIOU"[AnswerButtons[1]], "AEIOU"[AnswerButtons[2]], "AEIOU"[AnswerButtons[3]], "AEIOU"[AnswerButtons[4]]);
        break;
        case 4:
        for (int i = 0; i < 5; i++) {
          switch (Shuffler[i]) {
            case 0:
            AnswerButtons[i] = 4;
            break;
            case 1:
            AnswerButtons[i] = 2;
            break;
            case 2:
            AnswerButtons[i] = 3;
            break;
            case 3:
            AnswerButtons[i] = 0;
            break;
            case 4:
            //AnswerButtons[i] = 2;
            break;
            case 5:
            AnswerButtons[i] = 1;
            break;
          }
        }
        Debug.LogFormat("[Mssngv Wls #{0}] The missing hieroglyphic is the Viper. Buttons are arranged {1}{2}{3}{4}{5}.", moduleId, "AEIOU"[AnswerButtons[0]], "AEIOU"[AnswerButtons[1]], "AEIOU"[AnswerButtons[2]], "AEIOU"[AnswerButtons[3]], "AEIOU"[AnswerButtons[4]]);
        break;
        case 5:
        for (int i = 0; i < 5; i++) {
          switch (Shuffler[i]) {
            case 0:
            AnswerButtons[i] = 2;
            break;
            case 1:
            AnswerButtons[i] = 3;
            break;
            case 2:
            AnswerButtons[i] = 1;
            break;
            case 3:
            AnswerButtons[i] = 4;
            break;
            case 4:
            AnswerButtons[i] = 0;
            break;
            case 5:
            //AnswerButtons[i] = 1;
            break;
          }
        }
        Debug.LogFormat("[Mssngv Wls #{0}] The missing hieroglyphic is the Water. Buttons are arranged {1}{2}{3}{4}{5}.", moduleId, "AEIOU"[AnswerButtons[0]], "AEIOU"[AnswerButtons[1]], "AEIOU"[AnswerButtons[2]], "AEIOU"[AnswerButtons[3]], "AEIOU"[AnswerButtons[4]]);
        break;
      }
      Cycle();
    }

    string WordGenerator () {
      string ChosenWords = "";
      if (ForbiddenNumber == 0) {
        do {
          ChosenWords = ModuleNames.NoAs[UnityEngine.Random.Range(0, ModuleNames.NoAs.Length)];
        } while (!(ChosenWords.Any(x => "ABCDEFGHIJKLMNOPQRSTUVWXYZ".Contains(x))));
      }
      else if (ForbiddenNumber == 1) {
        do {
          ChosenWords = ModuleNames.NoEs[UnityEngine.Random.Range(0, ModuleNames.NoEs.Length)];
        } while (!(ChosenWords.Any(x => "ABCDEFGHIJKLMNOPQRSTUVWXYZ".Contains(x))));
      }
      else if (ForbiddenNumber == 2) {
        do {
          ChosenWords = ModuleNames.NoIs[UnityEngine.Random.Range(0, ModuleNames.NoIs.Length)];
        } while (!(ChosenWords.Any(x => "ABCDEFGHIJKLMNOPQRSTUVWXYZ".Contains(x))));
      }
      else if (ForbiddenNumber == 3) {
        do {
          ChosenWords = ModuleNames.NoOs[UnityEngine.Random.Range(0, ModuleNames.NoOs.Length)];
        } while (!(ChosenWords.Any(x => "ABCDEFGHIJKLMNOPQRSTUVWXYZ".Contains(x))));
      }
      else if (ForbiddenNumber == 4) {
        do {
          ChosenWords = ModuleNames.NoUs[UnityEngine.Random.Range(0, ModuleNames.NoUs.Length)];
        } while (!(ChosenWords.Any(x => "ABCDEFGHIJKLMNOPQRSTUVWXYZ".Contains(x))));
      }
      Debug.LogFormat("[Mssngv Wls #{0}] The current module is {1}.", moduleId, ChosenWords);
      return ChosenWords;
    }

    #pragma warning disable 414
    private readonly string TwitchHelpMessage = @"Use !{0} 1/2/3/4/5 to press the button from left to right.";
    #pragma warning restore 414

    IEnumerator ProcessTwitchCommand (string Command) {
      yield return null;
      if (Command.Length != 1 || !"12345".Contains(Command)) {
        yield return "sendtochaterror I don't understand!";
        yield break;
      }
      else {
        Vowels[int.Parse(Command) - 1].OnInteract();
      }
    }

    IEnumerator TwitchHandleForcedSolve () {
      for (int i = 0; i < 5; i++) {
        if (AnswerButtons[i] == ForbiddenNumber) {
          Vowels[i].OnInteract();
          yield return new WaitForSecondsRealtime(.1f);
        }
      }
    }
}

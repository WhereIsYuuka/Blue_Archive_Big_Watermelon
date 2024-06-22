using System;
using System.Collections.Generic;
using System.Reflection;

public class Globals
{
    // public const string FX2_1_1 = "Sounds/SFX/小桃/1";
    // public const string FX2_1_2 = "Sounds/SFX/小桃/2";
    // public const string FX2_2_1 = "Sounds/SFX/小桃/dead";

    // public const string FX3_1_1 = "Sounds/SFX/柚子/1";
    // public const string FX3_1_2 = "Sounds/SFX/柚子/2";
    // public const string FX3_2_1 = "Sounds/SFX/柚子/dead";

    // public const string FX4_1_1 = "Sounds/SFX/爱丽丝/1";
    // public const string FX4_1_2 = "Sounds/SFX/爱丽丝/2";
    // public const string FX4_1_3 = "Sounds/SFX/爱丽丝/3";
    // public const string FX4_2_1 = "Sounds/SFX/爱丽丝/dead";

    // public const string FX5_1_1 = "Sounds/SFX/小雪/1";
    // public const string FX5_2_1 = "Sounds/SFX/小雪/dead";
    // public const string FX6_1_1 = "Sounds/SFX/邮箱/1";
    // public const string Fx6_1_2 = "Sounds/SFX/邮箱/2";
    // public const string FX6_1_3 = "Sounds/SFX/邮箱/3";
    // public const string FX6_1_4 = "Sounds/SFX/邮箱/4";
    // public const string FX6_1_5 = "Sounds/SFX/邮箱/5";
    // public const string FX6_1_6 = "Sounds/SFX/邮箱/6";
    // public const string FX6_1_7 = "Sounds/SFX/邮箱/7";
    // public const string FX6_1_8 = "Sounds/SFX/邮箱/8";
    // public const string FX6_1_9 = "Sounds/SFX/邮箱/9";
    // public const string FX6_1_10 = "Sounds/SFX/邮箱/10";
    // public const string FX6_1_11 = "Sounds/SFX/邮箱/11";
    // public const string FX6_1_12 = "Sounds/SFX/邮箱/12";
    // public const string FX6_1_13 = "Sounds/SFX/邮箱/13";
    // public const string FX6_1_14 = "Sounds/SFX/邮箱/14";

    // public const string FX7_1_1 = "Sounds/SFX/诺亚/1";

    // public const string FX8_1_1 = "Sounds/SFX/遥香/1";
    // public const string FX8_1_2 = "Sounds/SFX/遥香/2";

    // public const string FX9_1_1 = "Sounds/SFX/佳代子/1";
    // public const string FX9_1_2 = "Sounds/SFX/佳代子/2";

    // public const string FX10_1_1 = "Sounds/SFX/阿露/1";
    // public const string FX10_1_2 = "Sounds/SFX/阿露/2";

    // public const string FX11_1_1 = "Sounds/SFX/睦月/1";
    // public const string FX11_1_2 = "Sounds/SFX/睦月/2";
    // public const string FX11_1_3 = "Sounds/SFX/睦月/3";
    public static readonly Dictionary<string, string[]> SoundEffects = new Dictionary<string, string[]>
    {
        { "2", new[] { "Sounds/SFX/小桃/1", "Sounds/SFX/小桃/2" } },
        { "2_2", new[] { "Sounds/SFX/小桃/dead" } },
        { "3", new[] { "Sounds/SFX/柚子/1", "Sounds/SFX/柚子/2" } },
        { "3_2", new[] { "Sounds/SFX/柚子/dead" } },
        { "4", new[] { "Sounds/SFX/爱丽丝/1", "Sounds/SFX/爱丽丝/2", "Sounds/SFX/爱丽丝/3", "Sounds/SFX/爱丽丝/dead" } },
        { "4_2", new[] { "Sounds/SFX/爱丽丝/dead" } },
        { "5", new[] { "Sounds/SFX/小雪/1" } },
        { "5_2", new[] { "Sounds/SFX/小雪/dead" } },
        { "6", new[] { "Sounds/SFX/邮箱/1", "Sounds/SFX/邮箱/2", "Sounds/SFX/邮箱/3", "Sounds/SFX/邮箱/4", "Sounds/SFX/邮箱/5", "Sounds/SFX/邮箱/6", "Sounds/SFX/邮箱/7", "Sounds/SFX/邮箱/8", "Sounds/SFX/邮箱/9", "Sounds/SFX/邮箱/10", "Sounds/SFX/邮箱/11", "Sounds/SFX/邮箱/12", "Sounds/SFX/邮箱/13", "Sounds/SFX/邮箱/14" } },
        { "6_2", new[] { "Sounds/SFX/邮箱/10" } },
        { "7", new[] { "Sounds/SFX/诺亚/1" } },
        { "8", new[] { "Sounds/SFX/遥香/1", "Sounds/SFX/遥香/2" } },
        { "9", new[] { "Sounds/SFX/佳代子/1", "Sounds/SFX/佳代子/2" } },
        { "10", new[] { "Sounds/SFX/阿露/1", "Sounds/SFX/阿露/2" } },
        { "11", new[] { "Sounds/SFX/睦月/1", "Sounds/SFX/睦月/2", "Sounds/SFX/睦月/3" } }
    };

    public static string GetRandomSoundEffect(string key)
    {
        if (SoundEffects.ContainsKey(key))
        {
            string[] soundEffects = SoundEffects[key];
            Random random = new Random();
            int index = random.Next(0, soundEffects.Length);
            return soundEffects[index];
        }
        else
        {
            return null;
        }
    }
}

public class FXCount
{
    public const int FX2 = 2;
    public const int FX3 = 2;
    public const int FX4 = 3;
    public const int FX5 = 1;
    public const int FX6 = 14;
    public const int FX7 = 1;
    public const int FX8 = 2;
    public const int FX9 = 2;
    public const int FX10 = 2;
    public const int FX11 = 3;

    public static int GetFXCount(int tag)
    {
        switch (tag)
        {
            case 2: return FX2;
            case 3: return FX3;
            case 4: return FX4;
            case 5: return FX5;
            case 6: return FX6;
            case 7: return FX7;
            case 8: return FX8;
            case 9: return FX9;
            case 10: return FX10;
            case 11: return FX11;
            default: return 0;
        }
    }
}

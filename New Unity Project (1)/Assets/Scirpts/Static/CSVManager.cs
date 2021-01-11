using UnityEngine;
using System.IO;

public static class CSVManager {

    private static string reportDirectoryName = "Report";
    private static string reportFileName = "report.csv";
    private static string reportSeparator = ",";
    private static string M4reportFileName = "M4report.csv";
    private static string T34reportFileName = "T34report.csv";
    private static string T72reportFileName = "T72report.csv";
    private static string SMKreportFileName = "SMKreport.csv";
    private static string TOS1reportFileName = "TOS1report.csv";
    private static string MinereportFileName = "Minereport.csv";
    private static string TigerreportFileName = "Tigerreport.csv";
    private static string PanzerIIreportFileName = "PanzerIIreport.csv";
    private static string PlayerreportFileName = "Player.csv";
    private static string[] reportHeaders = new string[38] {
        "Team",
        "Name",
        "Health",
        "Damage Done",
        "Total Shots Hits",
        "Points Pathed",
        "Flee ounted",
        "Points 1 Passed",
        "Points 2 Passed",
        "Points 3 Passed",
        "Tank Type",
        "Tank Model",
        "Ricohet Power Picked Up",
        "Health Pack Used",
        "Ricohet Shells Hits",
        "Rockets Power Picked Up",
        "Rockets Hit",
        "Damage Done By Ricohet Shells",
        "Damage Done By Rockets ",
        "Damage Done By Missle",
        "Missles Hit",
        "kills",
        "Last Hit By",
        "Missle Ricohet Hit",
        "Damage Done By Missle Ricohet",
        "Damage Done By Missle Mine Globel",
        "Health Damage",
        "Health Damage By Mine Team",
        "Health Damage By Missle",
        "Health Damage By Missle Ric",
        "Health Damage By Richet",
        "Health Damage By Rocket Ric",
        "Health Damage By Rocket ",
        "Damage Done By Shell",
        "Health Damage By Shells",
        "Shells Hit ",
        "Spawn Time ",
        "Shots Fired"

    };

    private static string[] PlayerreportHeaders = new string[26] {
        "DamageDone",
        "DamageByRockets",
        "DamageByRichet",
        "DamgeByRocketRic",
        "DamageByMissle",
        "DamageBYMissleRic",
        "DamgeByMineTeam",
        "DamageBYMineGlobal",
        "RichetsShellhit",
        "ShotsHits",
        "LastHitby",
        "RocketsFiredHit",
        "MineTeamHit",
        "MissleRicHit",
        "MissleHit",
        "Kills",
        "HealthDamage",
        "HealthDamageByMineTeam",
        "HealthDamageByMissle",
        "HealthDamageByMissleRic",
        "HealthDamageByRichet",
        "HealthDamageByRocketRic",
        "HealthDamageByRockets",
        "HealthDamageByShells",
        "Spawntime",
        "Deathtime"
    };
    private static string timeStampHeader = "time stamp";

#region Interactions

    public static void AppendToReport(string[] strings) {
        VerifyDirectory();
        VerifyFile();
        using (StreamWriter sw = File.AppendText(GetFilePath())) {
            string finalString = "";
            for (int i = 0; i < strings.Length; i++) {
                if (finalString != "") {
                    finalString += reportSeparator;
                }
                finalString += strings[i];
            }
            finalString += reportSeparator + GetTimeStamp();
            sw.WriteLine(finalString);
        }
    }

    public static void CreateReportPlayer()
    {
        VerifyDirectoryPlayer();
        using (StreamWriter sw = File.CreateText(GetFilePathPlayer()))
        {
            string finalString = "";
            for (int i = 0; i < PlayerreportHeaders.Length; i++)
            {
                if (finalString != "")
                {
                    finalString += reportSeparator;
                }
                finalString += PlayerreportHeaders[i];
            }
            finalString += reportSeparator + timeStampHeader;
            sw.WriteLine(finalString);
        }
    }
public static void CreateReport()
    {
        VerifyDirectory();
        using (StreamWriter sw = File.CreateText(GetFilePath()))
        {
            string finalString = "";
            for (int i = 0; i < reportHeaders.Length; i++)
            {
                if (finalString != "")
                {
                    finalString += reportSeparator;
                }
                finalString += reportHeaders[i];
            }
            finalString += reportSeparator + timeStampHeader;
            sw.WriteLine(finalString);
        }
    }

    public static void PlayerAppendToReport(string[] strings)
    {
        VerifyDirectoryPlayer();
        VerifyFilePlayer();
        using (StreamWriter sw = File.AppendText(GetFilePathPlayer()))
        {
            string finalString = "";
            for (int i = 0; i < strings.Length; i++)
            {
                if (finalString != "")
                {
                    finalString += reportSeparator;
                }
                finalString += strings[i];
            }
            finalString += reportSeparator + GetTimeStamp();
            sw.WriteLine(finalString);
        }
    }


    static void VerifyDirectoryPlayer()
    {
        string dir = GetDirectoryPathPlayer();
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
    }

    static void VerifyFilePlayer()
    {
        string file = GetFilePathPlayer();
        if (!File.Exists(file))
        {
            CreateReport();
        }
    }

    static string GetDirectoryPathPlayer()
    {
        return Application.dataPath + "/" + reportDirectoryName;
    }

    static string GetFilePathPlayer()
    {
        return GetDirectoryPath() + "/" + PlayerreportFileName;
    }


    
    #endregion


    #region Operations

    static void VerifyDirectory() {
        string dir = GetDirectoryPath();
        if (!Directory.Exists(dir)) {
            Directory.CreateDirectory(dir);
        }
    }

    static void VerifyFile() {
        string file = GetFilePath();
        if (!File.Exists(file)) {
            CreateReport();
        }
    }

#endregion


#region Queries

    static string GetDirectoryPath() {
        return Application.dataPath + "/" + reportDirectoryName;
    }

    static string GetFilePath() {
        return GetDirectoryPath() + "/" + reportFileName;
    }

    static string GetTimeStamp() {
        return System.DateTime.UtcNow.ToString();
    }

    #endregion
    #region InteractionsM4
    public static void AppendToReportM4(string[] strings)
    {
        VerifyDirectoryM4();
        VerifyFileM4();
        using (StreamWriter sw = File.AppendText(GetFilePathM4()))
        {
            string finalString = "";
            for (int i = 0; i < strings.Length; i++)
            {
                if (finalString != "")
                {
                    finalString += reportSeparator;
                }
                finalString += strings[i];
            }
            finalString += reportSeparator + GetTimeStampM4();
            sw.WriteLine(finalString);
        }
    }

    public static void CreateReportM4()
    {
        VerifyDirectoryM4();
        using (StreamWriter sw = File.CreateText(GetFilePathM4()))
        {
            string finalString = "";
            for (int i = 0; i < reportHeaders.Length; i++)
            {
                if (finalString != "")
                {
                    finalString += reportSeparator;
                }
                finalString += reportHeaders[i];
            }
            finalString += reportSeparator + timeStampHeader;
            sw.WriteLine(finalString);
        }
    }

    #endregion
    #region Operations

    static void VerifyDirectoryM4()
    {
        string dir = GetDirectoryPathM4();
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
    }

    static void VerifyFileM4()
    {
        string file = GetFilePathM4();
        if (!File.Exists(file))
        {
            CreateReportM4();
        }
    }

    #endregion
    #region Queries

    static string GetDirectoryPathM4()
    {
        return Application.dataPath + "/" + reportDirectoryName;
    }

    static string GetFilePathM4()
    {
        return GetDirectoryPath() + "/" + M4reportFileName;
    }

    static string GetTimeStampM4()
    {
        return System.DateTime.UtcNow.ToString();
    }

    #endregion

    public static void AppendToReportT34(string[] strings)
    {
        VerifyDirectoryT34();
        VerifyFileT34();
        using (StreamWriter sw = File.AppendText(GetFilePathT34()))
        {
            string finalString = "";
            for (int i = 0; i < strings.Length; i++)
            {
                if (finalString != "")
                {
                    finalString += reportSeparator;
                }
                finalString += strings[i];
            }
            finalString += reportSeparator + GetTimeStamp();
            sw.WriteLine(finalString);
        }
    }

    public static void CreateReportT34()
    {
        VerifyDirectoryT34();
        using (StreamWriter sw = File.CreateText(GetFilePathT34()))
        {
            string finalString = "";
            for (int i = 0; i < reportHeaders.Length; i++)
            {
                if (finalString != "")
                {
                    finalString += reportSeparator;
                }
                finalString += reportHeaders[i];
            }
            finalString += reportSeparator + timeStampHeader;
            sw.WriteLine(finalString);
        }
    }

    static void VerifyDirectoryT34()
    {
        string dir = GetDirectoryPathT34();
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
    }

    static void VerifyFileT34()
    {
        string file = GetFilePathT34();
        if (!File.Exists(file))
        {
            CreateReportT34();
        }
    }


    static string GetDirectoryPathT34()
    {
        return Application.dataPath + "/" + reportDirectoryName;
    }

    static string GetFilePathT34()
    {
        return GetDirectoryPath() + "/" + T34reportFileName;
    }

    static string GetTimeStampT34()
    {
        return System.DateTime.UtcNow.ToString();
    }

    public static void AppendToReportT72(string[] strings)
    {
        VerifyDirectoryT72();
        VerifyFileT72();
        using (StreamWriter sw = File.AppendText(GetFilePathT72()))
        {
            string finalString = "";
            for (int i = 0; i < strings.Length; i++)
            {
                if (finalString != "")
                {
                    finalString += reportSeparator;
                }
                finalString += strings[i];
            }
            finalString += reportSeparator + GetTimeStamp();
            sw.WriteLine(finalString);
        }
    }

    public static void CreateReportT72()
    {
        VerifyDirectoryT72();
        using (StreamWriter sw = File.CreateText(GetFilePathT72()))
        {
            string finalString = "";
            for (int i = 0; i < reportHeaders.Length; i++)
            {
                if (finalString != "")
                {
                    finalString += reportSeparator;
                }
                finalString += reportHeaders[i];
            }
            finalString += reportSeparator + timeStampHeader;
            sw.WriteLine(finalString);
        }
    }

    static void VerifyDirectoryT72()
    {
        string dir = GetDirectoryPathT72();
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
    }

    static void VerifyFileT72()
    {
        string file = GetFilePathT72();
        if (!File.Exists(file))
        {
            CreateReportT72();
        }
    }


    static string GetDirectoryPathT72()
    {
        return Application.dataPath + "/" + reportDirectoryName;
    }

    static string GetFilePathT72()
    {
        return GetDirectoryPath() + "/" + T72reportFileName;
    }

    static string GetTimeStampT72()
    {
        return System.DateTime.UtcNow.ToString();
    }

    public static void AppendToReportSMK(string[] strings)
    {
        VerifyDirectorySMK();
        VerifyFileSMK();
        using (StreamWriter sw = File.AppendText(GetFilePathSMK()))
        {
            string finalString = "";
            for (int i = 0; i < strings.Length; i++)
            {
                if (finalString != "")
                {
                    finalString += reportSeparator;
                }
                finalString += strings[i];
            }
            finalString += reportSeparator + GetTimeStamp();
            sw.WriteLine(finalString);
        }
    }

    public static void CreateReportSMK()
    {
        VerifyDirectorySMK();
        using (StreamWriter sw = File.CreateText(GetFilePathSMK()))
        {
            string finalString = "";
            for (int i = 0; i < reportHeaders.Length; i++)
            {
                if (finalString != "")
                {
                    finalString += reportSeparator;
                }
                finalString += reportHeaders[i];
            }
            finalString += reportSeparator + timeStampHeader;
            sw.WriteLine(finalString);
        }
    }

    static void VerifyDirectorySMK()
    {
        string dir = GetDirectoryPathSMK();
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
    }

    static void VerifyFileSMK()
    {
        string file = GetFilePathSMK();
        if (!File.Exists(file))
        {
            CreateReportSMK();
        }
    }


    static string GetDirectoryPathSMK()
    {
        return Application.dataPath + "/" + reportDirectoryName;
    }

    static string GetFilePathSMK()
    {
        return GetDirectoryPath() + "/" + SMKreportFileName;
    }
    public static void AppendToReportTOS1(string[] strings)
    {
        VerifyDirectoryTOS1();
        VerifyFileTOS1();
        using (StreamWriter sw = File.AppendText(GetFilePathTOS1()))
        {
            string finalString = "";
            for (int i = 0; i < strings.Length; i++)
            {
                if (finalString != "")
                {
                    finalString += reportSeparator;
                }
                finalString += strings[i];
            }
            finalString += reportSeparator + GetTimeStamp();
            sw.WriteLine(finalString);
        }
    }

    public static void CreateReportTOS1()
    {
        VerifyDirectoryTOS1();
        using (StreamWriter sw = File.CreateText(GetFilePathTOS1()))
        {
            string finalString = "";
            for (int i = 0; i < reportHeaders.Length; i++)
            {
                if (finalString != "")
                {
                    finalString += reportSeparator;
                }
                finalString += reportHeaders[i];
            }
            finalString += reportSeparator + timeStampHeader;
            sw.WriteLine(finalString);
        }
    }

    static void VerifyDirectoryTOS1()
    {
        string dir = GetDirectoryPathTOS1();
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
    }

    static void VerifyFileTOS1()
    {
        string file = GetFilePathTOS1();
        if (!File.Exists(file))
        {
            CreateReportTOS1();
        }
    }


    static string GetDirectoryPathTOS1()
    {
        return Application.dataPath + "/" + reportDirectoryName;
    }

    static string GetFilePathTOS1()
    {
        return GetDirectoryPath() + "/" + TOS1reportFileName;
    }

    public static void AppendToReportMine(string[] strings)
    {
        VerifyDirectoryMine();
        VerifyFileMine();
        using (StreamWriter sw = File.AppendText(GetFilePathMine()))
        {
            string finalString = "";
            for (int i = 0; i < strings.Length; i++)
            {
                if (finalString != "")
                {
                    finalString += reportSeparator;
                }
                finalString += strings[i];
            }
            finalString += reportSeparator + GetTimeStamp();
            sw.WriteLine(finalString);
        }
    }

    public static void CreateReportMine()
    {
        VerifyDirectoryMine();
        using (StreamWriter sw = File.CreateText(GetFilePathMine()))
        {
            string finalString = "";
            for (int i = 0; i < reportHeaders.Length; i++)
            {
                if (finalString != "")
                {
                    finalString += reportSeparator;
                }
                finalString += reportHeaders[i];
            }
            finalString += reportSeparator + timeStampHeader;
            sw.WriteLine(finalString);
        }
    }

    static void VerifyDirectoryMine()
    {
        string dir = GetDirectoryPathMine();
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
    }

    static void VerifyFileMine()
    {
        string file = GetFilePathMine();
        if (!File.Exists(file))
        {
            CreateReportMine();
        }
    }


    static string GetDirectoryPathMine()
    {
        return Application.dataPath + "/" + reportDirectoryName;
    }

    static string GetFilePathMine()
    {
        return GetDirectoryPath() + "/" + MinereportFileName;
    }

    public static void AppendToReportTiger(string[] strings)
    {
        VerifyDirectoryTiger();
        VerifyFileTiger();
        using (StreamWriter sw = File.AppendText(GetFilePathTiger()))
        {
            string finalString = "";
            for (int i = 0; i < strings.Length; i++)
            {
                if (finalString != "")
                {
                    finalString += reportSeparator;
                }
                finalString += strings[i];
            }
            finalString += reportSeparator + GetTimeStamp();
            sw.WriteLine(finalString);
        }
    }

    public static void CreateReportTiger()
    {
        VerifyDirectoryTiger();
        using (StreamWriter sw = File.CreateText(GetFilePathTiger()))
        {
            string finalString = "";
            for (int i = 0; i < reportHeaders.Length; i++)
            {
                if (finalString != "")
                {
                    finalString += reportSeparator;
                }
                finalString += reportHeaders[i];
            }
            finalString += reportSeparator + timeStampHeader;
            sw.WriteLine(finalString);
        }
    }

    static void VerifyDirectoryTiger()
    {
        string dir = GetDirectoryPathTiger();
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
    }

    static void VerifyFileTiger()
    {
        string file = GetFilePathTiger();
        if (!File.Exists(file))
        {
            CreateReportTiger();
        }
    }


    static string GetDirectoryPathTiger()
    {
        return Application.dataPath + "/" + reportDirectoryName;
    }

    static string GetFilePathTiger()
    {
        return GetDirectoryPath() + "/" + TigerreportFileName;
    }

    public static void AppendToReportPanzerII(string[] strings)
    {
        VerifyDirectoryPanzerII();
        VerifyFilePanzerII();
        using (StreamWriter sw = File.AppendText(GetFilePathPanzerII()))
        {
            string finalString = "";
            for (int i = 0; i < strings.Length; i++)
            {
                if (finalString != "")
                {
                    finalString += reportSeparator;
                }
                finalString += strings[i];
            }
            finalString += reportSeparator + GetTimeStamp();
            sw.WriteLine(finalString);
        }
    }

    public static void CreateReportPanzerII()
    {
        VerifyDirectoryTiger();
        using (StreamWriter sw = File.CreateText(GetFilePathTiger()))
        {
            string finalString = "";
            for (int i = 0; i < reportHeaders.Length; i++)
            {
                if (finalString != "")
                {
                    finalString += reportSeparator;
                }
                finalString += reportHeaders[i];
            }
            finalString += reportSeparator + timeStampHeader;
            sw.WriteLine(finalString);
        }
    }

    static void VerifyDirectoryPanzerII()
    {
        string dir = GetDirectoryPathTiger();
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
    }

    static void VerifyFilePanzerII()
    {
        string file = GetFilePathTiger();
        if (!File.Exists(file))
        {
            CreateReportPanzerII();
        }
    }


    static string GetDirectoryPathPanzerII()
    {
        return Application.dataPath + "/" + reportDirectoryName;
    }

    static string GetFilePathPanzerII()
    {
        return GetDirectoryPath() + "/" + PanzerIIreportFileName;
    }
}

using UnityEngine;
using UnityEditor;

public static class MyTools {

    [MenuItem("My Tools/1. Add Defaults To Report %F1")]
    static void DEV_AppendDefaultsToReport() {
        CSVManager.AppendToReport(
            new string[5] {
                "john",
                Random.Range(0, 11).ToString(),
                Random.Range(0, 11).ToString(),
                Random.Range(0, 11).ToString(),
                Random.Range(0, 11).ToString()
            }
        );
        EditorApplication.Beep();
        Debug.Log("<color=green>Report updated successfully!</color>");
    }

    [MenuItem("My Tools/2. Reset Report %F12")]
    static void DEV_ResetReport() {
        CSVManager.CreateReport();
        EditorApplication.Beep();
        Debug.Log("<color=orange>The report has been reset...</color>");
    }

}

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public static class AppSettings  
{
    // Admin
    public static int buildingChoice;
    // Caretaker and Super
    public static Dictionary<string, string> caretakers = new Dictionary<string, string>();
    public static List<string> adminFaultsList = new List<string>();
    public static List<Fault> allFaults = new List<Fault>();
    public static List<Contractor> allContractors = new List<Contractor>();

}

﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.AspNetCore.Components;

public class NPCManager
{
    private List<NPC> NPCs = new List<NPC>();

    public async void LoadNPCs(HttpClient Http)
    {
        NPC[] npcArray = await Http.GetJsonAsync<NPC[]>("data/NPCs.json");
        NPCs.AddRange(npcArray);
    }

    public NPC GetNPCByID(int id)
    {
        return NPCs[id];
    }
    public string GetNPCData()
    {
        string data = "";
        foreach(NPC npc in NPCs)
        {
            data += "" + npc.IsInteractable + ",";
        }
        data = data.Substring(0, data.Length - 1);
        return data;
    }
    public void LoadNPCData(string data)
    {
        if(data == null || data.Length == 0)
        {
            return;
        }
        string[] lines = data.Split(',');
        int iterator = 0;
        foreach(string s in lines)
        {
            try
            {
                NPCs[iterator].IsInteractable = bool.Parse(s);
            }
            catch
            {
                Console.WriteLine("Failed to parse bool for " + s);


            }
            iterator++;
        }
    }
}

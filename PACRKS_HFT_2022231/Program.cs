﻿using ConsoleTools;
using PACRKS_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PACRKS_HFT_2022231.Client
{
    internal class Program
    {
        static RestService rest;
        static void Create(string entity)
        {
            if (entity == "Player")
            {
                Console.Write("Enter Player Name: ");
                string name = Console.ReadLine();
                rest.Post(new Player() { Username = name }, "player");
            }
        }
        static void List(string entity)
        {
            if (entity == "Player")
            {
                List<Player> players = rest.Get<Player>("player");
                foreach (var item in players)
                {
                    Console.WriteLine(item.PlayerId + ": " + item.Username);
                }
            }
            Console.ReadLine();
        }
        static void Update(string entity)
        {
            if (entity == "Player")
            {
                Console.Write("Enter Player's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Player one = rest.Get<Player>(id, "player");
                Console.Write($"New name [old: {one.Username}]: ");
                string name = Console.ReadLine();
                one.Username = name;
                rest.Put(one, "player");
            }
        }
        static void Delete(string entity)
        {
            if (entity == "Player")
            {
                Console.Write("Enter Player's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "player");
            }
        }

        static void Create2(string entity)
        {
            if (entity == "Stats")
            {
                Console.Write("Enter kills : ");
                double kills = double.Parse(Console.ReadLine());
                Console.Write("Enter deaths: ");
                double deaths = double.Parse(Console.ReadLine());
                int statid = Stathelper() + 1;
                Console.Write("Enter shots fired : ");
                double shots = double.Parse(Console.ReadLine());
                Console.Write("Enter shots connected : ");
                double conn = double.Parse(Console.ReadLine());
                Console.Write("Enter time played : ");
                float time = float.Parse(Console.ReadLine());
                rest.Post(new Stats() { Kills = kills, StatId = statid, TimePlayed = time, ShotsConnected = conn, ShotsFired = shots, Deaths = deaths}, "stats");
            }
        }
        static int Stathelper()
        {
            List<Stats> stats = rest.Get<Stats>("stats");
            return stats.Count;

        }
        static void List2(string entity)
        {
            if (entity == "Stats")
            {
                List<Stats> stats = rest.Get<Stats>("stats");
                foreach (var item in stats)
                {
                    Console.WriteLine(item.StatId + ": " + "Kills: " + item.Kills + ": " + "Deaths: " + item.Deaths + ": " + "Shots fired: " + item.ShotsFired + " Shots conncted : " + item.ShotsConnected + " Time played: " + item.TimePlayed);
                }
            }
            Console.ReadLine();
        }
        static void Update2(string entity)
        {
            if (entity == "Stats")
            {
                Console.Write("Enter Stats's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Stats one = rest.Get<Stats>(id, "stats");

                Console.Write($"New kills [old: {one.Kills}]: ");
                double kills = double.Parse(Console.ReadLine());
                one.Kills = kills;
                Console.Write($"New deaths [old: {one.Deaths}]: ");
                double deaths = double.Parse(Console.ReadLine());
                one.Deaths = deaths;
                Console.Write($"New shots fired [old: {one.ShotsFired}]: ");
                double shotsf = double.Parse(Console.ReadLine());
                one.ShotsFired = shotsf;
                Console.Write($"New shots connected [old: {one.ShotsConnected}]: ");
                double shotsc = double.Parse(Console.ReadLine());
                one.ShotsConnected = shotsc;
                Console.Write($"New time played [old: {one.TimePlayed}]: ");
                float timep = float.Parse(Console.ReadLine());
                one.TimePlayed = timep;

                rest.Put(one, "stats");
            }
        }
        static void Delete2(string entity)
        {
            if (entity == "Stats")
            {
                Console.Write("Enter Stats's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "stats");
            }
        }

        

        static void Create3(string entity)
        {
            if (entity == "Matches")
            {
                Console.Write("Enter Match Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Match type: ");
                string type = Console.ReadLine();
                rest.Post(new Matches() { Map = name, Type = type}, "match");
            }
        }

        static void List3(string entity)
        {
            if (entity == "Matches")
            {
                List<Matches> matches = rest.Get<Matches>("match");
                foreach (var item in matches)
                {
                    Console.WriteLine(item.MatchId + ": " + item.Map);
                }
            }
            Console.ReadLine();
        }
        static void Update3(string entity)
        {
            if (entity == "Matches")
            {
                Console.Write("Enter Match's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Matches one = rest.Get<Matches>(id, "match");
                Console.Write($"New map [old: {one.Map}]: ");
                string name = Console.ReadLine();
                //Console.Write($"New type [old: {one.Type}]: ");
                //string type = Console.ReadLine();
                one.Map = name;
                rest.Put(one, "match");
            }
        }
        static void Delete3(string entity)
        {
            if (entity == "Matches")
            {
                Console.Write("Enter Match's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "match");
            }
        }
        static void Create4(string entity)
        {
            if (entity == "Characters")
            {
                Console.Write("Enter Character's Name: ");
                string name = Console.ReadLine();
                rest.Post(new Characters() { Name = name }, "characters");
            }
        }
        static void List4(string entity)
        {
            if (entity == "Characters")
            {
                List<Characters> characters = rest.Get<Characters>("characters");
                foreach (var item in characters)
                {
                    Console.WriteLine(item.CharacterId + ": " + item.Name);
                }
            }
            Console.ReadLine();
        }
        static void Update4(string entity)
        {
            if (entity == "Characters")
            {
                Console.Write("Enter Character's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Characters one = rest.Get<Characters>(id, "characters");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "characters");
            }
        }
        static void Delete4(string entity)
        {
            if (entity == "Characters")
            {
                Console.Write("Enter Character's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "characters");
            }
        }
        static void AverageKillsInMatchOne(string entity)
        {
            if (entity == "Stats")
            {
                double average = rest.GetSingle<double>("noncrud/action");
                Console.WriteLine("Average kills in game one: " + average);
                Console.ReadLine();
            }

        }

        static void MaxKills(string name)
        {
            if (name == "Stats")
            {
                List<Matches> stats = rest.Get<Matches>("match");
                int statcounter = stats.Count;
                Console.WriteLine($"Enter the id(1-{statcounter}) of the match you want the max kills for: ");
                int id = int.Parse(Console.ReadLine());
                double maxkills = rest.GetSingle<double>($"NonCrud/action/{id}/forMaxKills");
                Console.WriteLine("Match id: " + id + ": Max kills: " + maxkills);
                Console.ReadLine();
            }
        
        }

        static void MinDeaths(string name)
        {
            if (name == "Stats")
            {
                List<Matches> stats = rest.Get<Matches>("match");
                int statcounter = stats.Count;
                Console.WriteLine($"Enter the id(1-{statcounter}) of the match you want the minimum deaths for: ");
                int id = int.Parse(Console.ReadLine());
                double minkills = rest.GetSingle<double>($"NonCrud/action/{id}/formindeaths");
                Console.WriteLine("Match id: " + id + ": Min deaths: " + minkills);
                Console.ReadLine();
            }
        
        }

        static void PlayerKD(string name)
        {
            if (name == "Player")
            {
                List<Player> player = rest.Get<Player>("player");
                Console.WriteLine("Names of the players: ");
                foreach (var item in player)
                {
                    Console.WriteLine(item.Username);
                }
                Console.WriteLine();
                Console.WriteLine("Enter the name of a player you want the K/D of: ");
                
                string id = Console.ReadLine();
                double playerKD = rest.GetSingle<double>($"NonCrud/action/playerkd/{id}");
                Console.WriteLine();
                Console.Write($"Name of the player: {id}  K/D of the player: {playerKD}");
                Console.ReadLine();

            }
        }

        static void PlayerPlayedTime(string name)
        {
            if (name == "Player")
            {
                List<Player> player = rest.Get<Player>("player");
                Console.WriteLine("Names of the players: ");
                foreach (var item in player)
                {
                    Console.WriteLine(item.Username);
                }
                Console.WriteLine();
                Console.WriteLine("Enter the name of a player to see how much he/she played: ");

                string id = Console.ReadLine();
                float timeplayed = (float)rest.GetSingle<double>($"NonCrud/action/playertimeplayed/{id}");
                Console.WriteLine();
                Console.WriteLine($"Name of the player: {id}  Time he played: {timeplayed} minutes");
                Console.ReadLine();
            }
        }


        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:35367/", "swagger");
            try
            {

            
            var playerSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Player"))
                .Add("Create", () => Create("Player"))
                .Add("Delete", () => Delete("Player"))
                .Add("Update", () => Update("Player"))
                .Add("Exit", ConsoleMenu.Close);

            var statsSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List2("Stats"))
                .Add("Create", () => Create2("Stats"))
                .Add("Delete", () => Delete2("Stats"))
                .Add("Update", () => Update2("Stats"))
                .Add("Exit", ConsoleMenu.Close);

            var matchesSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List3("Matches"))
                .Add("Create", () => Create3("Matches"))
                .Add("Delete", () => Delete3("Matches"))
                .Add("Update", () => Update3("Matches"))
                .Add("Exit", ConsoleMenu.Close);

            var charactersSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List4("Characters"))
                .Add("Create", () => Create4("Characters"))
                .Add("Delete", () => Delete4("Characters"))
                .Add("Update", () => Update4("Characters"))
                .Add("Exit", ConsoleMenu.Close);

            var noncrudSubMenu = new ConsoleMenu(args, level: 1)
                .Add("Show me the average kills in the first match!", () => AverageKillsInMatchOne("Stats"))
                .Add("Show me the max kills in a certain match!", () => MaxKills("Stats"))
                .Add("Show me the minimum number of deaths in a certain match!", () => MinDeaths("Stats"))
                .Add("Show me the K/D of a certain player!", () => PlayerKD("Player"))
                .Add("Show me how much a certain player played in a game!", () => PlayerPlayedTime("Player"))
                .Add("Exit", ConsoleMenu.Close);



            var menu = new ConsoleMenu(args, level: 0)
                .Add("Player", () => playerSubMenu.Show())
                .Add("Stats", () => statsSubMenu.Show())
                .Add("Matches", () => matchesSubMenu.Show())
                .Add("Characters", () => charactersSubMenu.Show())
                .Add("Non crud menu points", () => noncrudSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
            }
            catch (Exception)
            {

            }
        }
    }
}

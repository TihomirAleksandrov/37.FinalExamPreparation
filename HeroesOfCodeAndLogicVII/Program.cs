using System;
using System.Collections.Generic;
using System.Linq;

namespace HeroesOfCodeAndLogicVII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int heroNum = int.Parse(Console.ReadLine());

            Dictionary<string, HeroStats> heroes = GetHeroes(heroNum);

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] splitInput = input.Split(" - ").ToArray();

                string command = splitInput[0];
                string heroName = splitInput[1];

                if (command == "CastSpell")
                {
                    int manaNeeded = int.Parse(splitInput[2]);
                    string spellName = splitInput[3];

                    CastSpell(heroes, heroName, manaNeeded, spellName);
                }
                else if (command == "TakeDamage")
                {
                    int damage = int.Parse(splitInput[2]);
                    string attacker = splitInput[3];

                    TakeDamage(heroes, heroName, damage, attacker);
                }
                else if (command == "Recharge")
                {
                    int manaAmount = int.Parse(splitInput[2]);

                    RechargeMP(heroes, heroName, manaAmount);
                }
                else if (command == "Heal")
                {
                    int healthAmount = int.Parse(splitInput[2]);

                    Heal(heroes, heroName, healthAmount);
                }
            }

            foreach (var hero in heroes)
            {
                Console.WriteLine($"{hero.Key} \n  HP: {hero.Value.HitPoints} \n  MP: {hero.Value.ManaPoints}");
            }
        }

        static void Heal(Dictionary<string, HeroStats> heroes, string heroName, int amount)
        {
            int oldHP = heroes[heroName].HitPoints;
            heroes[heroName].HitPoints += amount;
            int totalHP = heroes[heroName].HitPoints;

            if (totalHP > 100)
            {
                heroes[heroName].HitPoints = 100;
                amount = 100 - oldHP;
            }

            Console.WriteLine($"{heroName} healed for {amount} HP!");
        }

        static void RechargeMP(Dictionary<string, HeroStats> heroes, string heroName, int amount)
        {
            int oldMP = heroes[heroName].ManaPoints;
            heroes[heroName].ManaPoints += amount;
            int totalMP = heroes[heroName].ManaPoints;

            if (totalMP > 200)
            {
                heroes[heroName].ManaPoints = 200;
                amount = 200 - oldMP;
            }

            Console.WriteLine($"{heroName} recharged for {amount} MP!");
        }

        static void TakeDamage(Dictionary<string, HeroStats> heroes, string heroName, int damage, string attacker)
        {
            heroes[heroName].HitPoints -= damage;
            int hpLeft = heroes[heroName].HitPoints;
            if (hpLeft > 0)
            {
                Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {hpLeft} HP left!");
            }
            else
            {
                Console.WriteLine($"{heroName} has been killed by {attacker}!");

                heroes.Remove(heroName);
            }
        }

        static void CastSpell(Dictionary<string, HeroStats> heroes, string heroName, int manaNeeded, string spellNAme)
        {
            if (heroes[heroName].ManaPoints >= manaNeeded)
            {
                heroes[heroName].ManaPoints -= manaNeeded;
                
                Console.WriteLine($"{heroName} has successfully cast {spellNAme} and now has {heroes[heroName].ManaPoints} MP!");
            }
            else
            {
                Console.WriteLine($"{heroName} does not have enough MP to cast {spellNAme}!");
            }
        }

        static Dictionary<string, HeroStats> GetHeroes(int heroNum)
        {
            Dictionary<string, HeroStats> heroesInfo = new Dictionary<string, HeroStats>();

            for (int i = 0; i < heroNum; i++)
            {
                string[] hero = Console.ReadLine().Split().ToArray();

                string heroName = hero[0];
                int heroHP = int.Parse(hero[1]);
                int heroMP = int.Parse(hero[2]);

                heroesInfo.Add(heroName, new HeroStats(heroHP, heroMP));
            }

            return heroesInfo;
        }
    }

    public class HeroStats
    {
        public HeroStats(int hitPoints, int manaPoints)
        {
            HitPoints = hitPoints;

            ManaPoints = manaPoints;
        }

        public int HitPoints { get; set; }

        public int ManaPoints { get; set; }
    }
}

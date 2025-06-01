class Program
{
    class Player
    {
        public int health;
        public int happiness;
        public int money;
        public int hunger;

        public void ClampStats()
        {
            health = Math.Clamp(health, 0, 100);
            happiness = Math.Clamp(happiness, 0, 100);
            hunger = Math.Clamp(hunger, 0, 100);

            if (money < -50)
            {
                Console.WriteLine("You got into deep debt. The police arrested you for fare evasion, theft, and tax fraud.");
                Console.WriteLine("Game over.");
                Environment.Exit(0);
            }

            if (health == 0 || happiness == 0 || hunger == 100)
            {
                Console.WriteLine("You died. Game over.");
                Environment.Exit(0);
            }

            if (money < 0)
            {
                Console.WriteLine("You're in debt! Be careful...");
            }
        }



        public bool IsDead()
        {
            return health == 0 || happiness == 0 || money == 0 || hunger == 100;
        }
    }

    static void Main()
    {
        Player p = new Player()
        {
            health = 100,
            happiness = 100,
            money = 250,
            hunger = 0
        };

        while (true)
        {
            if (p.IsDead())
            {
                Console.WriteLine("You died. Game over.");
                break;
            }

            Console.WriteLine("\nWhat do you wanna do? (kebab, kofola, job, shadyjob, halong, drugstore, walk)");
            string vyberuzivatele = Console.ReadLine()!;

            switch (vyberuzivatele)
            {
                case "kebab":
                    Kebab(p);
                    break;
                case "kofola":
                    Kofolka(p);
                    break;
                case "job":
                    PracevYoonu(p);
                    break;
                case "shadyjob":
                    ProdavaniVapiku(p);
                    break;
                case "halong":
                    HaLong(p);
                    break;
                case "drugstore":
                    Lekarna(p);
                    break;
                case "walk":
                    Prochazka(p);
                    break;
                default:
                    Console.WriteLine("Either the code is fucked up or you didn't enter a valid option");
                    break;
            }

            p.ClampStats();
        }
    }

    static void Kebab(Player p)
    {
        p.health -= 30;
        p.happiness += 20;
        p.money -= 100;

        if (p.hunger > 0)
        {
            p.hunger -= 30;
            Console.WriteLine("You ate kebab. It reduced your hunger.");
        }
        else
        {
            Console.WriteLine("You ate kebab, but you weren't hungry.");
        }

        ShowStats(p);
    }


    static void Kofolka(Player p)
    {
        p.health += 10;
        p.happiness += 30;
        p.money -= 30;
        Console.WriteLine($"You had kofolka.");
        ShowStats(p);
    }

    static void PracevYoonu(Player p)
    {
        p.happiness -= 10;
        p.money += 100;
        p.hunger += 30;
        Console.WriteLine($"You worked in Yoon for a day.");
        ShowStats(p);
    }

    static void ProdavaniVapiku(Player p)
    {
        p.health -= 30;
        p.money += 200;
        p.hunger += 20;
        Console.WriteLine($"You sold vapes to children (bastard). One of the parents fought you.");
        ShowStats(p);
    }

    static void HaLong(Player p)
    {
        p.happiness -= 10;
        p.money -= 100;

        if (p.hunger > 0)
        {
            p.hunger -= 30;
            Console.WriteLine("You ate moldy food in HaLong. It slightly reduced your hunger.");
        }
        else
        {
            Console.WriteLine("You waited forever in HaLong, ate moldy food, but weren't even hungry.");
        }

        p.health -= 20;
        ShowStats(p);
    }


    static void Lekarna(Player p)
    {
        p.happiness += 20;
        p.money -= 20;
        p.health += 50;
        p.hunger += 10;
        Console.WriteLine($"You bought some medicine. The lady gave you a free sample of sunscreen.");
        ShowStats(p);
    }

    static void Prochazka(Player p)
    {
        p.happiness += 50;
        p.health += 20;
        p.hunger += 20;
        Console.WriteLine($"You went for a walk in the forest.");
        ShowStats(p);
    }

    static void ShowStats(Player p)
    {
        Console.WriteLine($"Your statistics are health: {p.health}, happiness: {p.happiness}, money: {p.money}, hunger: {p.hunger}");
    }
}


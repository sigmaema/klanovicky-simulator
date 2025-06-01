using Spectre.Console;

class Program
{
    class Player(int initialHealth = 100, int initialHappiness = 100, int initialMoney = 250, int initialHunger = 0)
    {
        public int Health { get; set; } = initialHealth;
        public int Happiness { get; set; } = initialHappiness;
        public int Money { get; set; } = initialMoney;
        public int Hunger { get; set; } = initialHunger;

        public void ClampStats()
        {
            Health = Math.Clamp(Health, 0, 100);
            Happiness = Math.Clamp(Happiness, 0, 100);
            Hunger = Math.Clamp(Hunger, 0, 100);

            if (Money < -50)
            {
                Console.WriteLine("You got into deep debt. The police arrested you for fare evasion, theft, and tax fraud.");
                Console.WriteLine("Game over.");
                Environment.Exit(0);
            }

            if (Health == 0 || Happiness == 0 || Hunger == 100)
            {
                Console.WriteLine("You died. Game over.");
                Environment.Exit(0);
            }

            if (Money < 0)
            {
                Console.WriteLine("You're in debt! Be careful...");
            }
        }

        public bool IsDead()
        {
            return Health == 0 || Happiness == 0 || Hunger == 100;
        }
    }

    static void Main()
    {
        Player p = new Player();

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
        p.Health -= 30;
        p.Happiness += 20;
        p.Money -= 100;

        if (p.Hunger > 0)
        {
            p.Hunger -= 30;
            AnsiConsole.Write(new Markup("[bold]You ate kebab. It was delicious but a little sus.[/]\n"));
        }
        else
        {
            AnsiConsole.Write(new Markup("[bold]You ate kebab, but you weren't even hungry.[/]\n"));
        }

        ShowStats(p);
    }

    static void Kofolka(Player p)
    {
        p.Health += 10;
        p.Happiness += 30;
        p.Money -= 30;
        AnsiConsole.Write(new Markup("[bold]You had kofolka. It made you very happy[/]\n"));
        ShowStats(p);
    }

    static void PracevYoonu(Player p)
    {
        p.Happiness -= 10;
        p.Money += 100;
        p.Hunger += 30;
        AnsiConsole.Write(new Markup("[bold]You worked in Yoon for a day. You made a lot of money[/]\n"));
        ShowStats(p);
    }

    static void ProdavaniVapiku(Player p)
    {
        p.Health -= 30;
        p.Money += 200;
        p.Hunger += 20;
        AnsiConsole.Write(new Markup("[bold]You sold vapes to children (bastard). One of the parents fought you.[/]\n"));
        ShowStats(p);
    }

    static void HaLong(Player p)
    {
        p.Happiness -= 10;
        p.Money -= 100;

        if (p.Hunger > 0)
        {
            p.Hunger -= 30;
            AnsiConsole.Write(new Markup("[bold]You ate moldy food in HaLong. It slightly reduced your hunger.[/]\n"));
        }
        else
        {
            AnsiConsole.Write(new Markup("[bold]You waited forever in HaLong, ate moldy food, but weren't even hungry.[/]\n"));
        }

        p.Health -= 20;
        ShowStats(p);
    }

    static void Lekarna(Player p)
    {
        p.Happiness += 20;
        p.Money -= 20;
        p.Health += 50;
        p.Hunger += 10;
        AnsiConsole.Write(new Markup("[bold]You bought some medicine. The lady gave you a free sample of sunscreen.[/]\n"));
        ShowStats(p);
    }

    static void Prochazka(Player p)
    {
        p.Happiness += 50;
        p.Health += 20;
        p.Hunger += 20;
        AnsiConsole.Write(new Markup("[bold]You went for a walk in the forest.[/]\n"));
        ShowStats(p);
    }

    static string FormatMoney(int value)
    {
        if (value < 0)
            return $"[red]{value}[/]";
        if (value < 50)
            return $"[yellow]{value}[/]";
        return $"[green]{value}[/]";
    }

    static string FormatHunger(int hunger)
    {
        if (hunger >= 100)
            return $"[bold red]{hunger}[/]";
        else if (hunger >= 70)
            return $"[yellow]{hunger}[/]";
        else
            return $"[green]{hunger}[/]";
    }
    static string FormatHappiness(int happiness)
    {
        if (happiness <= 40)
            return $"[bold red]{happiness}[/]";
        else if (happiness <= 70)
            return $"[yellow]{happiness}[/]";
        else
            return $"[green]{happiness}[/]";
    }
    static string FormatHealth(int health)
    {
        if (health <= 40)
            return $"[bold red]{health}[/]";
        else if (health <= 70)
            return $"[yellow]{health}[/]";
        else
            return $"[green]{health}[/]";
    }

    static void ShowStats(Player p)
    {
        var table = new Table();
        table.AddColumn("Stat");
        table.AddColumn("Value");

        table.AddRow("Health", FormatHealth(p.Health));
        table.AddRow("Happiness", FormatHappiness(p.Happiness));
        table.AddRow("Money", FormatMoney(p.Money));
        table.AddRow("Hunger", FormatHunger(p.Hunger));

        AnsiConsole.Write(table);
    }
}


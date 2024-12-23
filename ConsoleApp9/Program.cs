using ConsoleApp5;
 
class Game
{
    public static GameField CurrentField;
    public static Character ChooseCharacter(int a) 
    { 
        switch (a)
        {
            case 1:
                Console.WriteLine("Введите имя");
                return new Warrior(Console.ReadLine());
                 
            case 2:
                Console.WriteLine("Введите имя");
                return new Archer(Console.ReadLine());
                
        }
        return null;
    }
    static void MovePlayer(Character player, ConsoleKey key)
    {
        switch (key)
        {
            case ConsoleKey.W: 
                player.PosY--; 
                break;
            case ConsoleKey.S:
                player.PosY++; 
                break;
            case ConsoleKey.A:
                player.PosX--; 
                break;
            case ConsoleKey.D:
                player.PosX++;
                break;
        }
    }
    static void atackPlayer(Character atacker, ConsoleKey key,Character defender)
    {
        switch (key)
        {
            case ConsoleKey.U:
                atacker.SpecialAttack(defender);
                break;
            case ConsoleKey.F:
                atacker.Attack(defender);
                break;
        }
    }
    static void Main(string[] args)
        {
        Game.CurrentField = new GameField(10, 10);
        Console.WriteLine("Игрок 1 выберите персонажа (1 = Warrior; 2 = Archer)");
        int i = Convert.ToInt32(Console.ReadLine());
        Character player1 = Game.ChooseCharacter(i);
        Console.WriteLine();
        Console.WriteLine("Игрок 2 выберите персонажа (1 = Warrior; 2 = Archer)");
        int j = Convert.ToInt32(Console.ReadLine());
        Character player2 = Game.ChooseCharacter(j);
        Console.WriteLine();
        player1.PosX = 0;
        player1.PosY = 0;
        player2.PosX = CurrentField.Width-1;
        player2.PosY = CurrentField.Height-1;
        char[,] pole = CurrentField.initializfield(player1, player2);
        CurrentField.DisplayField(pole);
        bool gaming = true;
        while (gaming)
        {
            bool nado1 = true;
            bool nado2 = true;
            char[,] poleotkat = pole;
            int otkat1X = player1.PosX;
            int otkat1Y = player1.PosY;
            int otkat2X = player2.PosX;
            int otkat2Y = player2.PosY;
            Console.WriteLine($"{player1.Name} имеет {player1.Health} здоровья, {player2.Name} имеет {player2.Health} здоровья");
            Console.WriteLine("Передвижение W вверх A влево S вниз D вправо F атака U специальная атака (Ход игрока 1)");
            
            
            while (nado1)
            {
                var key1 = Console.ReadKey(true).Key;
                if (key1 == ConsoleKey.W|| key1 == ConsoleKey.A|| key1 == ConsoleKey.D|| key1 == ConsoleKey.S) { Game.MovePlayer(player1, key1); }
                else if (key1 == ConsoleKey.U || key1 == ConsoleKey.F) { Game.atackPlayer(player1, key1, player2); }
                else 
                {
                    Console.WriteLine("Некоректная команда");
                    continue;
                }
                if (player1.PosX == player2.PosX && player1.PosY == player2.PosY)  
                {
                    pole = poleotkat;
                    player1.PosX = otkat1X;
                    player1.PosY = otkat1Y;
                    Console.WriteLine("Невозможный ход");
                    continue;
                }
                nado1 = false;
            }
            pole = CurrentField.initializfield(player1, player2);
            CurrentField.DisplayField(pole);
            Console.WriteLine($"{player1.Name} имеет {player1.Health} здоровья, {player2.Name} имеет {player2.Health} здоровья");
            Console.WriteLine("Передвижение W вверх A влево S вниз D вправо F атака U специальная атака (Ход игрока 2)");
            if (player1.Health <= 0 || player2.Health <= 0)
            {
                gaming = false;
                continue;
            }


            while (nado2)
            {
                var key2 = Console.ReadKey(true).Key;
                if (key2 == ConsoleKey.W || key2 == ConsoleKey.A || key2 == ConsoleKey.D || key2 == ConsoleKey.S) { Game.MovePlayer(player2, key2); }
                else if (key2 == ConsoleKey.U || key2 == ConsoleKey.F) { Game.atackPlayer(player2, key2, player1); }
                else
                {
                    Console.WriteLine("Некоректная команда");
                    continue;
                }
                if (player1.PosX == player2.PosX && player1.PosY == player2.PosY)
                {
                    pole = poleotkat;
                    player2.PosX = otkat2X;
                    player2.PosY = otkat2Y;
                    Console.WriteLine("Невозможный ход");
                    continue;
                }
                nado2 = false;
            }
            pole = CurrentField.initializfield(player1, player2);
            CurrentField.DisplayField(pole);
            if (player1.Health <= 0 || player2.Health <= 0)
            {
                gaming = false;
            }
        }
    }
}
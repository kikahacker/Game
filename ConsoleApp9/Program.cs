using ConsoleApp5;
 
class Game
{
    public static GameField CurrentField;
    public static Character ChooseCharacter(int a) 
    { 
        switch (a)
        {
            case 1:
                return new Warrior("warrior");
                break;
            case 2:
                return new Archer("archer");
                break;
        }
        return null;
    }
    static void Main(string[] args)
    {
        Game.CurrentField = new GameField(10, 10);
        Console.WriteLine("Игрок 1 выберите персонажа (1 = Warrior; 2 = Archer)");
        int i = Convert.ToInt32(Console.ReadLine());
        Character player1 = Game.ChooseCharacter(i);
        Console.WriteLine("Игрок 2 выберите персонажа (1 = Warrior; 2 = Archer)");
        int j = Convert.ToInt32(Console.ReadLine());
        Character player2 = Game.ChooseCharacter(j);

        char[,] pole = CurrentField.initializfield();
        CurrentField.DisplayField(pole);
    }
}
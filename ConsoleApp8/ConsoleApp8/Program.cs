using System;

// Интерфейс IWeapon
public interface IWeapon
{
    void UseWeapon();
}

// Реализация для меча
public class Sword : IWeapon
{
    public void UseWeapon()
    {
        Console.WriteLine("Атакует мечом!");
    }
}

// Реализация для лука
public class Bow : IWeapon
{
    public void UseWeapon()
    {
        Console.WriteLine("Стреляет из лука!");
    }
}

// Реализация для топора
public class Axe : IWeapon
{
    public void UseWeapon()
    {
        Console.WriteLine("Атакует топором!");
    }
}

// Класс Player
public class Player
{
    private IWeapon _weapon;

    public Player(IWeapon weapon)
    {
        _weapon = weapon;
    }

    public void SetWeapon(IWeapon weapon)
    {
        _weapon = weapon;
    }

    public void Attack()
    {
        _weapon.UseWeapon();
    }
}

// Класс Game
public class Game
{
    private Player _player;

    public Game()
    {
        // Изначально игрок получает оружие.
        _player = new Player(new Sword());
    }

    public void Start()
    {
        Console.WriteLine("Игра началась!");
        string command;

        do
        {
            Console.WriteLine("Введите команду (атака, юз меч, юз лук, юз топор, выход):");
            command = Console.ReadLine();

            switch (command.ToLower())
            {
                case "атака":
                    _player.Attack();
                    break;
                case "юз меч":
                    _player.SetWeapon(new Sword());
                    Console.WriteLine("Оружие изменено на меч.");
                    break;
                case "юз лук":
                    _player.SetWeapon(new Bow());
                    Console.WriteLine("Оружие изменено на лук.");
                    break;
                case "юз топор":
                    _player.SetWeapon(new Axe());
                    Console.WriteLine("Оружие изменено на топор.");
                    break;
                case "выход":
                    Console.WriteLine("Игра завершена.");
                    break;
                default:
                    Console.WriteLine("Неизвестная команда.");
                    break;
            }
        } while (command.ToLower() != "выход");
    }
}

// Основная программа
public class Program
{
    public static void Main(string[] args)
    {
        Game game = new Game();
        game.Start();
    }
}
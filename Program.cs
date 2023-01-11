using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight_check_in
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // инициализация массива с секторами и местами в них
            int[] sectors = { 15, 26, 10, 12, 8 };
            bool isOpen = true;

            while (isOpen)
            {
                // смещение информации внмз консоли  
                // вывод информации по секторам и местам 
                Console.SetCursorPosition(0, 16);
                for (int i = 0; i < sectors.Length; i++)
                {
                    Console.WriteLine($"В секторе {i + 1} свободно {sectors[i]} мест."); 

                }

                // оформление программы (наименование + команды)
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Регистрация на рейс.");
                Console.WriteLine("\n\n1 - забронировать места.\n\n2 - выход.\n\n");
                Console.Write("Введите номер команды:  ");
               
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1: int userSector, userSeatsAmount;
                        Console.Write("В каком секторе вы хотите лететь?  ");
                        userSector = Convert.ToInt32(Console.ReadLine()) - 1;
                        if (sectors.Length <= userSector)
                        {
                            Console.WriteLine("Такого сектора не существует.");
                        }
                        Console.Write("Сколько мест вы хотите забронировать?  ");
                        userSeatsAmount = Convert.ToInt32(Console.ReadLine());  
                        if (userSeatsAmount < 0)
                        {
                            Console.WriteLine("Неверное количество мест.");
                        }
                        if (sectors[userSector] < userSeatsAmount  || userSeatsAmount < 0)
                        {
                            Console.WriteLine($"В секторе {userSector} недостаточно мест." +
                                $"Остаток {sectors[userSector]}.");
                            break;
                        }

                        sectors[userSector] -= userSeatsAmount;
                        Console.WriteLine("Бронирование успешно!");
                        break;
                    case 2: isOpen = false;
                        break;
                }

                // остановка цикла и очистка консоли     
                Console.ReadKey();
                Console.Clear();
            }

        }
    }
}

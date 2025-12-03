using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaWork4_2
{
    public class Money
    {
        private uint _rubles;
        private byte _kopeks;

        public uint Rubles
        {
            get => _rubles;
            private set => _rubles = value;
        }

        public byte Kopeks
        {
            get => _kopeks;
            private set
            {
                if (value >= 100)
                    throw new ArgumentException("Копейки не могут быть >= 100");
                _kopeks = value;
            }
        }

        // Конструкторы
        public Money(uint rubles = 0, byte kopeks = 0)
        {
            if (kopeks >= 100)
                throw new ArgumentException("Копейки не могут быть >= 100");

            Rubles = rubles;
            Kopeks = kopeks;
        }

        public Money(Money other)
        {
            Rubles = other.Rubles;
            Kopeks = other.Kopeks;
        }

        // Метод из задания 6
        public Money AddKopeks(uint kopeksToAdd)
        {
            ulong totalKopeks = (ulong)Rubles * 100 + Kopeks + kopeksToAdd;
            uint newRubles = (uint)(totalKopeks / 100);
            byte newKopeks = (byte)(totalKopeks % 100);

            if (newRubles < Rubles) // Проверка переполнения
                throw new OverflowException("Переполнение при добавлении копеек");

            return new Money(newRubles, newKopeks);
        }

        // Перегрузка ToString()
        public override string ToString()
        {
            return $"{Rubles} руб. {Kopeks:00} коп.";
        }

        // Унарные операторы (задание 7)
        public static Money operator ++(Money money)
        {
            return money.AddKopeks(1);
        }

        public static Money operator --(Money money)
        {
            if (money.Kopeks == 0 && money.Rubles == 0)
                return new Money(0, 0);

            ulong totalKopeks = (ulong)money.Rubles * 100 + money.Kopeks - 1;
            uint newRubles = (uint)(totalKopeks / 100);
            byte newKopeks = (byte)(totalKopeks % 100);

            return new Money(newRubles, newKopeks);
        }

        // Операторы приведения (задание 7)
        public static explicit operator uint(Money money)
        {
            return money.Rubles;
        }

        public static implicit operator double(Money money)
        {
            return money.Kopeks / 100.0;
        }

        // Бинарные операторы (задание 7)
        public static Money operator +(Money money, uint kopeks)
        {
            return money.AddKopeks(kopeks);
        }

        public static Money operator +(uint kopeks, Money money)
        {
            return money.AddKopeks(kopeks);
        }

        public static Money operator -(Money money, uint kopeks)
        {
            ulong totalKopeks = (ulong)money.Rubles * 100 + money.Kopeks;

            if (kopeks > totalKopeks)
                return new Money(0, 0);

            totalKopeks -= kopeks;
            uint newRubles = (uint)(totalKopeks / 100);
            byte newKopeks = (byte)(totalKopeks % 100);

            return new Money(newRubles, newKopeks);
        }

        public static Money operator -(uint kopeks, Money money)
        {
            ulong moneyTotalKopeks = (ulong)money.Rubles * 100 + money.Kopeks;

            if (moneyTotalKopeks > kopeks)
                return new Money(0, 0);

            ulong result = kopeks - moneyTotalKopeks;
            uint newRubles = (uint)(result / 100);
            byte newKopeks = (byte)(result % 100);

            return new Money(newRubles, newKopeks);
        }
    }
}

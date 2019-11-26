using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            var bancomat_ru = new Bancomat(CurrencyType.Ruble);
            var firstBanknotes = bancomat_ru.WithdrawСash(2050, CurrencyType.Ruble);

            var bancomat_en = new Bancomat(CurrencyType.Dollar);
            var secondBanknotest = bancomat_en.WithdrawСash(2140, CurrencyType.Dollar);


            foreach (var banknote in firstBanknotes)
            {
                Console.WriteLine(banknote + "руб." + " ");
            }

            foreach (var banknote in secondBanknotest)
            {
                Console.WriteLine(banknote + "$" + " ");
            }
        }
    }

    public enum CurrencyType
    {
        Eur,
        Dollar,
        Ruble
    }

    public interface IBanknote
    {
        CurrencyType Currency { get; }
        string Value { get; }
    }

    public class Bancomat
    {
        private readonly BanknoteHandler _handler;
        private readonly CurrencyType _type;
        public Bancomat(CurrencyType type)
        {
            _type = type;
            _handler = new BanknoteHandler(null, 20, _type);
            _handler = new BanknoteHandler(_handler, 50, _type);
            _handler = new BanknoteHandler(_handler, 200, _type);
            _handler = new BanknoteHandler(_handler, 1000, _type);
        }


        public List<int> WithdrawСash(int cash, CurrencyType type)
        {
            return _handler.Hendle(cash, new List<int>(), type);
        }
    }

    public interface IBanknoteHandler
    {
        List<int> Hendle(int cash, List<int> banknotes, CurrencyType type);
    }

    public class BanknoteHandler : IBanknoteHandler
    {
        private readonly IBanknoteHandler _hendler;
        private readonly int _value;
        private readonly CurrencyType _type;
        public BanknoteHandler(IBanknoteHandler hendler, int value, CurrencyType type)
        {
            _hendler = hendler;
            _value = value;
            _type = type;
        }

        public List<int> Hendle(int cash, List<int> banknotes, CurrencyType type)
        {
            if (_type != type)
            {
                throw new Exception("Сurrency error");
            }
            while (cash - _value > -1)
            {
                cash -= _value;
                banknotes.Add(_value);
            }

            if (_hendler != null)
            {
                return _hendler.Hendle(cash, banknotes, type);
            }
            return cash == 0 ? banknotes : throw new Exception("failed transaction");
        }
    }
}

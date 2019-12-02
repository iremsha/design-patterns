using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new PrintingContext();
            var flashUSB = new FlashUSB();
            var document = new WordDocument();
            context.InputCash(100); //Сумма в 100 денежных единиц принята
            context.ChooseDevice(flashUSB); //Устройство принято
            context.ChooseDocument(document); //Документ принят
            context.PrintingDocument(); //Печатаю документ..
            context.IsRepeat(false); //Печать завершина
            context.GetCash(); //Заберите сдачу
            context.Close();
            context.ChooseDocument(document); //Error: Exception("Печать была завершина")
        }


        public class PrintingContext
        {
            public IState State { get; set; }
            public IDevice divice { get; set; }
            public IDocument document { get; set; }
            public PrintingContext()
            {
                State = new InputCashState();
            }
            public void InputCash(int cash)
            {
                State.InputCash(this, cash);
            }

            public void ChooseDevice(IDevice device)
            {
                State.ChooseDevice(this, device);
            }
            public void ChooseDocument(IDocument document)
            {
                State.ChooseDocument(this, document);
            }
            public void PrintingDocument()
            {
                State.PrintingDocument(this);
            }
            public void IsRepeat(bool repeat)
            {
                State.IsRepeat(this, repeat);
            }
            public void GetCash()
            {
                State.GetCash(this);
            }
            public void Close()
            {
                State.Close(this);
            }

        }
        public interface IDevice
        {

        }
        class FlashUSB: IDevice
        {

        }
        public interface IDocument
        {

        }
        class WordDocument: IDocument
        {

        }
        public interface IState
        {
            void InputCash(PrintingContext context, int cash);
            void ChooseDevice(PrintingContext context, IDevice device);
            void ChooseDocument(PrintingContext context, IDocument document);
            void PrintingDocument(PrintingContext context);
            void IsRepeat(PrintingContext context, bool repeat);
            void GetCash(PrintingContext context);
            void Close(PrintingContext context);

        }
        public abstract class BaseState : IState
        {
            public virtual void ChooseDevice(PrintingContext context, IDevice device) { }
            public virtual void ChooseDocument(PrintingContext context, IDocument document) { }
            public virtual void GetCash(PrintingContext context) { }
            public virtual void InputCash(PrintingContext context, int cash) { }
            public virtual void IsRepeat(PrintingContext context, bool repeat) { }
            public virtual void PrintingDocument(PrintingContext context) { }
            public virtual void Close(PrintingContext context)
            {
                context.State = new CloseState();
            }
        }
        public class InputCashState : BaseState
        {
            public override void InputCash(PrintingContext context, int cash)
            {
                Console.WriteLine($"Сумма в {cash} денежных единиц принята");
                context.State = new ChooseDeviceState();
            }

        }
        public class ChooseDeviceState : BaseState
        {
            public override void ChooseDevice(PrintingContext context, IDevice device)
            {
                Console.WriteLine($"Устройство принято");
                context.State = new ChooseDocumentState();
            }

        }
        public class ChooseDocumentState : BaseState
        {
            public override void ChooseDocument(PrintingContext context, IDocument document)
            {
                Console.WriteLine($"Документ принят");
                context.State = new PrintingDocumentState();
            }

        }
        public class PrintingDocumentState : BaseState
        {
            public override void PrintingDocument(PrintingContext context)
            {
                Console.WriteLine($"Печатаю документ..");
                context.State = new IsRepeatState();
            }

        }
        public class IsRepeatState : BaseState
        {
            public override void IsRepeat(PrintingContext context, bool repeat)
            {
                if (repeat)
                {
                    Console.WriteLine($"Повторяю печать");
                    context.State = new ChooseDocumentState();
                }
                else
                {
                    Console.WriteLine($"Печать завершина");
                    context.State = new GetCashState();
                }

            }

        }
        public class GetCashState : BaseState
        {
            public override void GetCash(PrintingContext context)
            {
                Console.WriteLine($"Заберите сдачу");
                context.State = new CloseState();
            }

        }
        public class CloseState : BaseState
        {
            public override void ChooseDevice(PrintingContext context, IDevice device)
            {
                throw new Exception("Печать была завершина");
            }
            public override void ChooseDocument(PrintingContext context, IDocument document)
            {
                throw new Exception("Печать была завершина");
            }
            public override void GetCash(PrintingContext context)
            {
                throw new Exception("Печать была завершина");
            }
            public override void InputCash(PrintingContext context, int cash)
            {
                throw new Exception("Печать была завершина");
            }
            public override void IsRepeat(PrintingContext context, bool repeat)
            {
                throw new Exception("Печать была завершина");
            }
            public override void PrintingDocument(PrintingContext context)
            {
                throw new Exception("Печать была завершина");
            }
        }
    }
}

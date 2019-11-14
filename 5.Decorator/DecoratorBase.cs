using System;
using System.Net.NetworkInformation;

namespace Decorator
{
    public class DecoratorBase : IMessage
    {
        private IMessage Decoratee;

        public DecoratorBase(IMessage msg)
        {
            Decoratee = msg;
        }


        public string GetAuthor()
        {
            return HideName(Decoratee.GetAuthor());
        }

        public string GetText()
        {
            return EncodeText(Decoratee.GetText());
        }

        public string GetAddress()
        {
            return DecodeText(EncodeText(Decoratee.GetAddress()));
        }

        protected virtual string HideName(string name)
        {
            return name;
        }

        protected virtual string EncodeText(string text)
        {
            return text;
        }  
        
        protected virtual string DecodeText(string text)
        {
            return text;
        }  
    }

    public class HideDecorater : DecoratorBase
    {
        public HideDecorater(IMessage msg) : base(msg)
        { }

        protected override string HideName(string name)
        { 
            return base.HideName($"-hide-{name}-hide-");
        }
    }
    
    public class CoderDecorater: DecoratorBase
    {
        public CoderDecorater(IMessage msg) : base(msg)
        { }

        protected override string EncodeText(string text)
        {
            return base.EncodeText($"-lock-{text}-lock-");
        }
    }
    
    public class EncoderDecorater : DecoratorBase
    {
        public EncoderDecorater(IMessage msg) : base(msg)
        { }

        protected override string DecodeText(string text)
        {
            return base.DecodeText($"-unlock-{text}-unlock-");
        }
    }
}
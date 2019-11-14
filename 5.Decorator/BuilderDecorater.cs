namespace Decorator
{
    public class BuilderDecorater
    {
        private IMessage _msg;

        public BuilderDecorater(IMessage msg)
        {
            _msg = msg;
        }

        public BuilderDecorater HidingNames()
        {
            _msg = new HideDecorater(_msg);
            return this;
        }
        
        public BuilderDecorater Coder()
        {
            _msg = new CoderDecorater(_msg);
            return this;
        }
        
        public BuilderDecorater Decoder()
        {
            _msg = new EncoderDecorater(_msg);
            return this;
        }

        public IMessage Build()
        {
            return _msg;
        }
    }
}
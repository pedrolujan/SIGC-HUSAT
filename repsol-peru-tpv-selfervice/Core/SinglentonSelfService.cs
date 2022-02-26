namespace selferviceSIGC.Core
{
    public class SinglentonSelfService
    {
        public SelfServiceBase _singletonSelfService => SelfServiceBase.Instance;
    }
}
